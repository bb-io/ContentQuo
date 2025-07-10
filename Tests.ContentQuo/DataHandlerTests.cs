using Apps.ContentQuo.DataSourceHandler;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Tests.ContentQuo.Base;

namespace Tests.ContentQuo;

[TestClass]
public class DataHandlerTests : TestBase
{
    [TestMethod]
    public async Task EvaluationDataHandler_IssSuccess()
    {
        var handler = new EvaluationDataHandler(InvocationContext);

        var response = await handler.GetDataAsync(new DataSourceContext
        {
            SearchString = ""
        }, CancellationToken.None);

        var json = System.Text.Json.JsonSerializer.Serialize(response);
        Console.WriteLine(json);
        Assert.IsNotNull(response);
    }
}
