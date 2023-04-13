/* 
 * DecomposerConstants.cs
 * 
 *   Created: 2023-04-13-12:23:57
 *   Modified: 2023-04-13-12:23:57
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.InterfaceGenerator.Decomposer
{
    public static class Constants
    {
        public const string AttributeName = "Decomposable";
        public const string AttributeNamespace = "Dgmjr.InterfaceGenerator.Decomposer";
        public const string AttributeFullName = AttributeNamespace + "." + AttributeName;

        public const string IDecomposedInterfaceDeclaration = 
        $$$"""public interface IDecomposed<{{ decomposed_from }}> { }""";

        public const string IDecomposedMarkerInterfaceDeclaration =
        $$$"""public interface IDecomposed<{{ decomposed_from }}> { }""";

        public const string IComposedClassDeclaration = 
        """
        public partial class {{ class_name }} : {{ for { decomposed_from }, IDecomposed<{ decomposed_from }>
        {
            public { class_name }({ decomposed_from } decomposed)
            {
                { decomposed_from } = decomposed;
            }

            public { decomposed_from } { decomposed_from } {{ get; }}
        }
        """;
    }
}
