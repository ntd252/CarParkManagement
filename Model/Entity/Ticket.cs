using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }
        public string CustomerName { get; set; }

        public string LicensePlate { get; set; }
        public Trip Trip { get; set; }

    }
}
