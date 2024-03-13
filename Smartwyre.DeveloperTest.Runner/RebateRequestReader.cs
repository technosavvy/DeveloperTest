using System;

namespace Smartwyre.DeveloperTest.Types.Readers;

public sealed class RebateRequestReader 
{
    public CalculateRebateRequest Request { get; private set; }

    public RebateRequestReader Read()
    {

        var RebateIdentifier = ReadLine("Rebate Identifier");
        var ProductIdentifier = ReadLine("Product Identifier");
        var volume = ReadDecimal("Volume");

        Request = new CalculateRebateRequest()
        {
            ProductIdentifier = ProductIdentifier,
            RebateIdentifier = RebateIdentifier,
            Volume = volume
        };

        return this;
    }

    private static string ReadLine(string name)
    {
        Console.WriteLine($"Please enter {name}:");

        var value = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine($"Please enter {name}, the {name} cannot be empty");

            value = Console.ReadLine();
        }

        return value.Trim();
    }

    private static decimal ReadDecimal(string name)
    {
        var value = ReadLine(name);
        
        if (decimal.TryParse(value, out decimal result))
        {
            return result;
        }

        return 0;
    }
}