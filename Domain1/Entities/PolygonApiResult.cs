namespace Domain.Entities
{
    public class PolygonApiResult : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double O { get; set; } // Open
        public double H { get; set; } // High
        public double L { get; set; } // Low
        public double C { get; set; } // Close
        public long V { get; set; } // Volume
    }

}
