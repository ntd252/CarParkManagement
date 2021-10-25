using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class ParkingLot
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Area { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
    }
}
