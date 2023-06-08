/*
 * IUriConvertible.cs
 *
 *   Created: 2023-06-08-02:02:45
 *   Modified: 2023-06-08-02:02:53
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Abstractions;

#if NET7_0_OR_GREATER
public interface IUriConvertible<TSelf> where TSelf : IUriConvertible<TSelf>
{
    public static abstract IUriConvertible<TSelf>  FromUri(string s);
    public static virtual IUriConvertible<TSelf>  FromUri(Uri uri) => TSelf.FromUri(uri.ToString());
}
#endif
