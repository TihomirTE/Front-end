namespace Academy
{
    public interface IConfigurationProvider
    {
        bool IsTestEnvironment { get; }
    }
}
