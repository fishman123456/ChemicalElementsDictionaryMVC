using ChemicalElementsDictionaryMVC.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChemicalElementsDictionaryMVC.Pages.ChemicalElements
{
    public class ChemicalElementDeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ChemicalElementDeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task <IActionResult> OnGetAsync(int id)
        {
            ChemicalElement? removeble = await _db.Chemicals.FirstOrDefaultAsync(c => c.Id == id);
            if(removeble != null)
            {
                _db.Chemicals.Remove(removeble);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage("ChemicalElementsList");
        }
    }
}
