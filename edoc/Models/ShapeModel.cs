using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using EDocument.Models.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDocument.Models
{
    public class ShapeModel
    {
        public int Id { get; set; }
        public int ShapeTypeId { get; set; }
        [MinimumHeight()]
        [OddHeight(new int[] {2}, new string[] { "A diamond's height needs to be an odd number such as 3, 5 or 7." })]
        public int Height { get; set; }
        public string Label { get; set; }
        public int? LabelRow { get; set; }

        public ShapeModel()
        {
            ShapeTypeId = 1;
            Label = "Hi";
        }
    }

    public class ShapeDBContext : DbContext
    {
        public DbSet<ShapeModel> Shapes { get; set; }
    }
}