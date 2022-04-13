using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Helpers
{
    public static class Helper
    {
        public static string GetPath(string root, string folder, string filename)
        {
            return Path.Combine(root, folder, filename);
        }
    }
}
