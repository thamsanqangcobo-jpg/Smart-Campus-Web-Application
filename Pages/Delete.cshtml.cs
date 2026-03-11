using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IncidentReport IncidentReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IncidentReport = await _context.IncidentReports.FindAsync(id);

            if (IncidentReport == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (IncidentReport == null)
            {
                return NotFound();
            }

            _context.IncidentReports.Remove(IncidentReport);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Incident report deleted successfully."; 
            return RedirectToPage("./SOSIndex");
        }
    }
}
