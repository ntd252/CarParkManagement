using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entity
{
    public class BookingOffice
    {
        [Required]
        public int Id { get; set; }
        public string OfficeName { get; set; }
        public string Phone { get; set; }
        public Trip Trip { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public DateTime ContractStarts { get; set; }
        public DateTime ContractEnds { get; set; }

    }
}
