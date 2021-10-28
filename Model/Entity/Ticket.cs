using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CustomerName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CarLicensePlate { get; set; }
        public Car Car { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }


    }
}
