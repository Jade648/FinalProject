using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class HomeController : Controller
{
    // this controller depends on the NorthwindRepository
    private DataContext _dataContext;
    public HomeController(DataContext db) => _dataContext = db;
    public ActionResult Index() => View(_dataContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now).Take(3));
    public IActionResult AddDiscount() => View();

    [HttpPost]

public IActionResult AddDiscount(Discount model){

{
    if (ModelState.IsValid)
    {
      if (_dataContext.Discounts.Any(d => d.Title == model.Title))
      {
        ModelState.AddModelError("", "Title must be unique");
      }
      else
      {
        _dataContext.AddDiscount(model);
        return RedirectToAction("Index");
      }
    }
    return View();
}
}
}


