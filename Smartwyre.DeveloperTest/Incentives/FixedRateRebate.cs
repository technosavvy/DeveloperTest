using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;

public sealed class FixedRateRebate : IIncentive
{
    public CalculateRebateResult Calculate(Product product, Rebate rebate, decimal volume)
    {
        var result = new CalculateRebateResult();
        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) || rebate.Percentage == 0 || product.Price == 0 || volume == 0)
        {
            result.Success = false;
            return result;
        }

        result.Success = true;
        result.rebateIncentive = product.Price * rebate.Percentage * volume;
        return result;
    }
}

