using System.Collections.Generic;

namespace RiskModel.Decorator
{
    public class DecoratorSolutionBase : IDecoratorSolution
    {
        private RiskService service = new RiskService();

        public IEnumerable<Risk> GetRisks()
        {
            return service.GetRisks();
        }
    }
}