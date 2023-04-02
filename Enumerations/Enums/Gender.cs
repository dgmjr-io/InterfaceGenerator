/*
 * Gender.cs
 *
 *   Created: 2022-11-16-05:59:15
 *   Modified: 2022-11-17-08:46:27
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The gender enum.
/// </summary>
[GenerateEnumerationRecordStruct("Gender", "JustinWritesCode")]
public enum GenderEnum
{
    [Display(Name = "None")]
    None = 0,
    [Display(Name = "Agender")]
    Agender = -1,
    [Display(Name = "Male")]
    Male = 1,
    [Display(Name = "Female")]
    Female = 2,
    [Display(Name = "Cis Male")]
    CidMale = 3,
    [Display(Name = "Cis Female")]
    CisFemale = 4,
    [Display(Name = "Transman")]
    Transman = -2,
    [Display(Name = "Transwoman")]
    Transwoman = -3,
    [Display(Name = "Male")]
    Genderqueer = -11,
    [Display(Name = "Male")]
    GenderNeutral = -5,
    [Display(Name = "Other")]
    Other = -100,
}
