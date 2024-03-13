using System.Collections.Generic;
using Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;

namespace Smartwyre.DeveloperTest.Types;

public sealed class IncentiveDictionary
{
    private static readonly IDictionary<IncentiveType, IIncentive> incetive = new Dictionary<IncentiveType, IIncentive>()
    {
        { IncentiveType.AmountPerUom, new AmountPerUom() },
        { IncentiveType.FixedCashAmount, new FixedCashAmount() },
        { IncentiveType.FixedRateRebate, new FixedRateRebate() }
    };

    public static IIncentive Get(IncentiveType incentiveType)
    {
        return incetive[incentiveType];
    }
}