using System.Collections.Generic;

namespace RiskModel.Decorator
{
    public interface IDecoratorSolution
    {
        IEnumerable<Risk> GetRisks();
    }
}