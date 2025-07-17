using Apps.ContentQuo.Models.Requests;
using Apps.ContentQuo.Polling;
using Apps.ContentQuo.Polling.Models.Memory;
using Blackbird.Applications.Sdk.Common.Polling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.ContentQuo.Base;

namespace Tests.ContentQuo
{
    [TestClass]
    public class PollingTests :TestBase
    {
        [TestMethod]
        public async Task OnEvaluationsFinished_IsSuccess()
        {

            var request = new PollingEventRequest<DateMemory>
            {
                Memory = new DateMemory
                {
                    LastInteractionDate = DateTime.UtcNow.AddDays(-1)
                }
            };
            var optionalRequest = new GetEvaluationOptionalRequest{ };
            var polling = new PollingList(InvocationContext);

            var response = await polling.OnEvaluationsCreated(request, optionalRequest);

            var json = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(json);

        }
    }
}
