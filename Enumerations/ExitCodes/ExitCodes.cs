// /*
//  * ExitCodes.cs
//  *
//  *   Created: 2023-01-29-01:42:22
//  *   Modified: 2023-01-29-01:42:22
//  *
//  *   Author: David G. Mooore, Jr. <david@dgmjr.io>
//  *
//  *   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//  *      License: MIT (https://opensource.org/licenses/MIT)
//  */

// using System.CodeDom.Compiler;
// using System.Collections.Generic;
// using System.Enums;
// using System.Linq;
// using System.Reflection;
// using System.Runtime.CompilerServices;
// using System.Text;
// using Dgmjr.Abstractions;
// using Dgmjr.Enumerations.Abstractions;

// namespace System.Foo
// {
//     [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//     public struct ExitCode : IEnumeration<ExitCode, int>, IEnumeration<ExitCode>, IEnumeration, IConvertible, IComparable, IHaveAValue, IHaveAName, IHaveADescription, IIdentifiable, IComparable<ExitCode>, IEquatable<ExitCode>, IFormattable
//     {
//         /// <summary>Success</summary>
//         /// <remarks>Success</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.Success">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class Success
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.Success, 0, "Success")
//             {
//                 Id = 0,
//                 Name = "Success",
//                 Description = "Success",
//                 DisplayName = "Success",
//                 ShortName = "SUCCESS",
//                 GroupName = "ExitCode",
//                 Order = 0,
//                 Uri = "urn:system:exitcode:success",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.Success;

//             public const int Id = 0;

//             public const string Name = "Success";

//             public const string Description = "Success";

//             public const string DisplayName = "Success";

//             public const string ShortName = "SUCCESS";

//             public const string GroupName = "ExitCode";

//             public const int Order = 0;

//             public const string Uri = "urn:system:exitcode:success";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Failure</summary>
//         /// <remarks>Failure</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.Failure">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class Failure
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.Failure, 1, "Failure")
//             {
//                 Id = 1,
//                 Name = "Failure",
//                 Description = "Failure",
//                 DisplayName = "Failure",
//                 ShortName = "FAILURE",
//                 GroupName = "ExitCode",
//                 Order = 1,
//                 Uri = "urn:system:exitcode:failure",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.Failure;

//             public const int Id = 1;

//             public const string Name = "Failure";

//             public const string Description = "Failure";

//             public const string DisplayName = "Failure";

//             public const string ShortName = "FAILURE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 1;

//             public const string Uri = "urn:system:exitcode:failure";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Incorrect usage</summary>
//         /// <remarks>Incorrect usage</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExUsage">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExUsage
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExUsage, 64, "ExUsage")
//             {
//                 Id = 64,
//                 Name = "Incorrect usage",
//                 Description = "Incorrect usage",
//                 DisplayName = "ExUsage",
//                 ShortName = "EX_USAGE",
//                 GroupName = "ExitCode",
//                 Order = 64,
//                 Uri = "urn:system:exitcode:exusage",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExUsage;

//             public const int Id = 64;

//             public const string Name = "Incorrect usage";

//             public const string Description = "Incorrect usage";

//             public const string DisplayName = "ExUsage";

//             public const string ShortName = "EX_USAGE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 64;

//             public const string Uri = "urn:system:exitcode:exusage";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Data format error</summary>
//         /// <remarks>Data format error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExDataErr">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExDataErr
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExDataErr, 65, "ExDataErr")
//             {
//                 Id = 65,
//                 Name = "Data format error",
//                 Description = "Data format error",
//                 DisplayName = "ExDataErr",
//                 ShortName = "EX_DATAERR",
//                 GroupName = "ExitCode",
//                 Order = 65,
//                 Uri = "urn:system:exitcode:exdataerr",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExDataErr;

//             public const int Id = 65;

//             public const string Name = "Data format error";

//             public const string Description = "Data format error";

//             public const string DisplayName = "ExDataErr";

//             public const string ShortName = "EX_DATAERR";

//             public const string GroupName = "ExitCode";

//             public const int Order = 65;

//             public const string Uri = "urn:system:exitcode:exdataerr";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Cannot open input</summary>
//         /// <remarks>Cannot open input</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExNoInput">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExNoInput
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExNoInput, 66, "ExNoInput")
//             {
//                 Id = 66,
//                 Name = "Cannot open input",
//                 Description = "Cannot open input",
//                 DisplayName = "ExNoInput",
//                 ShortName = "EX_NOINPUT",
//                 GroupName = "ExitCode",
//                 Order = 66,
//                 Uri = "urn:system:exitcode:exnoinput",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExNoInput;

//             public const int Id = 66;

//             public const string Name = "Cannot open input";

//             public const string Description = "Cannot open input";

//             public const string DisplayName = "ExNoInput";

//             public const string ShortName = "EX_NOINPUT";

//             public const string GroupName = "ExitCode";

//             public const int Order = 66;

//             public const string Uri = "urn:system:exitcode:exnoinput";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Addressee unknown</summary>
//         /// <remarks>Addressee unknown</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExNoUser">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExNoUser
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExNoUser, 67, "ExNoUser")
//             {
//                 Id = 67,
//                 Name = "Addressee unknown",
//                 Description = "Addressee unknown",
//                 DisplayName = "ExNoUser",
//                 ShortName = "EX_NOUSER",
//                 GroupName = "ExitCode",
//                 Order = 67,
//                 Uri = "urn:system:exitcode:exnouser",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExNoUser;

//             public const int Id = 67;

//             public const string Name = "Addressee unknown";

//             public const string Description = "Addressee unknown";

//             public const string DisplayName = "ExNoUser";

//             public const string ShortName = "EX_NOUSER";

//             public const string GroupName = "ExitCode";

//             public const int Order = 67;

//             public const string Uri = "urn:system:exitcode:exnouser";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Host name unknown</summary>
//         /// <remarks>Host name unknown</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExNoHost">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExNoHost
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExNoHost, 68, "ExNoHost")
//             {
//                 Id = 68,
//                 Name = "Host name unknown",
//                 Description = "Host name unknown",
//                 DisplayName = "ExNoHost",
//                 ShortName = "EX_NOHOST",
//                 GroupName = "ExitCode",
//                 Order = 68,
//                 Uri = "urn:system:exitcode:exnohost",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExNoHost;

//             public const int Id = 68;

//             public const string Name = "Host name unknown";

//             public const string Description = "Host name unknown";

//             public const string DisplayName = "ExNoHost";

//             public const string ShortName = "EX_NOHOST";

//             public const string GroupName = "ExitCode";

//             public const int Order = 68;

//             public const string Uri = "urn:system:exitcode:exnohost";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Service unavailable</summary>
//         /// <remarks>Service unavailable</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExUnavail">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExUnavail
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExUnavail, 69, "ExUnavail")
//             {
//                 Id = 69,
//                 Name = "Service unavailable",
//                 Description = "Service unavailable",
//                 DisplayName = "ExUnavail",
//                 ShortName = "EX_UNAVAILABLE",
//                 GroupName = "ExitCode",
//                 Order = 69,
//                 Uri = "urn:system:exitcode:exunavail",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExUnavail;

//             public const int Id = 69;

//             public const string Name = "Service unavailable";

//             public const string Description = "Service unavailable";

//             public const string DisplayName = "ExUnavail";

//             public const string ShortName = "EX_UNAVAILABLE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 69;

//             public const string Uri = "urn:system:exitcode:exunavail";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Internal software error</summary>
//         /// <remarks>Internal software error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExSoftware">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExSoftware
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExSoftware, 70, "ExSoftware")
//             {
//                 Id = 70,
//                 Name = "Internal software error",
//                 Description = "Internal software error",
//                 DisplayName = "ExSoftware",
//                 ShortName = "EX_SOFTWARE",
//                 GroupName = "ExitCode",
//                 Order = 70,
//                 Uri = "urn:system:exitcode:exsoftware",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExSoftware;

//             public const int Id = 70;

//             public const string Name = "Internal software error";

//             public const string Description = "Internal software error";

