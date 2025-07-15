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

        [TestMethod]
        public async Task CreateEvaluation_ShouldReturnSuccess()
        {
            var action = new EvaluationsActions(InvocationContext, FileManager);
            var response = await action.CreateEvaluation(new Apps.ContentQuo.Models.Requests.CreateEvaluationRequest
            {
                Name= "[Blackbird] Sample eval 01",
                SrcLocale= "en-US",
                TgtLocale = "es-419",
                GroupID = "1691",
                WorkflowID= "1024",
                ProfileID= "8cf4ef61-3847-4fdb-876e-4e5e790353f7"
            });
            var json = System.Text.Json.JsonSerializer.Serialize(response);
            Console.WriteLine(json);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task UploadBilingualFile_ShouldReturnSuccess()
        {
            var action = new BilingualFilesActions(InvocationContext, FileManager);
            var response = await action.UploadFile(new Apps.ContentQuo.Models.Requests.GetEvaluationRequest
            {
                Id= "39139"
            }, new Apps.ContentQuo.Models.Requests.UploadFileRequest
            {
                File=new Blackbird.Applications.Sdk.Common.Files.FileReference { Name= "sample_xliff_enus-esla.xliff" }
            });
            var json = System.Text.Json.JsonSerializer.Serialize(response);
            Console.WriteLine(json);

            Assert.IsNotNull(response);
        }
    }
}
