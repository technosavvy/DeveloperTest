using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;

public interface IIncentive
{
    CalculateRebateResult Calculate(Product product, Rebate rebate, decimal volume);
}
