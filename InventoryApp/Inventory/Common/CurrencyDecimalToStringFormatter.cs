using AutoMapper;
using System.Globalization;

namespace Inventory.Common
{
    public class CurrencyDecimalToStringFormatter : IValueConverter<decimal, string>
    {
        CultureInfo ci = new CultureInfo("en-us");
        public string Convert(decimal source, ResolutionContext context)
            => source.ToString("c", ci);
    }
}