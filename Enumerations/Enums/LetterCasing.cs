/*
 * LetterCasing.cs
 *
 *   Created: 2022-11-29-01:01:21
 *   Modified: 2022-11-29-01:01:21
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Humanizer
{
    /// <summary>
    /// Options for specifying the desired letter casing for the output string
    /// </summary>
    [Flags]
    public enum LetterCasing
    {
        /// <summary>
        /// SomeString -> Some String
        /// </summary>
        Title,
        /// <summary>
        /// SomeString -> SOME STRING
        /// </summary>
        AllCaps,
        /// <summary>
        /// SomeString -> some string
        /// </summary>
        LowerCase,
        /// <summary>
        /// SomeString -> Some string
        /// </summary>
        Sentence,
    }
}
