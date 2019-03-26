using System.Collections.Generic;
using System.Linq;

namespace RiskModel.Decorator
{
    public class ByOwnerNameDecorator : IDecoratorSolution
    {
        private IDecoratorSolution _risks;
        private string ownerName;

        public ByOwnerNameDecorator(IDecoratorSolution risks, string name)
        {
            this._risks = risks;
            ownerName = name;
        }

        public IEnumerable<Risk> GetRisks()
        {
            return _risks.GetRisks().Where(x => x.Owner.Name.ToLower() == ownerName.ToLower());
        }
    }
}