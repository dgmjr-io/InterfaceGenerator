/* 
 * ClassDecomposer.cs
 * 
 *   Created: 2023-04-13-12:08:49
 *   Modified: 2023-04-13-12:08:49
 * 
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *   
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.InterfaceGenerator.Decomposer
{


    using System;
    using Microsoft.CodeAnalysis;

    [Generator]
    public class DecompoedInterfacesGenerator : IIncrementalGenerator
    {
        public void Execute(IncrementalGeneratorInitializationContext context)
        {
            v
        }

        public static void GenerateInterfaces(type type)
        {
            if (!type.IsDefined(typeof(GenerateInterfacesAttribute), false))
            {
                return;
            }

            foreach (MethodInfo? method in type.GetMethods())
            {
                string interfaceName = $"{type.Name}_{method.Name}_Interface";
                System.Text.StringBuilder interfaceBuilder = new();

                _ = interfaceBuilder.AppendLine($"public interface {interfaceName}");
                _ = interfaceBuilder.AppendLine("{");

                foreach (ParameterInfo? parameter in method.GetParameters())
                {
                    _ = interfaceBuilder.AppendLine($"    {parameter.ParameterType.Name} {parameter.Name} {{ get; set; }}");
                }

                _ = interfaceBuilder.AppendLine("}");

                Console.WriteLine(interfaceBuilder.ToString());
            }

            foreach (PropertyInfo? property in type.GetProperties())
            {
                string interfaceName = $"{type.Name}_{property.Name}_Interface";
                System.Text.StringBuilder interfaceBuilder = new();

                _ = interfaceBuilder.AppendLine($"public interface {interfaceName}");
                _ = interfaceBuilder.AppendLine("{");

                _ = interfaceBuilder.AppendLine($"    {property.PropertyType.Name} {property.Name} {{ get; set; }}");

                _ = interfaceBuilder.AppendLine("}");

                Console.WriteLine(interfaceBuilder.ToString());
            }
        }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }

    [GenerateInterfaces]
    public class MyClass
    {
        public void MyMethod(int arg1, string arg2)
        {
        }

        public int MyProperty { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            InterfaceGenerator.GenerateInterfaces(typeof(MyClass));
        }
    }
}
