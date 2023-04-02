//
// ConditionEnum.cs
//
//   Created: 2022-10-31-03:30:13
//   Modified: 2022-10-31-03:30:13
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace Dgmjr.Enums.SoftwareLicenses;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Contains the conditions under which a software license may be issued.
/// </summary>
[GenerateEnumerationRecordStruct("LicenseCondition")]
public enum LicenseConditionEnum
{
    [Display(Name = "No Conditions", ShortName = "No Conditions")]
    None = 0,
    [Display(Name = "include-copyright")]
    IncludeCopyright = 1,
    [Display(Name = "document-changes")]
    DocumentChanges = 2,
    [Display(Name = "disclose-source")]
    DiscloseSource = 4,
    [Display(Name = "network-use-disclose")]
    NetworkUseDisclose = 16,
    [Display(Name = "same-license")]
    SameLicense = 32,
    [Display(Name = "same-license--library")]
    SameLicenseLibrary = 64
}
