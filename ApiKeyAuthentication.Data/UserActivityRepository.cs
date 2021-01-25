using ApiKeyAuthentication.Shared;
using ApiKeyMiddleware.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace ApiKeyAuthentication.Data
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly DatabaseHelper _db;

        public UserActivityRepository(string connectionString)
        {
            _db = new DatabaseHelper(connectionString);
        }

        public List<UserActivity> GetUserActivityForDatePeriod(DateTime startDate, DateTime endDate)
        {
            return _db.Query<UserActivity>("GetUserActivityForDatePeriod", new { StartDate = startDate, EndDate = endDate }, CommandType.StoredProcedure);
        }
    }
}
