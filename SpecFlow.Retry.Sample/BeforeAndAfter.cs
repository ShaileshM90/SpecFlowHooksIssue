using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlow.Retry.Sample
{
    [Binding]
    static class BeforeAndAfter
    {
        [AfterScenario()]
        static public void AfterScenarioExecution()
        {
            bool status = (ScenarioContext.Current.TestError != null) ? false : true;

            string ticketNumberWithExample = GetTicketNumber(ScenarioContext.Current.ScenarioInfo.Tags, ScenarioContext.Current["ScenarioExample"].ToString());

            if (!string.IsNullOrEmpty(ticketNumberWithExample))
            {
                if (!FeatureContext.Current.ContainsKey("ScenarioStatus"))
                {
                    FeatureContext.Current["ScenarioStatus"] = new Dictionary<string, List<bool>>() { { ticketNumberWithExample, new List<bool>() { status } } };
                }
                else
                {
                    Dictionary<string, List<bool>> currentScenarioStatus = (Dictionary<string, List<bool>>)FeatureContext.Current["ScenarioStatus"];
                    if (currentScenarioStatus.ContainsKey(ticketNumberWithExample))
                    {
                        List<bool> currentItem = currentScenarioStatus[ticketNumberWithExample];
                        currentItem.Add(status);
                        currentScenarioStatus[ticketNumberWithExample] = currentItem;
                    }
                    else
                    {
                        currentScenarioStatus.Add(ticketNumberWithExample, new List<bool>() { status });
                    }
                    FeatureContext.Current["ScenarioStatus"] = currentScenarioStatus;
                }
            }
        }

        [AfterFeature()]
        static public void AfterFeatureExecution()
        {
            if (FeatureContext.Current.ContainsKey("ScenarioStatus"))
            {
                Dictionary<string, List<bool>> ScenarioStatus = (Dictionary<string, List<bool>>)FeatureContext.Current["ScenarioStatus"];
                foreach (var item in ScenarioStatus)
                {
                    foreach (var value in item.Value)
                    {
                        Console.WriteLine(string.Format("{0} ===>>> {1}", item.Key, value));
                    }
                }
            }
        }

        static public string GetTicketNumber(string[] scenarioTags, string name = "")
        {
            if (scenarioTags.Any())
            {
                if (!scenarioTags.Contains("Ignored"))
                {
                    if (scenarioTags.Where(x => x.Contains("HA")).Any())
                    {
                        if (!string.IsNullOrEmpty(name))
                        {
                            return string.Format("{0} - {1}", scenarioTags.Where(x => x.Contains("HA")).First(), name);
                        }
                        return string.Format("{0}", scenarioTags.Where(x => x.Contains("HA")).First());
                    }
                }
            }
            return string.Empty;
        }
    }
}
