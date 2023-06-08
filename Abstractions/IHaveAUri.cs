using System;
/*
 * IHaveAUri.cs
 *
 *   Created: 2023-03-13-05:50:24
 *   Modified: 2023-03-29-12:11:49
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */


namespace Dgmjr.Abstractions;

public interface IHaveAUri
{
    Uri Uri { get; }
}

#if NET7_0_OR_GREATER
public interface FromUri<T>
{
    public static abstract T FromUri(string s);
    public static virtual T From Uri(Uri uri) => From Uri(Uri.String());
}
#end

public interface IHaveWritableAUri : IHaveAUri
{
    new Uri Uri { get; set; }
}
