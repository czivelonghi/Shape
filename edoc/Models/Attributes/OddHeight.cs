using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDocument.Models.Attributes
{
    public class OddHeight : ValidationAttribute
    {
        int[] ids = new int[] { };
        string[] messages = new string[] { };

        public OddHeight(int[] ids, string[] messages)
        {
            this.ids = ids;
            this.messages = messages;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ShapeModel model = (ShapeModel)validationContext.ObjectInstance;
            for (int i = 0; i < ids.Length; i++ )
                if (model.ShapeTypeId.Equals(ids[i]) && IsEven(model.Height))
                    return new ValidationResult(messages[i]);
            return null;
        }

        bool IsEven(int height)
        {
            return (height % 2 == 0);
        }
    }
}