using ChemicalElementsDictionaryMVC.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChemicalElementsDictionaryMVC.Pages.ChemicalElements
{
    public class ChemicalElementEditFormModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]

        public ChemicalElement ChemicalElement { get; set; } = new();

        public ChemicalElementEditFormModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ChemicalElement? chemnicalElement = await _db.Chemicals.FirstOrDefaultAsync(c => c.Id == id);
            if (chemnicalElement == null)
            {
                return NotFound();
            }
            ChemicalElement = chemnicalElement;
           return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ChemicalElement? update = await _db.Chemicals.FirstOrDefaultAsync(c => c.Id == ChemicalElement.Id);
            if(update == null)
            {
                return NotFound();
            }
            update.FullName=ChemicalElement.FullName;
            update.Code=ChemicalElement.Code;
            update.Mass=ChemicalElement.Mass;
            await _db.SaveChangesAsync();
            return RedirectToPage("ChemicalElementsList");
        }
    }
}
