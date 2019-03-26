using System.Collections.Generic;

namespace RiskModel
{
    public class Search
    {
        public Search()
        {
            listOfRisks = service.GetRisks();
        }

        private RiskService service = new RiskService();
        private List<Risk> listOfRisks = new List<Risk>();

        public List<Risk> GetListOfRisksWithOwnerName(string ownerName)
        {
            return listOfRisks.FindAll(x => x.Owner.Name.ToLower() == ownerName.ToLower());
        }

        public List<Risk> GetListOfRisksWithOwnerId(int ownerId)
        {
            return listOfRisks.FindAll(x => x.Owner.Id == ownerId);
        }

        public List<Risk> GetListOfRisksWithRiskId(int riskId)
        {
            return listOfRisks.FindAll(x => x.Id == riskId);
        }

        public List<Risk> GetListOfRisksWithStatus(RiskStatus status)
        {
            return listOfRisks.FindAll(x => x.Status == status);
        }

        public List<Risk> GetListOfRisksWithDifferentStatus(RiskStatus status)
        {
            return listOfRisks.FindAll(x => x.Status != status);
        }

        public List<Risk> GetListOfRisksWithTitleContains(string title)
        {
            return listOfRisks.FindAll(x => x.Title.ToLower().Contains(title.ToLower(), System.StringComparison.InvariantCultureIgnoreCase));
        }

        public List<Risk> GetListOfRisksWithRiskScore(int riskScore)
        {
            return listOfRisks.FindAll(x => x.RiskScore == riskScore);
        }
    }
}