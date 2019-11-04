using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kalyani1.Controllers
{

    public class ProductController : Controller
    {
        [Authorize(Roles = "Administrator")]
        // GET: Product
        public ActionResult Index() //for the admin to checkout the list of products.
        {
            var allProducts = new DAL.CRUDProduct().GetProducts();

            return View(allProducts);
        }

        
        [ActionName ("ProductIndex")]
        public ActionResult CustomerIndex()
        {
            var allProducts = new DAL.CRUDProduct().GetProducts();
            var allprodoctindexModelList = new List<Models.ProductIndexModel>();
            foreach (var item in allProducts)
            {
                allprodoctindexModelList.Add(new Models.ProductIndexModel()
                {
                    Id = item.Id,
                    Image = item.Image,
                    Name = item.Name,
                    UnitPrice = item.UnitPrice
                });
            }
            return View(allprodoctindexModelList);
        }

        public ActionResult ProductIndexV3()
        {
            var allProducts = new DAL.CRUDProduct().GetProducts();

            return View(allProducts);
        }

        public ActionResult CustomerDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DAL.Product product, HttpPostedFileBase image1)
        {
            try
            {
                if (image1 != null)
                {
                    product.Image = new byte[image1.ContentLength];
                    image1.InputStream.Read(product.Image, 0, image1.ContentLength);
                }
                if (ModelState.IsValid)
                {
                    new DAL.CRUDProduct().AddProduct(product);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                // Log Exception somewhere
                // Redirect to the error page
            }
            // If we got this far, something failed, redisplay form
            return View(product); /*Yahaan product sirf isliye diya hai taaki agar create waala form load ho list ki jagah to usey dobara na bharna pade*/
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                using (var context = new DAL.KalyaniProdDbEntities())
                {
                    DAL.Product product = context.Products.Find(Id);
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        
    }
}