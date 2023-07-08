using BookShop_Razor.Data;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category categoriess { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                categoriess = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(categoriess.Id);
            if (obj == null)
            {
                return NotFound();
            }
             _db.Categories.Remove(obj);

             _db.SaveChanges();

             return RedirectToPage("Index");
            
        }
    }
}
