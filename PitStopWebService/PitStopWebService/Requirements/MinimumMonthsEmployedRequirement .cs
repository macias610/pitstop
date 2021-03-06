﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PitStopWebService.Requirements
{
    public class MinimumMonthsEmployedRequirement : IAuthorizationRequirement
    {
        public int MinimumMonthsEmployed { get; private set; }

        public MinimumMonthsEmployedRequirement(int minimumMonths)
        {
            this.MinimumMonthsEmployed = minimumMonths;
        }
    }
}
