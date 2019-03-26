using System.Collections.Generic;
using System.Linq;

namespace RiskModel.Decorator
{
    public class DiffrentStatesOfRiskDecorator : IDecoratorSolution
    {
        private IDecoratorSolution _risks;
        private RiskStatus _notStatus = new RiskStatus();

        public DiffrentStatesOfRiskDecorator(IDecoratorSolution risks, RiskStatus status)
        {
            this._risks = risks;
            _notStatus = status;
        }

        public IEnumerable<Risk> GetRisks()
        {
            return _risks.GetRisks().Where(x => x.Status != _notStatus);
        }
    }
}