using ChemicalElementsDictionaryMVC.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChemicalElementsDictionaryMVC.Pages.ChemicalElements
{
    public class ChemicalElementsListModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<ChemicalElement> ChemicalElements { get; private set; } = new();
        public ChemicalElementsListModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            ChemicalElements = _db.Chemicals.ToList();
        }

        //public async Task OnGetAsync()
        //{
        //    ChemicalElements = await _db.Chemicals.ToListAsync();
        //}
    }
}
