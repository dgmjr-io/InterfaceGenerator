// /* 
//  * Models.cs
//  * 
//  *   Created: 2023-04-08-03:02:41
//  *   Modified: 2023-04-08-03:02:41
//  * 
//  *   Author: David G. Moore, Jr. <david@dgmjr.io>
//  *   
//  *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

namespace Dgmjr.InterfaceGenerator.Decomposer.Models
{

    public record struct DecomposedProperty(string PropertyName, string PropertyType, string DecomposedFrom, bool IsGettable, bool IsSettable);
    public record struct DecomposedMemberModel(string DecomposedFrom, string MemberName);

    public record struct DecomposedMethodModel(string ReturnType, string MethodName, DecomposedParameterModel[]? Parameters, DecomposedTypeConstraintModel[]? GenericTypeConstraints);

    public record struct DecomposedParameterModel(string Type, string Name);

    public record struct DecomposedTypeConstraintModel(string Name, string Constraint);
}
