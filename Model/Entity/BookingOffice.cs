using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Entity
{
    public class BookingOffice
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string OfficeName { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Place { get; set; }

        public int Price { get; set; }
        public DateTime ContractStarts { get; set; }
        public DateTime ContractEnds { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

    }
}
