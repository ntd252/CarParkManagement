using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    public class Trip
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Destination { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Driver { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CarType { get; set; }

        public int BookedTicketNumber { get; set; }
        public int MaxTicketNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }

        public List<BookingOffice> BookingOffices { get; set; }

    }
}