//             public const string DisplayName = "ExSoftware";

//             public const string ShortName = "EX_SOFTWARE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 70;

//             public const string Uri = "urn:system:exitcode:exsoftware";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>System error (e.g., can't fork)</summary>
//         /// <remarks>System error (e.g., can't fork)</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExOsErr">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExOsErr
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExOsErr, 71, "ExOsErr")
//             {
//                 Id = 71,
//                 Name = "System error (e.g., can't fork)",
//                 Description = "System error (e.g., can't fork)",
//                 DisplayName = "ExOsErr",
//                 ShortName = "EX_OSERR",
//                 GroupName = "ExitCode",
//                 Order = 71,
//                 Uri = "urn:system:exitcode:exoserr",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExOsErr;

//             public const int Id = 71;

//             public const string Name = "System error (e.g., can't fork)";

//             public const string Description = "System error (e.g., can't fork)";

//             public const string DisplayName = "ExOsErr";

//             public const string ShortName = "EX_OSERR";

//             public const string GroupName = "ExitCode";

//             public const int Order = 71;

//             public const string Uri = "urn:system:exitcode:exoserr";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Critical OS file missing</summary>
//         /// <remarks>Critical OS file missing</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExOsFile">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExOsFile
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExOsFile, 72, "ExOsFile")
//             {
//                 Id = 72,
//                 Name = "Critical OS file missing",
//                 Description = "Critical OS file missing",
//                 DisplayName = "ExOsFile",
//                 ShortName = "EX_OSFILE",
//                 GroupName = "ExitCode",
//                 Order = 72,
//                 Uri = "urn:system:exitcode:exosfile",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExOsFile;

//             public const int Id = 72;

//             public const string Name = "Critical OS file missing";

//             public const string Description = "Critical OS file missing";

//             public const string DisplayName = "ExOsFile";

//             public const string ShortName = "EX_OSFILE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 72;

//             public const string Uri = "urn:system:exitcode:exosfile";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Cannot create (user) output file</summary>
//         /// <remarks>Cannot create (user) output file</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExCantCreate">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExCantCreate
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExCantCreate, 73, "ExCantCreate")
//             {
//                 Id = 73,
//                 Name = "Cannot create (user) output file",
//                 Description = "Cannot create (user) output file",
//                 DisplayName = "ExCantCreate",
//                 ShortName = "EX_CANTCREAT",
//                 GroupName = "ExitCode",
//                 Order = 73,
//                 Uri = "urn:system:exitcode:excantcreate",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExCantCreate;

//             public const int Id = 73;

//             public const string Name = "Cannot create (user) output file";

//             public const string Description = "Cannot create (user) output file";

//             public const string DisplayName = "ExCantCreate";

//             public const string ShortName = "EX_CANTCREAT";

//             public const string GroupName = "ExitCode";

//             public const int Order = 73;

//             public const string Uri = "urn:system:exitcode:excantcreate";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Input/output error</summary>
//         /// <remarks>Input/output error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExIoErr">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExIoErr
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExIoErr, 74, "ExIoErr")
//             {
//                 Id = 74,
//                 Name = "Input/output error",
//                 Description = "Input/output error",
//                 DisplayName = "ExIoErr",
//                 ShortName = "EX_IOERR",
//                 GroupName = "ExitCode",
//                 Order = 74,
//                 Uri = "urn:system:exitcode:exioerr",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExIoErr;

//             public const int Id = 74;

//             public const string Name = "Input/output error";

//             public const string Description = "Input/output error";

//             public const string DisplayName = "ExIoErr";

//             public const string ShortName = "EX_IOERR";

//             public const string GroupName = "ExitCode";

//             public const int Order = 74;

//             public const string Uri = "urn:system:exitcode:exioerr";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Temporary failure, user is invited to retry</summary>
//         /// <remarks>Temporary failure, user is invited to retry</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExTempFail">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExTempFail
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExTempFail, 75, "ExTempFail")
//             {
//                 Id = 75,
//                 Name = "Temporary failure, user is invited to retry",
//                 Description = "Temporary failure, user is invited to retry",
//                 DisplayName = "ExTempFail",
//                 ShortName = "EX_TEMPFAIL",
//                 GroupName = "ExitCode",
//                 Order = 75,
//                 Uri = "urn:system:exitcode:extempfail",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExTempFail;

//             public const int Id = 75;

//             public const string Name = "Temporary failure, user is invited to retry";

//             public const string Description = "Temporary failure, user is invited to retry";

//             public const string DisplayName = "ExTempFail";

//             public const string ShortName = "EX_TEMPFAIL";

//             public const string GroupName = "ExitCode";

//             public const int Order = 75;

//             public const string Uri = "urn:system:exitcode:extempfail";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Remote error in protocol</summary>
//         /// <remarks>Remote error in protocol</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExProtocol">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExProtocol
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExProtocol, 76, "ExProtocol")
//             {
//                 Id = 76,
//                 Name = "Remote error in protocol",
//                 Description = "Remote error in protocol",
//                 DisplayName = "ExProtocol",
//                 ShortName = "EX_PROTOCOL",
//                 GroupName = "ExitCode",
//                 Order = 76,
//                 Uri = "urn:system:exitcode:exprotocol",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExProtocol;

//             public const int Id = 76;

//             public const string Name = "Remote error in protocol";

//             public const string Description = "Remote error in protocol";

//             public const string DisplayName = "ExProtocol";

//             public const string ShortName = "EX_PROTOCOL";

//             public const string GroupName = "ExitCode";

//             public const int Order = 76;

//             public const string Uri = "urn:system:exitcode:exprotocol";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Permission denied</summary>
//         /// <remarks>Permission denied</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExNoPerm">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExNoPerm
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExNoPerm, 77, "ExNoPerm")
//             {
//                 Id = 77,
//                 Name = "Permission denied",
//                 Description = "Permission denied",
//                 DisplayName = "ExNoPerm",
//                 ShortName = "EX_NOPERM",
//                 GroupName = "ExitCode",
//                 Order = 77,
//                 Uri = "urn:system:exitcode:exnoperm",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExNoPerm;

//             public const int Id = 77;

//             public const string Name = "Permission denied";

//             public const string Description = "Permission denied";

//             public const string DisplayName = "ExNoPerm";

//             public const string ShortName = "EX_NOPERM";

//             public const string GroupName = "ExitCode";

//             public const int Order = 77;

//             public const string Uri = "urn:system:exitcode:exnoperm";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Configuration error</summary>
//         /// <remarks>Configuration error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.ExConfig">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class ExConfig
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.ExConfig, 78, "ExConfig")
//             {
//                 Id = 78,
//                 Name = "Configuration error",
//                 Description = "Configuration error",
//                 DisplayName = "ExConfig",
//                 ShortName = "EX_CONFIG",
//                 GroupName = "ExitCode",
//                 Order = 78,
//                 Uri = "urn:system:exitcode:exconfig",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.ExConfig;

//             public const int Id = 78;

//             public const string Name = "Configuration error";

//             public const string Description = "Configuration error";

//             public const string DisplayName = "ExConfig";

//             public const string ShortName = "EX_CONFIG";

//             public const string GroupName = "ExitCode";

//             public const int Order = 78;

//             public const string Uri = "urn:system:exitcode:exconfig";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid argument</summary>
//         /// <remarks>Invalid argument</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidArguments">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidArguments
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidArguments, 2, "InvalidArguments")
//             {
//                 Id = 2,
//                 Name = "Invalid argument",
//                 Description = "Invalid argument",
//                 DisplayName = "InvalidArguments",
//                 ShortName = "EX_ARG",
//                 GroupName = "ExitCode",
//                 Order = 2,
//                 Uri = "urn:system:exitcode:invalidarguments",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidArguments;

//             public const int Id = 2;

//             public const string Name = "Invalid argument";

//             public const string Description = "Invalid argument";

//             public const string DisplayName = "InvalidArguments";

//             public const string ShortName = "EX_ARG";

//             public const string GroupName = "ExitCode";

//             public const int Order = 2;

