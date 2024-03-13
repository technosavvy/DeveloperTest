using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;

public sealed class FixedCashAmount : IIncentive
{
    public CalculateRebateResult Calculate(Product product, Rebate rebate, decimal volume)
    {
        var result = new CalculateRebateResult();
        if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) || rebate.Amount == 0)
        {
            result.Success = false;
            return result;
        }

        result.Success = true;
        result.rebateIncentive = rebate.Amount;
        return result;
    }
}
