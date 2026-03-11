using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string FullName { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        public async Task OnGetAsync()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                RegistrationDate = user.DateCreated;
                IsActive = user.IsActive;
                FullName = user.FullName;
            }
        }
    }
}

