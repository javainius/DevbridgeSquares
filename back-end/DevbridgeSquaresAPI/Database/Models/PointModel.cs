using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    [Table("Points")]
    public class PointModel
    {
        public int Id { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
