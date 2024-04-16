using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.ContentQuo;

public class ContentQuoApplication : IApplication, ICategoryProvider
{

    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.QualityManagement];
        set { }
    }
    
    public ContentQuoApplication()
    {
    }

    public string Name
    {
        get => "ContentQuo";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}