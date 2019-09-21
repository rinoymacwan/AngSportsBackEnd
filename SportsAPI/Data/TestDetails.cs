using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAPI.Data
{
    public class TestDetails
    {
        public Test CurrentTest { get; set; }
        public List<UserTestMapping> CurrentUserTestMapping { get; set; }

        public TestDetails(Test test, List<UserTestMapping> details)
        {
            this.CurrentTest = test;
            this.CurrentUserTestMapping = details;
        }
    }
}
