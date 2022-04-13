using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Areas.AdminArea.Utilities.Extentions
{
    public static class Extention
    {
        public static bool CheckContentType(this IFormFile file , string type)
        {
            return file.ContentType.Contains(type);
        }
        public static bool CheckContentLength(this IFormFile file, long size)
        {
            return file.Length / 1024 < size;
        }
    }
}
