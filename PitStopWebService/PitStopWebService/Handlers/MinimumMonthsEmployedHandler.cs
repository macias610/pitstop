using Constans.Claims;
using Microsoft.AspNetCore.Authorization;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PitStopWebService.Requirements
{
    public class MinimumMonthsEmployedHandler
    : AuthorizationHandler<MinimumMonthsEmployedRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MinimumMonthsEmployedRequirement requirement)
        {
            var user = context.User;


            var employmentCommenced = user.FindFirst(claim => claim.Type == CustomClaimTypes.EmploymentCommenced).Value;

            var employmentStarted = Convert.ToDateTime(employmentCommenced);
            var today = LocalDateTime.FromDateTime(DateTime.Now);

            var monthsPassed = Period
                .Between(new LocalDateTime(employmentStarted.Year, employmentStarted.Month, employmentStarted.Day, employmentStarted.Hour, employmentStarted.Minute, employmentStarted.Second), today, PeriodUnits.Months)
                .Months;

            if (monthsPassed >= requirement.MinimumMonthsEmployed)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
