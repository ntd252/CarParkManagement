using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        public string LicensePlate { get; set; }


    }
}
