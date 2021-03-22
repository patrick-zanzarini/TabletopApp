using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace TabletopRpg.Framework
{
    public class ApplicationConfiguration
    {
        public RequestCulture DefaultCulture { get; set; }
        public CultureInfo[] SupportedCulture { get; set; }
    }
}