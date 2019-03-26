using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RiskModel.Command
{
    public class ByTitleCommand : ICommand
    {

        private string titleOfRisk;

        public ByTitleCommand(string title)
        {
           titleOfRisk = title.ToLower();
        }
        public IEnumerable<Risk> Execute(IEnumerable<Risk> risks)
        {
            return risks.Where(x => x.Title.ToLower().Contains(titleOfRisk));
        }
    }
}

