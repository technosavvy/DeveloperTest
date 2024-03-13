using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.Data;

public class RebateDataStore: IRebateDataStore
{
    public Rebate GetRebate(string rebateIdentifier)
    {
        // Access database to retrieve account, code removed for brevity 
        //return new Rebate();
        return GetGetRebateList().Where(pi => pi.Identifier == rebateIdentifier).ToList().FirstOrDefault();
    }

    public void StoreCalculationResult(Rebate account, decimal rebateAmount)
    {
        // Update account in database, code removed for brevity
    }

    private static List<Rebate> GetGetRebateList()
    {
        var RebateList = new List<Rebate>
        {
            new() { Identifier = "RebateIdentifier1", Amount = 10.0m, Incentive = IncentiveType.FixedRateRebate, Percentage = 2.0m },
            new() { Identifier = "RebateIdentifier2", Amount = 10.0m, Incentive = IncentiveType.FixedCashAmount, Percentage = 3.0m },
            new() { Identifier = "RebateIdentifier3", Amount = 10.0m, Incentive = IncentiveType.AmountPerUom, Percentage = 4.0m }
        };
        return RebateList;
    }
}
