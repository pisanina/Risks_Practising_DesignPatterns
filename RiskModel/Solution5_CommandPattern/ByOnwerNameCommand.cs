using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RiskModel.Command
{
    public class ByOnwerNameCommand : ICommand
    {
        private string ownerName;

        public ByOnwerNameCommand(string ownerN)
        {
            ownerName = ownerN;
        }
        public IEnumerable<Risk> Execute(IEnumerable<Risk> risks)
        {
            return risks.Where(x => x.Owner.Name.ToLower() == ownerName.ToLower());
        }
    }
}
