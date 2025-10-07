using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_ADO.Models;

namespace MVC_CRUD_ADO.Controllers
{
    public class ProductController : Controller
    {
        IproductRespo Ipr;
       public ProductController(IproductRespo Ipr)
        {
            this.Ipr = Ipr;
        }
        public IActionResult Index()
        {
           List<Product> p = Ipr.GetAll();   

            return View(p);
        }

        public IActionResult Update()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            

                Ipr.Update(p);
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Ipr.DeleteProductById(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Add(Product p)
        {
           
             Ipr.Add(p);
            
            return RedirectToAction("Index");
        }

        public IActionResult GetProductById()
        {
            return View();
        }
        [HttpPost]
        //[Route("Product/GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            Product p =Ipr.GetProductById(id);
         

        return Content($"Id : {p.Id} Item Name {p.Name} Item price {p.Price} , Category : {p.Category}");

            
            //return View(p);
        }
      


    }
}
