//
// EnumerationJsonSerializer.cs
//
//   Created: 2022-11-02-01:19:42
//   Modified: 2022-11-02-01:19:43
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
#if NETSTADARD2_0_OR_GREATER
namespace Dgmjr.Enumerations.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class EnumerationJsonConverter<TEnumeration> : JsonConverter<TEnumeration>
    where TEnumeration : class, IEnumeration
{
    public override TEnumeration? Read(ref Utf8JsonReader reader, Type typeToConvert, Jso options)
    {
        var value = reader.GetString();
        return Enumeration.Parse<TEnumeration>(value);
    }

    public override void Write(Utf8JsonWriter writer, TEnumeration value, Jso options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
#endif
