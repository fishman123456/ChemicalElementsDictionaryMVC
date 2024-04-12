using ChemicalElementsDictionaryMVC.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChemicalElementsDictionaryMVC.Pages.ChemicalElements
{
    public class ChemicalElementsFormModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ChemicalElement ChemicalElement { get; set; } = new();

        public ChemicalElementsFormModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _db.Chemicals.AddAsync(ChemicalElement);
            await _db.SaveChangesAsync();
            return RedirectToPage("ChemicalElementsList"); // перенаправление запроса на список элементов
        }
    }
}
