using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RightWord.App.Extensions
{
    public class CultureHelper
    {
        public static Dictionary<string, string> CountryList()
        {
            Dictionary<string, string> cultureList = new Dictionary<string, string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures).OrderBy(x => x.EnglishName).ToArray();

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);
                
                if (!(cultureList.ContainsValue(getRegionInfo.DisplayName)))
                {
                    cultureList.Add(getRegionInfo.Name, getRegionInfo.DisplayName);
                }
            }

            return cultureList;
        }

        public static Dictionary<string, string> LanguageList()
        {
            Dictionary<string, string> cultureList = new Dictionary<string, string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures).OrderBy(x => x.EnglishName).ToArray();

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                cultureList.Add(getCulture.Name, getCulture.EnglishName);
            }

            return cultureList;
        }
    }
}