//             public const string Uri = "urn:system:exitcode:invalidarguments";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid project file</summary>
//         /// <remarks>Invalid project file</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidProjectFile">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidProjectFile
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidProjectFile, 3, "InvalidProjectFile")
//             {
//                 Id = 3,
//                 Name = "Invalid project file",
//                 Description = "Invalid project file",
//                 DisplayName = "InvalidProjectFile",
//                 ShortName = "EX_INVALID_PROJECT_FILE",
//                 GroupName = "ExitCode",
//                 Order = 3,
//                 Uri = "urn:system:exitcode:invalidprojectfile",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidProjectFile;

//             public const int Id = 3;

//             public const string Name = "Invalid project file";

//             public const string Description = "Invalid project file";

//             public const string DisplayName = "InvalidProjectFile";

//             public const string ShortName = "EX_INVALID_PROJECT_FILE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 3;

//             public const string Uri = "urn:system:exitcode:invalidprojectfile";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid target</summary>
//         /// <remarks>Invalid target</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidTarget">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidTarget
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidTarget, 4, "InvalidTarget")
//             {
//                 Id = 4,
//                 Name = "Invalid target",
//                 Description = "Invalid target",
//                 DisplayName = "InvalidTarget",
//                 ShortName = "EX_INVALID_TARGET",
//                 GroupName = "ExitCode",
//                 Order = 4,
//                 Uri = "urn:system:exitcode:invalidtarget",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidTarget;

//             public const int Id = 4;

//             public const string Name = "Invalid target";

//             public const string Description = "Invalid target";

//             public const string DisplayName = "InvalidTarget";

//             public const string ShortName = "EX_INVALID_TARGET";

//             public const string GroupName = "ExitCode";

//             public const int Order = 4;

//             public const string Uri = "urn:system:exitcode:invalidtarget";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid configuration</summary>
//         /// <remarks>Invalid configuration</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidConfiguration">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidConfiguration
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidConfiguration, 5, "InvalidConfiguration")
//             {
//                 Id = 5,
//                 Name = "Invalid configuration",
//                 Description = "Invalid configuration",
//                 DisplayName = "InvalidConfiguration",
//                 ShortName = "EX_INVALID_CONFIGURATION",
//                 GroupName = "ExitCode",
//                 Order = 5,
//                 Uri = "urn:system:exitcode:invalidconfiguration",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidConfiguration;

//             public const int Id = 5;

//             public const string Name = "Invalid configuration";

//             public const string Description = "Invalid configuration";

//             public const string DisplayName = "InvalidConfiguration";

//             public const string ShortName = "EX_INVALID_CONFIGURATION";

//             public const string GroupName = "ExitCode";

//             public const int Order = 5;

//             public const string Uri = "urn:system:exitcode:invalidconfiguration";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid verbosity</summary>
//         /// <remarks>Invalid verbosity</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidVerbosity">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidVerbosity
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidVerbosity, 6, "InvalidVerbosity")
//             {
//                 Id = 6,
//                 Name = "Invalid verbosity",
//                 Description = "Invalid verbosity",
//                 DisplayName = "InvalidVerbosity",
//                 ShortName = "EX_INVALID_VERBOSITY",
//                 GroupName = "ExitCode",
//                 Order = 6,
//                 Uri = "urn:system:exitcode:invalidverbosity",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidVerbosity;

//             public const int Id = 6;

//             public const string Name = "Invalid verbosity";

//             public const string Description = "Invalid verbosity";

//             public const string DisplayName = "InvalidVerbosity";

//             public const string ShortName = "EX_INVALID_VERBOSITY";

//             public const string GroupName = "ExitCode";

//             public const int Order = 6;

//             public const string Uri = "urn:system:exitcode:invalidverbosity";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid version</summary>
//         /// <remarks>Invalid version</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidVersion">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidVersion
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidVersion, 7, "InvalidVersion")
//             {
//                 Id = 7,
//                 Name = "Invalid version",
//                 Description = "Invalid version",
//                 DisplayName = "InvalidVersion",
//                 ShortName = "EX_INVALID_VERSION",
//                 GroupName = "ExitCode",
//                 Order = 7,
//                 Uri = "urn:system:exitcode:invalidversion",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidVersion;

//             public const int Id = 7;

//             public const string Name = "Invalid version";

//             public const string Description = "Invalid version";

//             public const string DisplayName = "InvalidVersion";

//             public const string ShortName = "EX_INVALID_VERSION";

//             public const string GroupName = "ExitCode";

//             public const int Order = 7;

//             public const string Uri = "urn:system:exitcode:invalidversion";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid assembly version</summary>
//         /// <remarks>Invalid assembly version</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidAssemblyVersion">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidAssemblyVersion
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidAssemblyVersion, 8, "InvalidAssemblyVersion")
//             {
//                 Id = 8,
//                 Name = "Invalid assembly version",
//                 Description = "Invalid assembly version",
//                 DisplayName = "InvalidAssemblyVersion",
//                 ShortName = "EX_INVALID_ASSEMBLY_VERSION",
//                 GroupName = "ExitCode",
//                 Order = 8,
//                 Uri = "urn:system:exitcode:invalidassemblyversion",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidAssemblyVersion;

//             public const int Id = 8;

//             public const string Name = "Invalid assembly version";

//             public const string Description = "Invalid assembly version";

//             public const string DisplayName = "InvalidAssemblyVersion";

//             public const string ShortName = "EX_INVALID_ASSEMBLY_VERSION";

//             public const string GroupName = "ExitCode";

//             public const int Order = 8;

//             public const string Uri = "urn:system:exitcode:invalidassemblyversion";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid property</summary>
//         /// <remarks>Invalid property</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidProperty">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidProperty
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidProperty, 9, "InvalidProperty")
//             {
//                 Id = 9,
//                 Name = "Invalid property",
//                 Description = "Invalid property",
//                 DisplayName = "InvalidProperty",
//                 ShortName = "EX_INVALID_PROPERTY",
//                 GroupName = "ExitCode",
//                 Order = 9,
//                 Uri = "urn:system:exitcode:invalidproperty",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidProperty;

//             public const int Id = 9;

//             public const string Name = "Invalid property";

//             public const string Description = "Invalid property";

//             public const string DisplayName = "InvalidProperty";

//             public const string ShortName = "EX_INVALID_PROPERTY";

//             public const string GroupName = "ExitCode";

//             public const int Order = 9;

//             public const string Uri = "urn:system:exitcode:invalidproperty";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid binary logger</summary>
//         /// <remarks>Invalid binary logger</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidBinaryLogger">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidBinaryLogger
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidBinaryLogger, 10, "InvalidBinaryLogger")
//             {
//                 Id = 10,
//                 Name = "Invalid binary logger",
//                 Description = "Invalid binary logger",
//                 DisplayName = "InvalidBinaryLogger",
//                 ShortName = "EX_INVALID_BINARY_LOGGER",
//                 GroupName = "ExitCode",
//                 Order = 10,
//                 Uri = "urn:system:exitcode:invalidbinarylogger",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidBinaryLogger;

//             public const int Id = 10;

//             public const string Name = "Invalid binary logger";

//             public const string Description = "Invalid binary logger";

//             public const string DisplayName = "InvalidBinaryLogger";

//             public const string ShortName = "EX_INVALID_BINARY_LOGGER";

//             public const string GroupName = "ExitCode";

//             public const int Order = 10;

//             public const string Uri = "urn:system:exitcode:invalidbinarylogger";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid binary log file</summary>
//         /// <remarks>Invalid binary log file</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidBinaryLogFile">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidBinaryLogFile
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidBinaryLogFile, 11, "InvalidBinaryLogFile")
//             {
//                 Id = 11,
//                 Name = "Invalid binary log file",
//                 Description = "Invalid binary log file",
//                 DisplayName = "InvalidBinaryLogFile",
//                 ShortName = "EX_INVALID_BINARY_LOG_FILE",
//                 GroupName = "ExitCode",
//                 Order = 11,
//                 Uri = "urn:system:exitcode:invalidbinarylogfile",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidBinaryLogFile;

//             public const int Id = 11;

