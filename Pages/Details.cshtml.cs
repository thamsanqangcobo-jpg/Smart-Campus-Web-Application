using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages.SOS
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IncidentReport IncidentReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IncidentReport = await _context.IncidentReports.FirstOrDefaultAsync(m => m.Id == id);

            if (IncidentReport == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
