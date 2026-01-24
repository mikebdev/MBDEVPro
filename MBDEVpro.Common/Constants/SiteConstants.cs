
namespace MBDEVpro.Common.Constants
{


    [Serializable]
    public class SiteConstants
    {
        public const string SiteName = "MBDEVpro";
        public const string SiteUrl = "https://www.mbdevpro.com";
        public const string SupportEmail = "";
    }

    [Serializable]
    public class RegularExpressionConstants
    {
        public const string Phone = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string Url = @"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?";
    }


}
