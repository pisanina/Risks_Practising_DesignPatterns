using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RiskModel.Command
{
    public class ByDiffrentStatusCommand : ICommand
    {
        private RiskStatus statusOfRisk;

        public ByDiffrentStatusCommand(RiskStatus status)
        {
            statusOfRisk = status;
        }

        public IEnumerable<Risk> Execute(IEnumerable<Risk> risks)
        {
            return risks.Where(x => x.Status != statusOfRisk);
        }
    }
}
