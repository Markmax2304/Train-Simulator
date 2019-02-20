using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrainSimulator
{
    public abstract class AbstractRailFactory
    {
        protected ObjectPool railPool;
        protected ObjectPool stationPool;

        public AbstractRailFactory(ObjectPool rails, ObjectPool stations)
        {
            railPool = rails;
            stationPool = stations;
        }

        public abstract RailWay CreateRailWay(Tile tile);
    }

    public class RailTrackFactory : AbstractRailFactory
    {
        public RailTrackFactory(ObjectPool rails, ObjectPool stations) : base(rails, stations)
        {
            
        }

        public override RailWay CreateRailWay(Tile tile)
        {
            if (tile.isStation) {
                RailWay station = stationPool.RealeseObject().GetComponent<RailWay>();
                station.SetPosition(tile.position);
                station.SetSprite(TypeRailWay.Station);
                return station;
            }
            else {
                RailWay rail = railPool.RealeseObject().GetComponent<RailWay>();
                TypeRailWay railType = ChooseSpriteByLinks(tile.links);
                int railDegree = GetRotateDegreeByLinks(tile.links, railType);
                rail.SetPosition(tile.position);
                rail.SetRotate(railDegree);
                rail.SetSprite(railType);
                return rail;
            }
        }

        TypeRailWay ChooseSpriteByLinks(List<SidesLink> links)
        {
            if (links.Count == 1) {
                if (FindEndUp(links)) {
                    // одна связь, точки к самой себе
                    return TypeRailWay.Endup;
                }
                else if (CalculateLink(links[0]) % 2 == 1) {
                    //одна связь, сумма индексов сторон нечётная
                    return TypeRailWay.Curve;
                }
                else if (CalculateLink(links[0]) % 2 == 0) {
                    if ((int)links[0].begin % 2 == 1 && (int)links[0].end % 2 == 1) {
                        //одна связь, сумма индексов сторон чётная, сами индексы сторон чётные 
                        return TypeRailWay.Horizontal;
                    }
                    else if ((int)links[0].begin % 2 == 0 && (int)links[0].end % 2 == 0) {
                        //одна связь, сумма индексов сторон чётная, сами индексы сторон нечётные
                        return TypeRailWay.Vertical;
                    }
                }
                else {
                    Debug.Log("Error. In ONE link happend some trouble.");
                }
            }
            else if (links.Count == 2 && !FindEndUp(links)) {
                if (CalculateLink(links[0]) % 2 == 1 && CalculateLink(links[1]) % 2 == 1 && FindGeneralPoints(links) == 1) {
                    //две связи, сумма индексов сторон у связей нечётная, одна общая стороная у связей
                    return TypeRailWay.TwoCurve;
                }
                else if (CalculateLink(links[0]) % 2 != CalculateLink(links[1]) % 2 && FindGeneralPoints(links) == 1) {
                    //две связи, сумма индексов сторон у связей разная по чётности, одна общая стороная у связей
                    //определяем левосторонняя или правосторонняя эта связь, дабы облегчить себе жизнь на этапе выбора правильной ротации
                    TileSides generalSides = GetGeneralSide(links[0], links[1]);
                    TileSides righerSide = CalculateLink(links[0]) % 2 == 1 ? GetRighterSide(links[0]) : GetRighterSide(links[1]);
                    if (generalSides == righerSide)
                        return TypeRailWay.OneInOneLeft;
                    else
                        return TypeRailWay.OneInOneRight;
                }
                else if (CalculateLink(links[0]) % 2 == 0 && CalculateLink(links[1]) % 2 == 0 && FindGeneralPoints(links) == 0) {
                    //две связи, сумма индексов сторон у связей чётная, ни одной общей стороны у связей
                    return TypeRailWay.Cross;
                }
                else {
                    Debug.Log("Error. In TWO link happend some trouble.");
                }
            }
            else if (links.Count == 3 && !FindEndUp(links)) {
                if (FindGeneralPoints(links) == 3) {
                    //три связи, три общих точки у связей
                    return TypeRailWay.ThreeCurve;
                }
                else {
                    Debug.Log("Error. In THREE link happend some trouble.");
                }
            }
            else {
                Debug.Log("Error. Uncorrect links input count.");
            }
            return TypeRailWay.None;
        }

        int CalculateLink(SidesLink link)
        {
            return (int)link.begin + (int)link.end;
        }

        int FindGeneralPoints(List<SidesLink> links)
        {
            int val = 0;
            for (int i = 0; i < links.Count; i++) {
                TileSides side = links[0].begin;
                for (int j = i + 1; j < links.Count; j++) {
                    if (side == links[j].begin) val++;
                    if (side == links[j].end) val++;
                }
                side = links[0].end;
                for (int j = i + 1; j < links.Count; j++) {
                    if (side == links[j].begin) val++;
                    if (side == links[j].end) val++;
                }
            }
            return val;
        }

        bool FindEndUp(List<SidesLink> links)
        {
            for (int i = 0; i < links.Count; i++) {
                if (links[i].begin == links[i].end) return true;
            }
            return false;
        }



        int GetRotateDegreeByLinks(List<SidesLink> links, TypeRailWay type)
        {
            int degree = 0;
            int offsetDegree = 90;
            TileSides generalSide;
            switch (type) {
                case TypeRailWay.Horizontal:
                case TypeRailWay.Vertical:
                case TypeRailWay.Cross:
                    break;
                case TypeRailWay.Curve:                                         // init state = left
                    TileSides righterSide = GetRighterSide(links[0]);
                    degree = ChooseDegreeByInitSide(TileSides.Left, righterSide);
                    break;
                case TypeRailWay.TwoCurve:                                      // init state = bottom
                    generalSide = GetGeneralSide(links[0], links[1]);
                    degree = ChooseDegreeByInitSide(TileSides.Bottom, generalSide);
                    break;
                case TypeRailWay.Endup:                                         // init state = bottom
                    degree = ChooseDegreeByInitSide(TileSides.Bottom, links[0].begin);
                    break;
                case TypeRailWay.OneInOneRight:                                 // init state = top
                case TypeRailWay.OneInOneLeft:
                    generalSide = GetGeneralSide(links[0], links[1]);
                    degree = ChooseDegreeByInitSide(TileSides.Top, generalSide);
                    break;
                case TypeRailWay.ThreeCurve:                                    // init state = left
                    TileSides emptySides = GetEmptySide(links);
                    degree = ChooseDegreeByInitSide(TileSides.Left, emptySides);
                    break;
            }
            return degree * offsetDegree;
        }

        int ChooseDegreeByInitSide(TileSides initSide, TileSides currentSides)
        {
            int sideIndex = (int)initSide;
            if (currentSides == (TileSides)((sideIndex + 1) & 3))
                return 1;
            else if (currentSides == (TileSides)((sideIndex + 2) & 3))
                return 2;
            else if (currentSides == (TileSides)((sideIndex + 3) & 3))
                return 3;
            else
                return 0;
        }

        TileSides GetGeneralSide(SidesLink one, SidesLink two)
        {
            if (one.begin == two.begin || one.begin == two.end)
                return one.begin;
            else if (one.end == two.begin || one.end == two.end)
                return one.end;
            return TileSides.None;
        }

        TileSides GetEmptySide(List<SidesLink> links)
        {
            for(int i = 0; i < 4; i++) {
                TileSides side = (TileSides)i;
                int count = 0;
                for (int j = 0; j < links.Count; j++) {
                    if (side == links[j].begin || side == links[j].end) {
                        count++;
                        break;
                    }
                }
                if (count == 0)
                    return side;
            }
            return TileSides.None;
        }

        TileSides GetRighterSide(SidesLink link)
        {
            int begin = (int)link.begin;
            int end = (int)link.end;
            if (((begin + 1) & 3) == end)
                return link.end;
            else
                return link.begin;
        }
    }
}
