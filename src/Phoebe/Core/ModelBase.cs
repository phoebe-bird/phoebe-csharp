using System.Collections.Generic;
using System.Text.Json;
using Phoebe.Models.Data.Observations.Recent;
using Phoebe.Models.Data.Observations.Recent.Notable;
using Phoebe.Models.Product.Lists.Historical;
using Phoebe.Models.Product.Top100;
using Phoebe.Models.Ref.Region.Info;
using Phoebe.Models.Ref.Region.List;
using Phoebe.Models.Ref.Taxonomy.SpeciesGroups;
using Ebird = Phoebe.Models.Ref.Taxonomy.Ebird;
using Geo = Phoebe.Models.Ref.Hotspot.Geo;
using Historic = Phoebe.Models.Data.Observations.Recent.Historic;
using Hotspot = Phoebe.Models.Ref.Hotspot;
using Notable = Phoebe.Models.Data.Observations.Geo.Recent.Notable;
using Recent = Phoebe.Models.Data.Observations.Geo.Recent;

namespace Phoebe.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Cat>(),
            new ApiEnumConverter<string, Detail>(),
            new ApiEnumConverter<string, Historic::Cat>(),
            new ApiEnumConverter<string, Historic::Detail>(),
            new ApiEnumConverter<string, Historic::Rank>(),
            new ApiEnumConverter<string, Recent::Cat>(),
            new ApiEnumConverter<string, Recent::Sort>(),
            new ApiEnumConverter<string, Notable::Detail>(),
            new ApiEnumConverter<string, SortKey>(),
            new ApiEnumConverter<string, RankedBy>(),
            new ApiEnumConverter<string, RegionNameFormat>(),
            new ApiEnumConverter<string, Fmt>(),
            new ApiEnumConverter<string, Hotspot::Fmt>(),
            new ApiEnumConverter<string, Geo::Fmt>(),
            new ApiEnumConverter<string, Ebird::Fmt>(),
            new ApiEnumConverter<string, SpeciesGrouping>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
