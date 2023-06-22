/*
 * IDbContext.cs
 *
 *   Created: 2023-04-16-02:10:19
 *   Modified: 2023-04-16-02:10:20
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
using Microsoft.EntityFrameworkCore;


namespace Microsoft.EntityFrameworkCore.Abstractions
{
    [Decompose()]
    public partial interface IDbContext
    {
        public int Foo { get; set; }
        public DbSet<Bar> Bars { get; set; }
    }

    [Decompose]
    public partial class Bar
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
