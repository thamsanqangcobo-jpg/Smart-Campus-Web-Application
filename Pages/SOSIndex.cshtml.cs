using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmartCampusPortal.Data;
using SmartCampusPortal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartCampusPortal.Pages
{
    public class SOSIndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SOSIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IncidentReport NewIncident { get; set; }

        public List<IncidentReport> IncidentReports { get; set; }

        public async Task OnGetAsync()
        {
            // Fetches recent reports to display
            IncidentReports = await _context.IncidentReports.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    IncidentReports = await _context.IncidentReports.ToListAsync();
                    return Page();
                }

                NewIncident.ReportDate = DateTime.Now;

                _context.IncidentReports.Add(NewIncident);
                await _context.SaveChangesAsync();

                // Set a success message in TempData
                TempData["SuccessMessage"] = "Report submitted successfully!";

                NewIncident = new IncidentReport();

                IncidentReports = await _context.IncidentReports.ToListAsync();

                return RedirectToPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
                IncidentReports = await _context.IncidentReports.ToListAsync();
                return Page();
            }
        }
    }
}

