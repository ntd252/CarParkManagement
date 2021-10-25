using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class Trip
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public string CarType { get; set; }
        public int BookedTicketNumber { get; set; }
        public int MaxTicketNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }

    }
}
