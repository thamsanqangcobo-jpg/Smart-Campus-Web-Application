using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages.Sos
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IncidentReport IncidentReport { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (IncidentReport.ReportDate == DateTime.MinValue)
            {
                IncidentReport.ReportDate = DateTime.Now;
            }

            _context.IncidentReports.Add(IncidentReport);
            await _context.SaveChangesAsync();
            return RedirectToPage("/SOSIndex");
        }
    }
}
