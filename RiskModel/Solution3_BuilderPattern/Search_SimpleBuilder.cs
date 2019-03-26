using System.Collections.Generic;

namespace RiskModel
{
    public class Search_SimpleBuilder
    {
        public Search_SimpleBuilder(List<Risk> risks)
        {
            listOfRisks = risks;
        }

        private List<Risk> listOfRisks = new List<Risk>();

        public void GetListOfRisksWithOwnerName(string ownerName)
        {
            listOfRisks = listOfRisks.FindAll(x => x.Owner.Name.ToLower() == ownerName.ToLower());
        }

        public void GetListOfRisksWithDifferentStatus(RiskStatus status)
        {
            listOfRisks = listOfRisks.FindAll(x => x.Status != status);
        }

        public void GetListOfRisksWithTitleContains(string title)
        {
            listOfRisks = listOfRisks.FindAll(x => x.Title.ToLower().Contains(title.ToLower()));
        }

        public List<Risk> Builded_Search()
        {
            return listOfRisks;
        }
    }
}