using ApiKeyAuthentication.Data;
using ApiKeyAuthentication.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ApiKeyAuthentication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;
        private readonly IUserActivityRepository _userActivityRepository;

        public UserActivityController(ILogger<UserActivityController> logger,
            IUserActivityRepository userActivityRepository)
        {
            _logger = logger;
            _userActivityRepository = userActivityRepository;
        }

        [HttpGet]
        public IEnumerable<UserActivity> Get()
        {
            //return the last seven days of the activity
            var endDate = DateTime.Now;
            var startDate = endDate.AddDays(-7);

            return _userActivityRepository.GetUserActivityForDatePeriod(startDate, endDate);
        }
    }
}
