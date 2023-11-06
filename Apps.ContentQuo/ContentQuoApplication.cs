using Blackbird.Applications.Sdk.Common;

namespace Apps.ContentQuo;

public class ContentQuoApplication : IApplication
{

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