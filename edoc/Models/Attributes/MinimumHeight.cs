using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDocument.Models.Attributes
{
    public class MinimumHeight : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ShapeModel model = (ShapeModel)validationContext.ObjectInstance;
            if (model.Height == 0)
                return new ValidationResult("A shape requires a height.");
            else if ((model.ShapeTypeId == 1) && (model.Height <= 1))
                return new ValidationResult("A triangle's minimum height needs to be greater than 1.");
            else if ((model.ShapeTypeId == 2) && (model.Height <= 2))
                return new ValidationResult("A diamond's minimum height needs to be greater than 2.");
            else if ((model.ShapeTypeId == 3) && (model.Height <= 1))
                return new ValidationResult("A rectangle's minimum height needs to be greater than 1.");
            return null;
        }
    }
}