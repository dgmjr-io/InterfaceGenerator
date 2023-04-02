//
// GuidAttribute.cs
//
//   Created: 2022-10-19-05:58:09
//   Modified: 2022-10-30-07:16:07
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace System.ComponentModel.DataAnnotations;

public sealed class GuidAttribute : ValueAttribute<Guid>
{
    public GuidAttribute(string guid) : this(Guid.Parse(guid)) { }
    public GuidAttribute(Guid guid) : base(guid) { }

    public Guid Guid => Value;
}