//             public const string Name = "Invalid binary log file";

//             public const string Description = "Invalid binary log file";

//             public const string DisplayName = "InvalidBinaryLogFile";

//             public const string ShortName = "EX_INVALID_BINARY_LOG_FILE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 11;

//             public const string Uri = "urn:system:exitcode:invalidbinarylogfile";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid help</summary>
//         /// <remarks>Invalid help</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidHelp">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidHelp
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidHelp, 12, "InvalidHelp")
//             {
//                 Id = 12,
//                 Name = "Invalid help",
//                 Description = "Invalid help",
//                 DisplayName = "InvalidHelp",
//                 ShortName = "EX_INVALID_HELP",
//                 GroupName = "ExitCode",
//                 Order = 12,
//                 Uri = "urn:system:exitcode:invalidhelp",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidHelp;

//             public const int Id = 12;

//             public const string Name = "Invalid help";

//             public const string Description = "Invalid help";

//             public const string DisplayName = "InvalidHelp";

//             public const string ShortName = "EX_INVALID_HELP";

//             public const string GroupName = "ExitCode";

//             public const int Order = 12;

//             public const string Uri = "urn:system:exitcode:invalidhelp";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid command</summary>
//         /// <remarks>Invalid command</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidCommand">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidCommand
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidCommand, 13, "InvalidCommand")
//             {
//                 Id = 13,
//                 Name = "Invalid command",
//                 Description = "Invalid command",
//                 DisplayName = "InvalidCommand",
//                 ShortName = "EX_INVALID_COMMAND",
//                 GroupName = "ExitCode",
//                 Order = 13,
//                 Uri = "urn:system:exitcode:invalidcommand",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidCommand;

//             public const int Id = 13;

//             public const string Name = "Invalid command";

//             public const string Description = "Invalid command";

//             public const string DisplayName = "InvalidCommand";

//             public const string ShortName = "EX_INVALID_COMMAND";

//             public const string GroupName = "ExitCode";

//             public const int Order = 13;

//             public const string Uri = "urn:system:exitcode:invalidcommand";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid project path</summary>
//         /// <remarks>Invalid project path</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidProjectPath">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidProjectPath
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidProjectPath, 14, "InvalidProjectPath")
//             {
//                 Id = 14,
//                 Name = "Invalid project path",
//                 Description = "Invalid project path",
//                 DisplayName = "InvalidProjectPath",
//                 ShortName = "EX_INVALID_PROJECT_PATH",
//                 GroupName = "ExitCode",
//                 Order = 14,
//                 Uri = "urn:system:exitcode:invalidprojectpath",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidProjectPath;

//             public const int Id = 14;

//             public const string Name = "Invalid project path";

//             public const string Description = "Invalid project path";

//             public const string DisplayName = "InvalidProjectPath";

//             public const string ShortName = "EX_INVALID_PROJECT_PATH";

//             public const string GroupName = "ExitCode";

//             public const int Order = 14;

//             public const string Uri = "urn:system:exitcode:invalidprojectpath";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid target path</summary>
//         /// <remarks>Invalid target path</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidTargetPath">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidTargetPath
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidTargetPath, 15, "InvalidTargetPath")
//             {
//                 Id = 15,
//                 Name = "Invalid target path",
//                 Description = "Invalid target path",
//                 DisplayName = "InvalidTargetPath",
//                 ShortName = "EX_INVALID_TARGET_PATH",
//                 GroupName = "ExitCode",
//                 Order = 15,
//                 Uri = "urn:system:exitcode:invalidtargetpath",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidTargetPath;

//             public const int Id = 15;

//             public const string Name = "Invalid target path";

//             public const string Description = "Invalid target path";

//             public const string DisplayName = "InvalidTargetPath";

//             public const string ShortName = "EX_INVALID_TARGET_PATH";

//             public const string GroupName = "ExitCode";

//             public const int Order = 15;

//             public const string Uri = "urn:system:exitcode:invalidtargetpath";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid target framework</summary>
//         /// <remarks>Invalid target framework</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidTargetFramework">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidTargetFramework
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidTargetFramework, 16, "InvalidTargetFramework")
//             {
//                 Id = 16,
//                 Name = "Invalid target framework",
//                 Description = "Invalid target framework",
//                 DisplayName = "InvalidTargetFramework",
//                 ShortName = "EX_INVALID_TARGET_FRAMEWORK",
//                 GroupName = "ExitCode",
//                 Order = 16,
//                 Uri = "urn:system:exitcode:invalidtargetframework",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidTargetFramework;

//             public const int Id = 16;

//             public const string Name = "Invalid target framework";

//             public const string Description = "Invalid target framework";

//             public const string DisplayName = "InvalidTargetFramework";

//             public const string ShortName = "EX_INVALID_TARGET_FRAMEWORK";

//             public const string GroupName = "ExitCode";

//             public const int Order = 16;

//             public const string Uri = "urn:system:exitcode:invalidtargetframework";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid output path</summary>
//         /// <remarks>Invalid output path</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidOutputPath">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidOutputPath
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidOutputPath, 17, "InvalidOutputPath")
//             {
//                 Id = 17,
//                 Name = "Invalid output path",
//                 Description = "Invalid output path",
//                 DisplayName = "InvalidOutputPath",
//                 ShortName = "EX_INVALID_OUTPUT_PATH",
//                 GroupName = "ExitCode",
//                 Order = 17,
//                 Uri = "urn:system:exitcode:invalidoutputpath",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidOutputPath;

//             public const int Id = 17;

//             public const string Name = "Invalid output path";

//             public const string Description = "Invalid output path";

//             public const string DisplayName = "InvalidOutputPath";

//             public const string ShortName = "EX_INVALID_OUTPUT_PATH";

//             public const string GroupName = "ExitCode";

//             public const int Order = 17;

//             public const string Uri = "urn:system:exitcode:invalidoutputpath";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid output type</summary>
//         /// <remarks>Invalid output type</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidOutputType">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidOutputType
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidOutputType, 18, "InvalidOutputType")
//             {
//                 Id = 18,
//                 Name = "Invalid output type",
//                 Description = "Invalid output type",
//                 DisplayName = "InvalidOutputType",
//                 ShortName = "EX_INVALID_OUTPUT_TYPE",
//                 GroupName = "ExitCode",
//                 Order = 18,
//                 Uri = "urn:system:exitcode:invalidoutputtype",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidOutputType;

//             public const int Id = 18;

//             public const string Name = "Invalid output type";

//             public const string Description = "Invalid output type";

//             public const string DisplayName = "InvalidOutputType";

//             public const string ShortName = "EX_INVALID_OUTPUT_TYPE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 18;

//             public const string Uri = "urn:system:exitcode:invalidoutputtype";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no logo</summary>
//         /// <remarks>Invalid no logo</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoLogo">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoLogo
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoLogo, 19, "InvalidNoLogo")
//             {
//                 Id = 19,
//                 Name = "Invalid no logo",
//                 Description = "Invalid no logo",
//                 DisplayName = "InvalidNoLogo",
//                 ShortName = "EX_INVALID_NO_LOGO",
//                 GroupName = "ExitCode",
//                 Order = 19,
//                 Uri = "urn:system:exitcode:invalidnologo",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoLogo;

//             public const int Id = 19;

//             public const string Name = "Invalid no logo";

//             public const string Description = "Invalid no logo";

//             public const string DisplayName = "InvalidNoLogo";

//             public const string ShortName = "EX_INVALID_NO_LOGO";

//             public const string GroupName = "ExitCode";

//             public const int Order = 19;

//             public const string Uri = "urn:system:exitcode:invalidnologo";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no restore</summary>
//         /// <remarks>Invalid no restore</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoRestore">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoRestore
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoRestore, 20, "InvalidNoRestore")
//             {
//                 Id = 20,
//                 Name = "Invalid no restore",
//                 Description = "Invalid no restore",
//                 DisplayName = "InvalidNoRestore",
//                 ShortName = "EX_INVALID_NO_RESTORE",
//                 GroupName = "ExitCode",
//                 Order = 20,
//                 Uri = "urn:system:exitcode:invalidnorestore",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoRestore;

