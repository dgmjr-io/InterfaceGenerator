/* 
 * IDecomposable.cs
 * 
 *   Created: 2023-04-13-12:11:10
 *   Modified: 2023-04-13-12:11:10
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

public sealed class Decomposable : Attribute
{
    public Decomposable(Type type)
    {
    }
}

public interface IDecomposed<TFrom>
{
    
}


public interface IComposed
{
    IEnumerable<(Type Type, MemberInfo Member)> ComposedFrom { get; }
    bool Contains(Type type, MemberInfo member);
}
