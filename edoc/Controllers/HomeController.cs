using EDocument.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDocument.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShapeViewModel shapeViewModel = new ShapeViewModel() 
            {
                Shape = Last()
            };
            return View(shapeViewModel);
        }

        [HttpPost()]
        public ActionResult Save(ShapeViewModel viewModel)
        {
            ShapeModel shape = viewModel.Shape;
            if (ModelState.IsValid)
            { 
                ShapeModel newShape = new ShapeModel { ShapeTypeId = shape.ShapeTypeId, Height = shape.Height, Label = shape.Label, LabelRow = shape.LabelRow };
                Save(shape);
            }
            return View("Index", viewModel);
        }

        void Save(ShapeModel shape)
        {
            using (ShapeDBContext db = new ShapeDBContext())
            {
                db.Shapes.Add(shape);
                db.SaveChanges();
            }
        }

        ShapeModel Last()
        {
            ShapeModel shape = new ShapeModel {};
            using (ShapeDBContext db = new ShapeDBContext())
            {
                if (db.Shapes.Count() > 0)
                    shape = db.Shapes.ToList().Last<ShapeModel>();
            }
            return shape;
        }
    }
}