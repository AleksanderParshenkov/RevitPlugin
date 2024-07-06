using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace FilterNavis.Models
{
    public static class PluginMode
    {
        public static bool IsCheckLinkRevitModel { get; set; }
        public static bool IsCheckRegistr {  get; set; }
        public static bool IsCheckToFirstItem { get; set; }

        public static void GetIsCheckLinkRevitModel(bool  isCheckLinkRevitModel)
        {
            IsCheckLinkRevitModel = isCheckLinkRevitModel;
        }
    }
}
