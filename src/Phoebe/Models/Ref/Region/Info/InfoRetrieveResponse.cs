using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Phoebe.Core;

namespace Phoebe.Models.Ref.Region.Info;

[JsonConverter(typeof(ModelConverter<InfoRetrieveResponse, InfoRetrieveResponseFromRaw>))]
public sealed record class InfoRetrieveResponse : ModelBase
{
    public Bounds? Bounds
    {
        get { return ModelBase.GetNullableClass<Bounds>(this.RawData, "bounds"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "bounds", value);
        }
    }

    public string? Result
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "result"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Bounds?.Validate();
        _ = this.Result;
    }

    public InfoRetrieveResponse() { }

    public InfoRetrieveResponse(InfoRetrieveResponse infoRetrieveResponse)
        : base(infoRetrieveResponse) { }

    public InfoRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InfoRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class InfoRetrieveResponseFromRaw : IFromRaw<InfoRetrieveResponse>
{
    /// <inheritdoc/>
    public InfoRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InfoRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Bounds, BoundsFromRaw>))]
public sealed record class Bounds : ModelBase
{
    public float? MaxX
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "maxX"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maxX", value);
        }
    }

    public float? MaxY
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "maxY"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "maxY", value);
        }
    }

    public float? MinX
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "minX"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "minX", value);
        }
    }

    public float? MinY
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "minY"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "minY", value);
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

    public Bounds(Bounds bounds)
        : base(bounds) { }

    public Bounds(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Bounds(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BoundsFromRaw.FromRawUnchecked"/>
    public static Bounds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BoundsFromRaw : IFromRaw<Bounds>
{
    /// <inheritdoc/>
    public Bounds FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Bounds.FromRawUnchecked(rawData);
}
