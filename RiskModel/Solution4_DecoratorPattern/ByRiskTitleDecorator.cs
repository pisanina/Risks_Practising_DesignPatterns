using System.Collections.Generic;
using System.Linq;

namespace RiskModel.Decorator
{
    public class ByRiskTitleDecorator : IDecoratorSolution
    {
        private IDecoratorSolution _risks;
        private string titleToFind;

        public ByRiskTitleDecorator(IDecoratorSolution risks, string title)
        {
            this._risks = risks;
            this.titleToFind = title;
        }

        public IEnumerable<Risk> GetRisks()
        {
            return _risks.GetRisks().Where(x => x.Title.ToLower().Contains(titleToFind.ToLower()));
        }
    }
}
