using System;
using System.Collections.Generic;
using System.Text;

namespace RiskModel.Command
{
    public interface ICommand
    {
        IEnumerable<Risk> Execute(IEnumerable<Risk> risks);
    }
}
