using Apps.ContentQuo.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.ContentQuo.Base;

namespace Tests.ContentQuo
{
    [TestClass]
    public class EvaluationTests: TestBase
    {
        [TestMethod]
        public async Task GetEvaluation_ShouldReturnEvaluation()
        {
            var action = new EvaluationsActions(InvocationContext, FileManager);
            var response = await action.GetEvaluation(new Apps.ContentQuo.Models.Requests.GetEvaluationRequest
            {
                Id = ""
            });
            var json = System.Text.Json.JsonSerializer.Serialize(response);
            Console.WriteLine(json);

            Assert.IsNotNull(response);
        }
    }
}
