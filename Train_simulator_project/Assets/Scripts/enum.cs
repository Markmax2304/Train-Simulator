

namespace TrainSimulator
{
    public enum TypeObjectPool { Rail, Station, Lokomotive, Carriage};

    public enum TypeTrain { Suburban, Express};
    public enum TypeCarriage { Lokomotive, Carriage};       // sprite types

    public enum TypeRailWay { Horizontal = 0, Vertical, Curve, Cross, Endup, TwoCurve, OneInOneRight, OneInOneLeft, ThreeCurve, Station, None};
    public enum TileSides { Top = 0, Right = 1, Bottom = 2, Left = 3, None = -1};
    
}
