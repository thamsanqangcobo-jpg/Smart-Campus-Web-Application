using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public IncidentReport IncidentReport { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            IncidentReport = await _context.IncidentReports.FindAsync(id);
            if (IncidentReport == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(IncidentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Incident Report updated successfully.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentReportExists(IncidentReport.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SOSIndex");
        }

        private bool IncidentReportExists(int id)
        {
            return _context.IncidentReports.Any(e => e.Id == id);
        }
    }
}