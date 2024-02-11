namespace WCFPresentation
{
    public class MarketData
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public long Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public double VolumeWeighted { get; set; }
        public double Number { get; set; }

    }
}
