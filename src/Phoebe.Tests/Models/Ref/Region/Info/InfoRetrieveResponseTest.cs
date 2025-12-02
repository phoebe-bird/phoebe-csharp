using Phoebe.Models.Ref.Region.Info;

namespace Phoebe.Tests.Models.Ref.Region.Info;

public class InfoRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InfoRetrieveResponse
        {
            Bounds = new()
            {
                MaxX = -75.764,
                MaxY = 42.896,
                MinX = -75.764,
                MinY = 42.896,
            },
            Result = "Madison, New York, United States",
        };

        Bounds expectedBounds = new()
        {
            MaxX = -75.764,
            MaxY = 42.896,
            MinX = -75.764,
            MinY = 42.896,
        };
        string expectedResult = "Madison, New York, United States";

        Assert.Equal(expectedBounds, model.Bounds);
        Assert.Equal(expectedResult, model.Result);
    }
}

public class BoundsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Bounds
        {
            MaxX = -75.764,
            MaxY = 42.896,
            MinX = -75.764,
            MinY = 42.896,
        };

        float expectedMaxX = -75.764;
        float expectedMaxY = 42.896;
        float expectedMinX = -75.764;
        float expectedMinY = 42.896;

        Assert.Equal(expectedMaxX, model.MaxX);
        Assert.Equal(expectedMaxY, model.MaxY);
        Assert.Equal(expectedMinX, model.MinX);
        Assert.Equal(expectedMinY, model.MinY);
    }
}
