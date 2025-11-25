using System;
using Phoebe;

namespace Phoebe.Tests;

public class TestBase
{
    protected IPhoebeClient client;

    public TestBase()
    {
        client = new PhoebeClient()
        {
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
