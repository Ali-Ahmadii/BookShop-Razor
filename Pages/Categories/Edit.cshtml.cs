using BookShop_Razor.Data;
using BookShop_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category categories { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id != null){
                categories = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //
                _db.Categories.Update(categories);

                _db.SaveChanges();

                //TempData["success"] = "Contact Updated Successfuly";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
