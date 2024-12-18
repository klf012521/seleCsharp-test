﻿using PracticeAutomation.Models.API.Response;
using CynkyUtilities;
using PracticeAutomation.Models.API.Request;

namespace PracticeAutomation.JsonBuilder.BookingService
{
    public class BookingJsonBuilder
    {
        public static CreateBookingRequest GetCreateBookingData()
        {
            return new CreateBookingRequest
            {
                firstname = StringGenerator.GetRandomString(),
                lastname = StringGenerator.GetRandomString(),
                totalprice = StringGenerator.GetRandomNumberBetween(1, 1000),
                depositpaid = true,
                bookingdates = new Bookingdates
                {
                    checkin = DateTimeGenerator.GetRandomDate(DateTimeGenerator.GetTodaysDateTime().Year, DateTimeGenerator.GetTodaysDateTime().AddYears(1).Year),
                    checkout = DateTimeGenerator.GetRandomDate(DateTimeGenerator.GetTodaysDateTime().Year, DateTimeGenerator.GetTodaysDateTime().AddYears(1).Year),
                },
                additionalneeds = StringGenerator.GetRandomString()
            };
        }
    }
}
