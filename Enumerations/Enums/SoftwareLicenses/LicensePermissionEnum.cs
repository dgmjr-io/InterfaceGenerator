//
// PermissionEnum.cs
//
//   Created: 2022-11-02-12:21:17
//   Modified: 2022-11-02-12:21:18
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace Dgmjr.Enums.SoftwareLicenses;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Contains the permissions granted by a software license.
/// </summary>
[GenerateEnumerationRecordStruct("LicensePermission")]
public enum LicensePermissionEnum
{
    [Display(Name = "No Permission", ShortName = "none")]
    None = 0,
    [Display(Name = "Commercial Use", ShortName = "commercial-use")]
    CommercialUse = 1,
    [Display(Name = "Distribution", ShortName = "distribution")]
    Distribution = 2,
    [Display(Name = "Modification", ShortName = "modifications")]
    Modifications = 4,
    [Display(Name = "Patent Use", ShortName = "patent-use")]
    PatentUse = 8,
    [Display(Name = "Private Use", ShortName = "private-use")]
    PrivateUse = 16,
    [Display(Name = "Sublicense", ShortName = "sublicense")]
    Sublicense = 32,
    [Display(Name = "Use", ShortName = "use")]
    Use = 64,
}

public partial record struct LicensePermission
{
}
