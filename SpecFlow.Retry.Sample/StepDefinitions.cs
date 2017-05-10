using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlow.Retry.Sample
{
    [Binding]
    public class StepDefinitions
    {
        [Given(@"""(.*)"" failed in exam")]
        public void GivenFailedInExam(string name)
        {
            Random rnd = new Random();
            int n = rnd.Next(1, 9);
            Assert.IsTrue(n % 2 == 0, string.Format("{0} falied in exam.. LOL :D :D :D ", name));
        }

    }
}
