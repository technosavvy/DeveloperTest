using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Types;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services
{

    public class RebateService : IRebateService
    {
        private readonly IRebateDataStore rebateDataStore;
        private readonly IProductDataStore productDataStore;

        public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
        {
            this.rebateDataStore = rebateDataStore;
            this.productDataStore = productDataStore;
        }

        public CalculateRebateResult Calculate(CalculateRebateRequest request)
        {
            var rebate = rebateDataStore.GetRebate(request.RebateIdentifier);
            var product = productDataStore.GetProduct(request.ProductIdentifier);

            var result = new CalculateRebateResult();

            if (rebate == null || product == null)
            {
                result.Success = false;

                return result;
            }            

            var incentive = IncentiveDictionary.Get(rebate.Incentive);

            result = incentive.Calculate(product, rebate, request.Volume);

            if (result.Success)
            {
                rebateDataStore.StoreCalculationResult(rebate, result.rebateIncentive);
            }

            return result;
        }
    }  
}