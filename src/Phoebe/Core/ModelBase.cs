using System.Text.Json;
using Phoebe.Exceptions;
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

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
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

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="PhoebeInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
