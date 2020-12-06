using AutoMapper;
using System;

namespace Inventory.Common
{
    internal class DateConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
            => source.ToString("MM/dd/yyyy");
    }
}