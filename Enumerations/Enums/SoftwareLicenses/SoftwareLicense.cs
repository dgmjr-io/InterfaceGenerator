/*
 * SoftwareLicense.cs
 *
 *   Created: 2022-10-31-06:27:56
 *   Modified: 2022-11-17-08:49:57
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Enums;



using System.ComponentModel.DataAnnotations;
public partial record struct SoftwareLicense// : IEnumeration, IEnumeration<SoftwareLicense, Int32>, IEquatable<SoftwareLicenseEnum>, IComparable<SoftwareLicenseEnum>, IHaveAValue<SoftwareLicenseEnum>, IHaveAValue, IIdentifiable<Int32>, IIdentifiable, IComparable<SoftwareLicense>, IEquatable<SoftwareLicense>
{
    // public virtual string Name => this.GetCustomAttribute<DisplayAttribute>().Name;
    // public virtual string ShortName => this.GetCustomAttribute<DisplayAttribute>().ShortName;
    public Uri Url => GetCustomAttribute<UriAttribute>().Uri;
}
