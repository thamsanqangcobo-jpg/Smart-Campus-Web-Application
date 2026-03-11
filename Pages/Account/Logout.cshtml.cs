using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

[Authorize]
public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnPost()
    {
        // Sign the user out
        await HttpContext.SignOutAsync();

        // Redirect to the home page
        return RedirectToPage("/Index");
    }
}

