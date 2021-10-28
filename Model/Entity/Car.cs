using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    public class Car
    {
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string LicensePlate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Type { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Color { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Company { get; set; }

        public int ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }

    }
}
