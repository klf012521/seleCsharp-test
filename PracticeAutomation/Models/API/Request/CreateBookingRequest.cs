﻿using PracticeAutomation.Models.API.Response;

namespace PracticeAutomation.Models.API.Request
{
    public class CreateBookingRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public Bookingdates bookingdates { get; set; }
        public string additionalneeds { get; set; }
    }
}
