using AutoMapper;
using System.Globalization;

namespace Inventory.Common
{
    public class CurrencyStringToDecimalFormatter : IValueConverter<string, decimal>
    {
        public decimal Convert(string sourceMember, ResolutionContext context)
        {
            return decimal.Parse(sourceMember.Replace("$", ""),
                            NumberStyles.AllowCurrencySymbol |
                            NumberStyles.AllowThousands |
                            NumberStyles.AllowDecimalPoint);
        }
    }
}