using System.Collections.Generic;

namespace RiskModel.Command
{
    public class RiskProvider
    {
        private IEnumerable<Risk> ListOfRisks;

        public RiskProvider(IEnumerable<Risk> risks)
        {
            ListOfRisks = risks;
        }

        public void ExecCommand(ICommand command)
        {
            ListOfRisks = command.Execute(ListOfRisks);
        }

        public IEnumerable<Risk> GetResults()
        {
            return ListOfRisks;
        }
    }
}