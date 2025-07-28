using System.Reflection;
using RevitDev.Common.Providers;

namespace RevitDev.Tests;

public class JsonProviderFixture : IClassFixture<JsonProvider>
{
    [Fact]
    public void CreateDictionaryFromFile()
    {
        var provider = new JsonProvider();
        var assembly = Assembly.GetExecutingAssembly();
        var jsonName = "create-dictionary-from-file.json";
        var expected = new Dictionary<int, string>()
        {
            { 100, "one hundred" },
            { 200, "two hundred" }
        };
        var result = provider.GetDictionaryFromResourceJson<int, string>(assembly, jsonName);
        Assert.NotNull(result);
        Assert.Equal(expected, result);
    }
}