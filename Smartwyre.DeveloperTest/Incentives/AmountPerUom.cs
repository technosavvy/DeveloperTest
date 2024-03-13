using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;

public sealed class AmountPerUom : IIncentive
{
    public CalculateRebateResult Calculate(Product product, Rebate rebate, decimal volume)
    {
        var result = new CalculateRebateResult();
        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) || rebate.Amount == 0 || volume == 0)
        {
            result.Success = false;
            return result;
        }

        result.Success = true;
        result.rebateIncentive = rebate.Amount * volume;
        return result;
    }
}

