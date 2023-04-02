/*
 * EnumerationToLookupTable.cs
 *
 *   Created: 2022-12-23-09:55:49
 *   Modified: 2022-12-23-09:55:49
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.Enumerations.EntityFrameworkCore;

using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Dgmjr.Enumerations.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Abstractions;
public static class EnumerationToLookupTableExtensions
{
    public static ModelBuilder ToLookupTable<TEnum>(this ModelBuilder modelBuilder, string tableName = null, params string[] properties)
        where TEnum : class, IEnumeration<TEnum>
    {
        tableName ??= typeof(TEnum).Name;
        modelBuilder.Entity<TEnum>(e =>
        {
            e.ToTable(tableName).HasKey(e => e.Id);
            e.Property(e => e.Id).ValueGeneratedNever();
            e.HasIndex(e => e.Name);
            foreach (var property in properties)
            {
                e.Property(property).HasColumnName(property);
            }
        });
        return modelBuilder;
    }

    public static IEnumerable<TEnum> SeedLookupTable<TEnum>(this IDbContext db)
        where TEnum : class, IEnumeration<TEnum>
    {
        var getAll = typeof(TEnum).GetRuntimeMethod("GetAll", Empty<Type>());
        var values = getAll.Invoke(null, Empty<object>()) as IEnumerable<TEnum>;
        var lookupTable = db.Set<TEnum>();
        foreach (var value in values)
        {
            var enumValue = (TEnum)value;
            if (lookupTable.Find(enumValue.Id) == null)
            {
                lookupTable.Add(enumValue);
            }
        }
        db.SaveChanges();
        return lookupTable;
    }
}
