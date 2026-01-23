using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Region.Info;

[JsonConverter(typeof(JsonModelConverter<InfoRetrieveResponse, InfoRetrieveResponseFromRaw>))]
public sealed record class InfoRetrieveResponse : JsonModel
{
    public Bounds? Bounds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Bounds>("bounds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bounds", value);
        }
    }

    public string? Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("result");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bounds?.Validate();
        _ = this.Result;
    }

    public InfoRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfoRetrieveResponse(InfoRetrieveResponse infoRetrieveResponse)
        : base(infoRetrieveResponse) { }
#pragma warning restore CS8618

    public InfoRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InfoRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InfoRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InfoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InfoRetrieveResponseFromRaw : IFromRawJson<InfoRetrieveResponse>
{
    /// <inheritdoc/>
    public InfoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InfoRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Bounds, BoundsFromRaw>))]
public sealed record class Bounds : JsonModel
{
    public float? MaxX
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("maxX");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxX", value);
        }
    }

    public float? MaxY
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("maxY");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxY", value);
        }
    }

    public float? MinX
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("minX");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minX", value);
        }
    }

    public float? MinY
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("minY");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minY", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaxX;
        _ = this.MaxY;
        _ = this.MinX;
        _ = this.MinY;
    }

    public Bounds() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Bounds(Bounds bounds)
        : base(bounds) { }
#pragma warning restore CS8618

    public Bounds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Bounds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BoundsFromRaw.FromRawUnchecked"/>
    public static Bounds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BoundsFromRaw : IFromRawJson<Bounds>
{
    /// <inheritdoc/>
    public Bounds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Bounds.FromRawUnchecked(rawData);
}
