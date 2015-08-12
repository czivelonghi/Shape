using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDocument.Models
{
    public class ShapeViewModel
    {
        public ShapeModel Shape { get; set; }

        public IEnumerable<SelectListItem> Shapes
        {
            get 
            {
                yield return new SelectListItem() { Text = "Triangle", Value = "1" };
                yield return new SelectListItem() { Text = "Diamond", Value = "2" };
                yield return new SelectListItem() { Text = "Rectangle", Value = "3" };
                yield return new SelectListItem() { Text = "Box", Value = "4" }; 
            }
        }
    }
}