//             public const int Id = 20;

//             public const string Name = "Invalid no restore";

//             public const string Description = "Invalid no restore";

//             public const string DisplayName = "InvalidNoRestore";

//             public const string ShortName = "EX_INVALID_NO_RESTORE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 20;

//             public const string Uri = "urn:system:exitcode:invalidnorestore";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no build</summary>
//         /// <remarks>Invalid no build</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoBuild">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoBuild
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoBuild, 21, "InvalidNoBuild")
//             {
//                 Id = 21,
//                 Name = "Invalid no build",
//                 Description = "Invalid no build",
//                 DisplayName = "InvalidNoBuild",
//                 ShortName = "EX_INVALID_NO_BUILD",
//                 GroupName = "ExitCode",
//                 Order = 21,
//                 Uri = "urn:system:exitcode:invalidnobuild",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoBuild;

//             public const int Id = 21;

//             public const string Name = "Invalid no build";

//             public const string Description = "Invalid no build";

//             public const string DisplayName = "InvalidNoBuild";

//             public const string ShortName = "EX_INVALID_NO_BUILD";

//             public const string GroupName = "ExitCode";

//             public const int Order = 21;

//             public const string Uri = "urn:system:exitcode:invalidnobuild";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no dependencies</summary>
//         /// <remarks>Invalid no dependencies</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoDependencies">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoDependencies
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoDependencies, 22, "InvalidNoDependencies")
//             {
//                 Id = 22,
//                 Name = "Invalid no dependencies",
//                 Description = "Invalid no dependencies",
//                 DisplayName = "InvalidNoDependencies",
//                 ShortName = "EX_INVALID_NO_DEPENDENCIES",
//                 GroupName = "ExitCode",
//                 Order = 22,
//                 Uri = "urn:system:exitcode:invalidnodependencies",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoDependencies;

//             public const int Id = 22;

//             public const string Name = "Invalid no dependencies";

//             public const string Description = "Invalid no dependencies";

//             public const string DisplayName = "InvalidNoDependencies";

//             public const string ShortName = "EX_INVALID_NO_DEPENDENCIES";

//             public const string GroupName = "ExitCode";

//             public const int Order = 22;

//             public const string Uri = "urn:system:exitcode:invalidnodependencies";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no incremental</summary>
//         /// <remarks>Invalid no incremental</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoIncremental">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoIncremental
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoIncremental, 23, "InvalidNoIncremental")
//             {
//                 Id = 23,
//                 Name = "Invalid no incremental",
//                 Description = "Invalid no incremental",
//                 DisplayName = "InvalidNoIncremental",
//                 ShortName = "EX_INVALID_NO_INCREMENTAL",
//                 GroupName = "ExitCode",
//                 Order = 23,
//                 Uri = "urn:system:exitcode:invalidnoincremental",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoIncremental;

//             public const int Id = 23;

//             public const string Name = "Invalid no incremental";

//             public const string Description = "Invalid no incremental";

//             public const string DisplayName = "InvalidNoIncremental";

//             public const string ShortName = "EX_INVALID_NO_INCREMENTAL";

//             public const string GroupName = "ExitCode";

//             public const int Order = 23;

//             public const string Uri = "urn:system:exitcode:invalidnoincremental";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no interactive</summary>
//         /// <remarks>Invalid no interactive</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoInteractive">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoInteractive
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoInteractive, 24, "InvalidNoInteractive")
//             {
//                 Id = 24,
//                 Name = "Invalid no interactive",
//                 Description = "Invalid no interactive",
//                 DisplayName = "InvalidNoInteractive",
//                 ShortName = "EX_INVALID_NO_INTERACTIVE",
//                 GroupName = "ExitCode",
//                 Order = 24,
//                 Uri = "urn:system:exitcode:invalidnointeractive",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoInteractive;

//             public const int Id = 24;

//             public const string Name = "Invalid no interactive";

//             public const string Description = "Invalid no interactive";

//             public const string DisplayName = "InvalidNoInteractive";

//             public const string ShortName = "EX_INVALID_NO_INTERACTIVE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 24;

//             public const string Uri = "urn:system:exitcode:invalidnointeractive";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid interactive</summary>
//         /// <remarks>Invalid interactive</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidInteractive">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidInteractive
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidInteractive, 25, "InvalidInteractive")
//             {
//                 Id = 25,
//                 Name = "Invalid interactive",
//                 Description = "Invalid interactive",
//                 DisplayName = "InvalidInteractive",
//                 ShortName = "EX_INVALID_INTERACTIVE",
//                 GroupName = "ExitCode",
//                 Order = 25,
//                 Uri = "urn:system:exitcode:invalidinteractive",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidInteractive;

//             public const int Id = 25;

//             public const string Name = "Invalid interactive";

//             public const string Description = "Invalid interactive";

//             public const string DisplayName = "InvalidInteractive";

//             public const string ShortName = "EX_INVALID_INTERACTIVE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 25;

//             public const string Uri = "urn:system:exitcode:invalidinteractive";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no warn</summary>
//         /// <remarks>Invalid no warn</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoWarn">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoWarn
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoWarn, 26, "InvalidNoWarn")
//             {
//                 Id = 26,
//                 Name = "Invalid no warn",
//                 Description = "Invalid no warn",
//                 DisplayName = "InvalidNoWarn",
//                 ShortName = "EX_INVALID_NO_WARN",
//                 GroupName = "ExitCode",
//                 Order = 26,
//                 Uri = "urn:system:exitcode:invalidnowarn",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoWarn;

//             public const int Id = 26;

//             public const string Name = "Invalid no warn";

//             public const string Description = "Invalid no warn";

//             public const string DisplayName = "InvalidNoWarn";

//             public const string ShortName = "EX_INVALID_NO_WARN";

//             public const string GroupName = "ExitCode";

//             public const int Order = 26;

//             public const string Uri = "urn:system:exitcode:invalidnowarn";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid warn as error</summary>
//         /// <remarks>Invalid warn as error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidWarnAsError">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidWarnAsError
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidWarnAsError, 27, "InvalidWarnAsError")
//             {
//                 Id = 27,
//                 Name = "Invalid warn as error",
//                 Description = "Invalid warn as error",
//                 DisplayName = "InvalidWarnAsError",
//                 ShortName = "EX_INVALID_WARN_AS_ERROR",
//                 GroupName = "ExitCode",
//                 Order = 27,
//                 Uri = "urn:system:exitcode:invalidwarnaserror",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidWarnAsError;

//             public const int Id = 27;

//             public const string Name = "Invalid warn as error";

//             public const string Description = "Invalid warn as error";

//             public const string DisplayName = "InvalidWarnAsError";

//             public const string ShortName = "EX_INVALID_WARN_AS_ERROR";

//             public const string GroupName = "ExitCode";

//             public const int Order = 27;

//             public const string Uri = "urn:system:exitcode:invalidwarnaserror";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid force</summary>
//         /// <remarks>Invalid force</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidForce">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidForce
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidForce, 28, "InvalidForce")
//             {
//                 Id = 28,
//                 Name = "Invalid force",
//                 Description = "Invalid force",
//                 DisplayName = "InvalidForce",
//                 ShortName = "EX_INVALID_FORCE",
//                 GroupName = "ExitCode",
//                 Order = 28,
//                 Uri = "urn:system:exitcode:invalidforce",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidForce;

//             public const int Id = 28;

//             public const string Name = "Invalid force";

//             public const string Description = "Invalid force";

//             public const string DisplayName = "InvalidForce";

//             public const string ShortName = "EX_INVALID_FORCE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 28;

//             public const string Uri = "urn:system:exitcode:invalidforce";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no cache</summary>
//         /// <remarks>Invalid no cache</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoCache">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoCache
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoCache, 29, "InvalidNoCache")
//             {
//                 Id = 29,
//                 Name = "Invalid no cache",
//                 Description = "Invalid no cache",
//                 DisplayName = "InvalidNoCache",
//                 ShortName = "EX_INVALID_NO_CACHE",
//                 GroupName = "ExitCode",
//                 Order = 29,
//                 Uri = "urn:system:exitcode:invalidnocache",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoCache;

