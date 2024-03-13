using Smartwyre.DeveloperTest.Types;
using Smartwyre.DeveloperTest.Smartwyre.DeveloperTest.Incentive;
using Xunit;


public sealed class FixedRateRebateTest
{
    [Fact]
    public void FixedRateRebateShouldReturnFalseSuccessIfVolumeZero()
    {
        var product = GetProduct();
        var rebate = GetRebate();
        var volume = 0;

        var incentive = new FixedRateRebate();

        var result = incentive.Calculate(product, rebate, volume);

        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateRebateShouldReturnFalseSuccessIfPercentageZero()
    {
        var product = GetProduct();
        var rebate = new Rebate
        {
            Amount = 1000,
            Identifier = "ProductIdentifier1",
            Incentive = IncentiveType.FixedRateRebate,
            Percentage = 0
        };
        
        var volume = 10.0m;

        var incentive = new FixedRateRebate();

        var result = incentive.Calculate(product, rebate, volume);

        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateRebateShouldReturnFalseSuccessIfPriceZero()
    {
        var product = new Product
        {
            Id = 1,
            Identifier = "ProductIdentifier1",
            Price = 0,
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate
        };

        var rebate = GetRebate();
        var volume = 10.0m;

        var incentive = new FixedRateRebate();

        var result = incentive.Calculate(product, rebate, volume);

        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateRebateShouldReturnFalseSuccessIfIncentiveTypeIsNotFixedRateRebate()
    {
        var product = new Product
        {
            Id = 1,
            Identifier = "ProductIdentifier1",
            Price = 0,
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };

        var rebate = GetRebate();
        var volume = 10.0m;

        var incentive = new FixedRateRebate();

        var result = incentive.Calculate(product, rebate, volume);

        Assert.False(result.Success);
    }

    [Fact]
    public void FixedRateRebateShouldSuccessTest()
    {
        var product = GetProduct();
        var rebate = GetRebate();
        var volume = 10.0m;
        var expectedRebate = product.Price * rebate.Percentage * volume;
        var incentive = new FixedRateRebate();

        var result = incentive.Calculate(product, rebate, volume);

        Assert.True(result.Success);
        Assert.Equal(expectedRebate, result.rebateIncentive);
    }


    private static Product GetProduct() => new()
    {
        Identifier = "ProductIdentifier1",
        Id = 1,        
        Price = 200.0m,
        SupportedIncentives = SupportedIncentiveType.FixedRateRebate,        
    };

    private static Rebate GetRebate() => new()
    {
        Identifier = "RebateIdentifier1",
        Amount = 100,
        Percentage = 1.5m,
        Incentive = IncentiveType.FixedRateRebate,
    };
}

