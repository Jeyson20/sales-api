using Sample.Application.Interfaces;
using System;

namespace Sample.Infraestructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