//             public const int Id = 29;

//             public const string Name = "Invalid no cache";

//             public const string Description = "Invalid no cache";

//             public const string DisplayName = "InvalidNoCache";

//             public const string ShortName = "EX_INVALID_NO_CACHE";

//             public const string GroupName = "ExitCode";

//             public const int Order = 29;

//             public const string Uri = "urn:system:exitcode:invalidnocache";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no version</summary>
//         /// <remarks>Invalid no version</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoVersion">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoVersion
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoVersion, 30, "InvalidNoVersion")
//             {
//                 Id = 30,
//                 Name = "Invalid no version",
//                 Description = "Invalid no version",
//                 DisplayName = "InvalidNoVersion",
//                 ShortName = "EX_INVALID_NO_VERSION",
//                 GroupName = "ExitCode",
//                 Order = 30,
//                 Uri = "urn:system:exitcode:invalidnoversion",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoVersion;

//             public const int Id = 30;

//             public const string Name = "Invalid no version";

//             public const string Description = "Invalid no version";

//             public const string DisplayName = "InvalidNoVersion";

//             public const string ShortName = "EX_INVALID_NO_VERSION";

//             public const string GroupName = "ExitCode";

//             public const int Order = 30;

//             public const string Uri = "urn:system:exitcode:invalidnoversion";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no package analysis</summary>
//         /// <remarks>Invalid no package analysis</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.InvalidNoPackageAnalysis">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class InvalidNoPackageAnalysis
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.InvalidNoPackageAnalysis, 31, "InvalidNoPackageAnalysis")
//             {
//                 Id = 31,
//                 Name = "Invalid no package analysis",
//                 Description = "Invalid no package analysis",
//                 DisplayName = "InvalidNoPackageAnalysis",
//                 ShortName = "EX_INVALID_NO_PACKAGE_ANALYSIS",
//                 GroupName = "ExitCode",
//                 Order = 31,
//                 Uri = "urn:system:exitcode:invalidnopackageanalysis",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.InvalidNoPackageAnalysis;

//             public const int Id = 31;

//             public const string Name = "Invalid no package analysis";

//             public const string Description = "Invalid no package analysis";

//             public const string DisplayName = "InvalidNoPackageAnalysis";

//             public const string ShortName = "EX_INVALID_NO_PACKAGE_ANALYSIS";

//             public const string GroupName = "ExitCode";

//             public const int Order = 31;

//             public const string Uri = "urn:system:exitcode:invalidnopackageanalysis";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Invalid no dependencies analysis</summary>
//         /// <remarks>Invalid no dependencies analysis</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.CommandFoundNotExecutable">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class CommandFoundNotExecutable
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.CommandFoundNotExecutable, 126, "CommandFoundNotExecutable")
//             {
//                 Id = 126,
//                 Name = "Invalid no dependencies analysis",
//                 Description = "Invalid no dependencies analysis",
//                 DisplayName = "CommandFoundNotExecutable",
//                 ShortName = "EX_INVALID_NO_DEPENDENCIES_ANALYSIS",
//                 GroupName = "ExitCode",
//                 Order = 126,
//                 Uri = "urn:system:exitcode:commandfoundnotexecutable",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.CommandFoundNotExecutable;

//             public const int Id = 126;

//             public const string Name = "Invalid no dependencies analysis";

//             public const string Description = "Invalid no dependencies analysis";

//             public const string DisplayName = "CommandFoundNotExecutable";

//             public const string ShortName = "EX_INVALID_NO_DEPENDENCIES_ANALYSIS";

//             public const string GroupName = "ExitCode";

//             public const int Order = 126;

//             public const string Uri = "urn:system:exitcode:commandfoundnotexecutable";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Command not found</summary>
//         /// <remarks>Command not found</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.CommandNotFound">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class CommandNotFound
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.CommandNotFound, 127, "CommandNotFound")
//             {
//                 Id = 127,
//                 Name = "Command not found",
//                 Description = "Command not found",
//                 DisplayName = "CommandNotFound",
//                 ShortName = "EX_COMMAND_NOT_FOUND",
//                 GroupName = "ExitCode",
//                 Order = 127,
//                 Uri = "urn:system:exitcode:commandnotfound",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.CommandNotFound;

//             public const int Id = 127;

//             public const string Name = "Command not found";

//             public const string Description = "Command not found";

//             public const string DisplayName = "CommandNotFound";

//             public const string ShortName = "EX_COMMAND_NOT_FOUND";

//             public const string GroupName = "ExitCode";

//             public const int Order = 127;

//             public const string Uri = "urn:system:exitcode:commandnotfound";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Command encountered error</summary>
//         /// <remarks>Command encountered error</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.CommandEncounteredError">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class CommandEncounteredError
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.CommandEncounteredError, 128, "CommandEncounteredError")
//             {
//                 Id = 128,
//                 Name = "Command encountered error",
//                 Description = "Command encountered error",
//                 DisplayName = "CommandEncounteredError",
//                 ShortName = "EX_COMMAND_ENCOUNTERED_ERROR",
//                 GroupName = "ExitCode",
//                 Order = 128,
//                 Uri = "urn:system:exitcode:commandencounterederror",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.CommandEncounteredError;

//             public const int Id = 128;

//             public const string Name = "Command encountered error";

//             public const string Description = "Command encountered error";

//             public const string DisplayName = "CommandEncounteredError";

//             public const string ShortName = "EX_COMMAND_ENCOUNTERED_ERROR";

//             public const string GroupName = "ExitCode";

//             public const int Order = 128;

//             public const string Uri = "urn:system:exitcode:commandencounterederror";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Command terminated by signal 2</summary>
//         /// <remarks>Command terminated by signal 2</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.CommandTerminatedBySignal2">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class CommandTerminatedBySignal2
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.CommandTerminatedBySignal2, 130, "CommandTerminatedBySignal2")
//             {
//                 Id = 130,
//                 Name = "Command terminated by signal 2",
//                 Description = "Command terminated by signal 2",
//                 DisplayName = "CommandTerminatedBySignal2",
//                 ShortName = "EX_COMMAND_TERMINATED_BY_SIGNAL_2",
//                 GroupName = "ExitCode",
//                 Order = 130,
//                 Uri = "urn:system:exitcode:commandterminatedbysignal2",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.CommandTerminatedBySignal2;

//             public const int Id = 130;

//             public const string Name = "Command terminated by signal 2";

//             public const string Description = "Command terminated by signal 2";

//             public const string DisplayName = "CommandTerminatedBySignal2";

//             public const string ShortName = "EX_COMMAND_TERMINATED_BY_SIGNAL_2";

//             public const string GroupName = "ExitCode";

//             public const int Order = 130;

//             public const string Uri = "urn:system:exitcode:commandterminatedbysignal2";

//             public const string Prompt = "ExitCode";
//         }

//         /// <summary>Command terminated by signal 15</summary>
//         /// <remarks>Command terminated by signal 15</remarks>
//         /// <seealso cref="F:System.Enums.ExitCode.CommandTerminatedBySignal15">ExitCode</seealso>
//         [GeneratedCode("Dgmjr.Enumerations.CodeGeneration.V2", "0.0.1.0")]
//         public static class CommandTerminatedBySignal15
//         {
//             public static readonly ExitCode Instance = new ExitCode(System.Enums.ExitCode.CommandTerminatedBySignal15, 143, "CommandTerminatedBySignal15")
//             {
//                 Id = 143,
//                 Name = "Command terminated by signal 15",
//                 Description = "Command terminated by signal 15",
//                 DisplayName = "CommandTerminatedBySignal15",
//                 ShortName = "EX_COMMAND_TERMINATED_BY_SIGNAL_15",
//                 GroupName = "ExitCode",
//                 Order = 143,
//                 Uri = "urn:system:exitcode:commandterminatedbysignal15",
//                 Prompt = "ExitCode"
//             };

//             public const System.Enums.ExitCode Value = System.Enums.ExitCode.CommandTerminatedBySignal15;

//             public const int Id = 143;

//             public const string Name = "Command terminated by signal 15";

