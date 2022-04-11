using ASP.NET_Core_EduHome.Data;
using ASP.NET_Core_EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EduHome.Services
{
    public class LayoutService
    {
      
        
            private readonly AppDbContext _context;

            public LayoutService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Setting> GetSettings()
            {
                Setting settings = await _context.Setting.FirstOrDefaultAsync();
                return settings;
            }

        public async Task<List<SocialNetwork>> GetSocial()
        {
            List<SocialNetwork> socialnetworks = await _context.SoicalNetworks.ToListAsync();
            return socialnetworks;
        }

    }
}
