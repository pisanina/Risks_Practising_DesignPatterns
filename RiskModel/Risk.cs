namespace RiskModel
{
    public class Risk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Resource Owner { get; set; }
        public RiskStatus Status { get; set; }
        public int RiskScore { get; set; }
    }

    public enum RiskStatus
    {
        Unapproved,
        Approved,
        Open,
        Closed,
        Mitigated
    }
}