using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCAWTest
{
    public partial class ListBookingDTO
    {
        public long Bookingid { get; set; }
        public Booking Booking { get; set; }
    }
    public partial class Booking
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long Totalprice { get; set; }
        public bool Depositpaid { get; set; }
        public Bookingdates Bookingdates { get; set; }
        public string Additionalneeds { get; set; }
    }

    public partial class Bookingdates
    {
        public DateTimeOffset Checkin { get; set; }
        public DateTimeOffset Checkout { get; set; }
    }
}

