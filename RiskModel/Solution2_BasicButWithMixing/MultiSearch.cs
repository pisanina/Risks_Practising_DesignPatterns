using System.Collections.Generic;

namespace RiskModel
{
    public class MultiSearch
    {
        public MultiSearch()
        {
            listOfRisks = service.GetRisks();
        }

        private RiskService service = new RiskService();
        private List<Risk> listOfRisks = new List<Risk>();

        public List<Risk> GetListOfRisksByOwnerStatusTitle(string ownerName = null, RiskStatus? status = null, string title = null)
        {
            if (ownerName != null)
            {
                listOfRisks = listOfRisks.FindAll(x => x.Owner.Name.ToLower() == ownerName.ToLower());
            }

            if (status != null)
            {
                listOfRisks = listOfRisks.FindAll(x => x.Status != status);
            }

            if (title != null)
            {
                listOfRisks = listOfRisks.FindAll(x => x.Title.Contains(title, System.StringComparison.InvariantCultureIgnoreCase));
            }
            return listOfRisks;
        }
    }
}