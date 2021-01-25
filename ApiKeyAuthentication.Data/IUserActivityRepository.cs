using ApiKeyAuthentication.Shared;
using System;
using System.Collections.Generic;

namespace ApiKeyAuthentication.Data
{
    public interface IUserActivityRepository
    {
        List<UserActivity> GetUserActivityForDatePeriod(DateTime startDate, DateTime endDate);
    }
}