//             public const string Description = "Command terminated by signal 15";

//             public const string DisplayName = "CommandTerminatedBySignal15";

//             public const string ShortName = "EX_COMMAND_TERMINATED_BY_SIGNAL_15";

//             public const string GroupName = "ExitCode";

//             public const int Order = 143;

//             public const string Uri = "urn:system:exitcode:commandterminatedbysignal15";

//             public const string Prompt = "ExitCode";
//         }

//         public static readonly ExitCode[] All = new ExitCode[52]
//         {
//             Success.Instance,
//             Failure.Instance,
//             ExUsage.Instance,
//             ExDataErr.Instance,
//             ExNoInput.Instance,
//             ExNoUser.Instance,
//             ExNoHost.Instance,
//             ExUnavail.Instance,
//             ExSoftware.Instance,
//             ExOsErr.Instance,
//             ExOsFile.Instance,
//             ExCantCreate.Instance,
//             ExIoErr.Instance,
//             ExTempFail.Instance,
//             ExProtocol.Instance,
//             ExNoPerm.Instance,
//             ExConfig.Instance,
//             InvalidArguments.Instance,
//             InvalidProjectFile.Instance,
//             InvalidTarget.Instance,
//             InvalidConfiguration.Instance,
//             InvalidVerbosity.Instance,
//             InvalidVersion.Instance,
//             InvalidAssemblyVersion.Instance,
//             InvalidProperty.Instance,
//             InvalidBinaryLogger.Instance,
//             InvalidBinaryLogFile.Instance,
//             InvalidHelp.Instance,
//             InvalidCommand.Instance,
//             InvalidProjectPath.Instance,
//             InvalidTargetPath.Instance,
//             InvalidTargetFramework.Instance,
//             InvalidOutputPath.Instance,
//             InvalidOutputType.Instance,
//             InvalidNoLogo.Instance,
//             InvalidNoRestore.Instance,
//             InvalidNoBuild.Instance,
//             InvalidNoDependencies.Instance,
//             InvalidNoIncremental.Instance,
//             InvalidNoInteractive.Instance,
//             InvalidInteractive.Instance,
//             InvalidNoWarn.Instance,
//             InvalidWarnAsError.Instance,
//             InvalidForce.Instance,
//             InvalidNoCache.Instance,
//             InvalidNoVersion.Instance,
//             InvalidNoPackageAnalysis.Instance,
//             CommandFoundNotExecutable.Instance,
//             CommandNotFound.Instance,
//             CommandEncounteredError.Instance,
//             CommandTerminatedBySignal2.Instance,
//             CommandTerminatedBySignal15.Instance
//         };

//         public static readonly int Count = All.Length;

//         object Id => Id;

//         object Value => Value;

//         public System.Enums.ExitCode Value { get; private set; }

//         public int Id { get; private set; }

//         public string Name { get; private set; }

//         public string Description { get; private set; }

//         public string DisplayName { get; private set; }

//         public string ShortName { get; private set; }

//         public string GroupName { get; private set; }

//         public int Order { get; private set; }

//         public string Uri { get; private set; }

//         public string Prompt { get; private set; }

//         public FieldInfo? FieldInfo => typeof(System.Enums.ExitCode).GetRuntimeField(Name);

//         public ExitCode(System.Enums.ExitCode value, int id, string? name = null, string? description = null)
//         {
//             Id = 0;
//             Name = null;
//             Description = null;
//             DisplayName = null;
//             ShortName = null;
//             GroupName = null;
//             Order = 0;
//             Uri = null;
//             Prompt = null;
//             Value = value;
//             Id = id;
//             Name = name ?? value.ToString();
//             Description = description;
//         }

//         public override string ToString()
//         {
//             return Name;
//         }

//         public static ExitCode FromValue(System.Enums.ExitCode value)
//         {
//             return FromValue(value, throwOnNotFound: true);
//         }

//         public static ExitCode FromValue(System.Enums.ExitCode value, bool throwOnNotFound)
//         {
//             ExitCode exitCode = All.FirstOrDefault((ExitCode x) => x.Value.Equals(value));
//             if (exitCode == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("value", value, $"The value {value} is not a valid ENUMERATION_TYPE.");
//             }
//             return exitCode;
//         }

//         public static ExitCode FromId(int id)
//         {
//             return FromId(id, throwOnNotFound: true);
//         }

//         public static ExitCode FromId(int id, bool throwOnNotFound)
//         {
//             ExitCode exitCode = All.FirstOrDefault((ExitCode x) => x.Id == id);
//             if (exitCode == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("id", id, $"The id {id} is not a valid ENUMERATION_TYPE.");
//             }
//             return exitCode;
//         }

//         public static ExitCode FromName(string name)
//         {
//             return FromName(name, throwOnNotFound: true);
//         }

//         public static ExitCode FromName(string name, bool throwOnNotFound)
//         {
//             string name2 = name;
//             ExitCode exitCode = All.FirstOrDefault((ExitCode x) => x.Name.Equals(name2, StringComparison.OrdinalIgnoreCase));
//             if (exitCode == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("name", name2, "The name " + name2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return exitCode;
//         }

//         public static ExitCode FromDescription(string description)
//         {
//             return FromDescription(description, throwOnNotFound: true);
//         }

//         public static ExitCode FromDescription(string description, bool throwOnNotFound)
//         {
//             string description2 = description;
//             ExitCode exitCode = All.FirstOrDefault((ExitCode x) => x.Description.Equals(description2, StringComparison.OrdinalIgnoreCase));
//             if (exitCode == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("description", description2, "The description " + description2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return exitCode;
//         }

//         public static ExitCode FromShortName(string shortName)
//         {
//             return FromDescription(shortName, throwOnNotFound: true);
//         }

//         public static ExitCode FromShortName(string shortName, bool throwOnNotFound)
//         {
//             string shortName2 = shortName;
//             ExitCode exitCode = All.FirstOrDefault((ExitCode x) => x.ShortName.Equals(shortName2, StringComparison.OrdinalIgnoreCase));
//             if (exitCode == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("shortName", shortName2, "The ShortName " + shortName2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return exitCode;
//         }

//         public static bool TryFromShortName(string shortName, out ExitCode result)
//         {
//             return TryFromShortName(shortName, out result, throwOnNotFound: false);
//         }

//         public static bool TryFromShortName(string shortName, out ExitCode result, bool throwOnNotFound)
//         {
//             string shortName2 = shortName;
//             result = All.FirstOrDefault((ExitCode x) => x.ShortName.Equals(shortName2, StringComparison.OrdinalIgnoreCase));
//             if (result == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("shortName", shortName2, "The ShortName " + shortName2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return result != default(ExitCode);
//         }

//         public static bool TryFromValue(System.Enums.ExitCode value, out ExitCode result)
//         {
//             return TryFromValue(value, out result, throwOnNotFound: false);
//         }

//         public static bool TryFromValue(System.Enums.ExitCode value, out ExitCode result, bool throwOnNotFound)
//         {
//             result = All.FirstOrDefault((ExitCode x) => x.Value.Equals(value));
//             if (result == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("value", value, $"The value {value} is not a valid ENUMERATION_TYPE.");
//             }
//             return result != default(ExitCode);
//         }

//         public static bool TryFromId(int id, out ExitCode result)
//         {
//             return TryFromId(id, out result, throwOnNotFound: false);
//         }

//         public static bool TryFromId(int id, out ExitCode result, bool throwOnNotFound)
//         {
//             result = All.FirstOrDefault((ExitCode x) => x.Id == id);
//             if (result == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("id", id, $"The id {id} is not a valid ExitCode.");
//             }
//             return result != default(ExitCode);
//         }

//         public static bool TryFromName(string name, out ExitCode result)
//         {
//             return TryFromName(name, out result, throwOnNotFound: false);
//         }

//         public static bool TryFromName(string name, out ExitCode result, bool throwOnNotFound)
//         {
//             string name2 = name;
//             result = All.FirstOrDefault((ExitCode x) => x.Name.Equals(name2, StringComparison.OrdinalIgnoreCase));
//             if (result == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("name", name2, "The name " + name2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return result != default(ExitCode);
//         }

//         public static bool TryFromDescription(string description, out ExitCode result)
//         {
//             return TryFromDescription(description, out result, throwOnNotFound: false);
//         }

//         public static bool TryFromDescription(string description, out ExitCode result, bool throwOnNotFound)
//         {
//             string description2 = description;
//             result = All.FirstOrDefault((ExitCode x) => x.Description.Equals(description2, StringComparison.OrdinalIgnoreCase));
//             if (result == default(ExitCode) && throwOnNotFound)
//             {
//                 throw new ArgumentOutOfRangeException("description", description2, "The description " + description2 + " is not a valid ENUMERATION_TYPE.");
//             }
//             return result != default(ExitCode);
//         }

//         public static IEnumerable<ExitCode> GetAll()
//         {
//             return All;
//         }

//         public static IEnumerable<ExitCode> GetAllExcept(params ExitCode[] except)
//         {
//             return All.Except(except);
//         }

//         public static IEnumerable<ExitCode> GetAllExcept(params System.Enums.ExitCode[] except)
//         {
//             return All.Except(except.Select((System.Enums.ExitCode x) => FromValue(x)));
//         }

//         public static IEnumerable<ExitCode> GetAllExcept(params int[] except)
//         {
//             return All.Except(except.Select((int x) => FromId(x)));
//         }

//         public static IEnumerable<ExitCode> GetAllExcept(params string[] except)
//         {
//             return All.Except(except.Select((string x) => FromName(x)));
//         }

//         public TypeCode GetTypeCode()
//         {
//             return TypeCode.Object;
//         }

//         public bool ToBoolean(IFormatProvider? provider)
//         {
//             return Value != System.Enums.ExitCode.Success;
//         }

//         public byte ToByte(IFormatProvider? provider)
//         {
//             return Convert.ToByte(Value);
//         }

//         public char ToChar(IFormatProvider? provider)
//         {
//             return Convert.ToChar(Value);
//         }

//         public DateTime ToDateTime(IFormatProvider? provider)
//         {
//             return Convert.ToDateTime(Value);
//         }

//         public decimal ToDecimal(IFormatProvider? provider)
//         {
//             return Convert.ToDecimal(Value);
//         }

//         public double ToDouble(IFormatProvider? provider)
//         {
//             return Convert.ToDouble(Value);
//         }

//         public short ToInt16(IFormatProvider? provider)
//         {
//             return Convert.ToInt16(Value);
//         }

//         public int ToInt32(IFormatProvider? provider)
//         {
//             return Convert.ToInt32(Value);
//         }

//         public long ToInt64(IFormatProvider? provider)
//         {
//             return Convert.ToInt64(Value);
//         }

//         public sbyte ToSByte(IFormatProvider? provider)
//         {
//             return Convert.ToSByte(Value);
//         }

//         public float ToSingle(IFormatProvider? provider)
//         {
//             return Convert.ToSingle(Value);
//         }

//         public string ToString(IFormatProvider? provider)
//         {
//             return DisplayName;
//         }

//         public object ToType(Type conversionType, IFormatProvider? provider)
//         {
//             return Convert.ChangeType(Value, conversionType);
//         }

//         public ushort ToUInt16(IFormatProvider? provider)
//         {
//             return Convert.ToUInt16(Value);
//         }

//         public uint ToUInt32(IFormatProvider? provider)
//         {
//             return Convert.ToUInt32(Value);
//         }

//         public ulong ToUInt64(IFormatProvider? provider)
//         {
//             return Convert.ToUInt64(Value);
//         }

//         public int CompareTo(ExitCode other)
//         {
//             return Value.CompareTo(other.Value);
//         }

//         public int CompareTo(object? other)
//         {
//             if (!(other is ExitCode other2))
//             {
//                 throw new ArgumentOutOfRangeException("other", other, "The value provided was not of the correct type (ExitCode)");
//             }
//             return CompareTo(other2);
//         }

//         public string ToString(string? format, IFormatProvider? formatProvider)
//         {
//             return ToString();
//         }

//         public static ExitCode Parse(string s, IFormatProvider? format = null)
//         {
//             if (!TryParse(s, out var result))
//             {
//                 throw new ArgumentOutOfRangeException("s", s, "The value " + s + " is not a valid ENUMERATION_TYPE.");
//             }
//             return result;
//         }

//         public static bool TryParse(string s, out ExitCode result)
//         {
//             return (result = (TryFromName(s, out result) ? result : (TryFromDescription(s, out result) ? result : (TryFromShortName(s, out result) ? result : default(ExitCode))))) != default(ExitCode);
//         }

//         public static bool TryParse(string? s, IFormatProvider? format, out ExitCode result)
//         {
//             return (result = (TryFromName(s, out result) ? result : (TryFromDescription(s, out result) ? result : (TryFromShortName(s, out result) ? result : default(ExitCode))))) != default(ExitCode);
//         }

//         public TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute
//         {
//             return FieldInfo.GetCustomAttribute<TAttribute>();
//         }

//         public static bool operator <(ExitCode left, ExitCode right)
//         {
//             return left.CompareTo(right) < 0;
//         }

//         public static bool operator <=(ExitCode left, ExitCode right)
//         {
//             return left.CompareTo(right) <= 0;
//         }

//         public static bool operator >(ExitCode left, ExitCode right)
//         {
//             return left.CompareTo(right) > 0;
//         }

//         public static bool operator >=(ExitCode left, ExitCode right)
//         {
//             return left.CompareTo(right) >= 0;
//         }

//         [CompilerGenerated]
//         private bool PrintMembers(StringBuilder builder)
//         {
//             builder.Append("Value = ");
//             builder.Append(Value.ToString());
//             builder.Append(", Id = ");
//             builder.Append(Id.ToString());
//             builder.Append(", Name = ");
//             builder.Append((object?)Name);
//             builder.Append(", Description = ");
//             builder.Append((object?)Description);
//             builder.Append(", DisplayName = ");
//             builder.Append((object?)DisplayName);
//             builder.Append(", ShortName = ");
//             builder.Append((object?)ShortName);
//             builder.Append(", GroupName = ");
//             builder.Append((object?)GroupName);
//             builder.Append(", Order = ");
//             builder.Append(Order.ToString());
//             builder.Append(", Uri = ");
//             builder.Append((object?)Uri);
//             builder.Append(", Prompt = ");
//             builder.Append((object?)Prompt);
//             builder.Append(", FieldInfo = ");
//             builder.Append(FieldInfo);
//             return true;
//         }

//         [CompilerGenerated]
//         public static bool operator !=(ExitCode left, ExitCode right)
//         {
//             return !(left == right);
//         }

//         [CompilerGenerated]
//         public static bool operator ==(ExitCode left, ExitCode right)
//         {
//             return left.Equals(right);
//         }

//         [CompilerGenerated]
//         public override readonly int GetHashCode()
//         {
//             return ((((((((EqualityComparer<System.Enums.ExitCode>.Default.GetHashCode(Value) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Id)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Order)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Uri)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prompt);
//         }

//         [CompilerGenerated]
//         public override readonly bool Equals(object obj)
//         {
//             return obj is ExitCode && Equals((ExitCode)obj);
//         }

//         [CompilerGenerated]
//         public readonly bool Equals(ExitCode other)
//         {
//             return EqualityComparer<System.Enums.ExitCode>.Default.Equals(Value, other.Value) && EqualityComparer<int>.Default.Equals(Id, other.Id) && EqualityComparer<string>.Default.Equals(Name, other.Name) && EqualityComparer<string>.Default.Equals(Description, other.Description) && EqualityComparer<string>.Default.Equals(DisplayName, other.DisplayName) && EqualityComparer<string>.Default.Equals(ShortName, other.ShortName) && EqualityComparer<string>.Default.Equals(GroupName, other.GroupName) && EqualityComparer<int>.Default.Equals(Order, other.Order) && EqualityComparer<string>.Default.Equals(Uri, other.Uri) && EqualityComparer<string>.Default.Equals(Prompt, other.Prompt);
//         }
//     }
// }
