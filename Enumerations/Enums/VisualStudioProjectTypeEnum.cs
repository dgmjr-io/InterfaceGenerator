//
// VisualStudioProjectType.cs
//
//   Created: 2022-10-16-05:52:39
//   Modified: 2022-10-30-05:21:21
//
//   Author: David G. Mooore, Jr. <david@dgmjr.io>
//
//   Copyright © 2022-2023 David G. Mooore, Jr., All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Dgmjr.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dgmjr.s;

[GenerateEnumerationRecordStruct("VisualStudioProjectType")]
public enum VisualStudioProjectTypeEnum
{
    [Display(Name = "None")]
    [Guid("00000000-0000-0000-0000-00000000000")]
    [FileExtensions(Extensions = ".*")]
    None = 0,

    [Display("Generic")]
    [Guid("13B669BE-BB05-4DDF-9536-439F39A36129")]
    [FileExtension(".proj")]
    Generic,

    [Display(Name = "ASP.NET 5")]
    [Guid("8BB2217D-0F2D-49D1-97BC-3654ED321F3B")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNET5,

    [Display(Name = "ASP.NET MVC 1")]
    [Guid("603C0E0B-DB56-11DC-BE95-000D561079B0")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNETMVC1,

    [Display(Name = "ASP.NET MVC 2")]
    [Guid("F85E285D-A4E0-4152-9332-AB1D724D3325")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNETMVC2,

    [Display(Name = "ASP.NET MVC 3")]
    [Guid("E53F8FEA-EAE0-44A6-8774-FFD645390401")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNETMVC3,

    [Display(Name = "ASP.NET MVC 4")]
    [Guid("E3E379DF-F4C6-4180-9B81-6769533ABE47")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNETMVC4,
    [FileExtensions(Extensions = ".csproj,.vbproj")]

    [Display(Name = "ASP.NET MVC 5")]
    [Guid("349C5851-65DF-11DA-9384-00065B846F21")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ASPNETMVC5,

    [Display(Name = "C#")]
    [Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC")]
    [FileExtensions(Extensions = ".csproj")]
    CSharp,
    [Display(Name = "C++")]
    [Guid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942")]
    [FileExtensions(Extensions = ".vcxproj")]
    CPlusPlus,
    [Display(Name = "Database")]
    [Guid("A9ACE9BB-CECE-4E62-9AA4-C7E7C5BD2124")]
    [FileExtensions(Extensions = ".sqlproj")]
    Database,
    [Display(Name = "Database (other project types)")]
    [Guid("4F174C21-8C12-11D0-8340-0000F80270F8")]
    [FileExtensions(Extensions = ".dbproj")]
    DatabaseOtherProjectTypes,
    [Display(Name = "Deployment Cab")]
    [Guid("3EA9E505-35AC-4774-B492-AD1749C4943A")]
    [FileExtensions(Extensions = ".cab")]
    DeploymentCab,
    [Display(Name = "Deployment Merge Module")]
    [Guid("06A35CCD-C46D-44D5-987B-CF40FF872267")]
    DeploymentMergeModule,
    [Display(Name = "Deployment Setup")]
    [Guid("978C614F-708E-4E1A-B201-565925725DBA")]
    DeploymentSetup,
    [Display(Name = "Deployment Smart Device Cab")]
    [Guid("AB322303-2255-48EF-A496-5904EB18DA55")]
    [FileExtensions(Extensions = ".cab")]
    DeploymentSmartDeviceCab,
    [Display(Name = "Distributed System")]
    [Guid("F135691A-BF7E-435D-8960-F99683D2D49C")]
    DistributedSystem,
    [Display(Name = "Dynamics 2012 AX C# in AOT")]
    [Guid("BF6F8E12-879D-49E7-ADF0-5503146B24B8")]
    [FileExtensions(Extensions = ".csproj")]
    Dynamics2012AXCSharpinAOT,
    [Display(Name = "F#")]
    [Guid("F2A71F9B-5D33-465A-A702-920D77279786")]
    [FileExtensions(Extensions = ".fsproj")]
    FSharp,
    [Display(Name = "J#")]
    [Guid("E6FDF86B-F3D1-11D4-8576-0002A516ECE8")]
    [FileExtensions(Extensions = ".jsproj")]
    JSharp,
    [Display(Name = "Legacy (2003) Smart Device (C#)")]
    [Guid("20D4826A-C6FA-45DB-90F4-C717570B9F32")]
    [FileExtensions(Extensions = ".csproj")]
    Legacy2003SmartDeviceCSharp,
    [Display(Name = "Legacy (2003) Smart Device (VB.NET)")]
    [Guid("CB4CE8C6-1BDB-4DC7-A4D3-65A1999772F8")]
    [FileExtensions(Extensions = ".vbproj")]
    Legacy2003SmartDeviceVBNET,
    [Display(Name = "Micro Framework")]
    [Guid("b69e3092-b931-443c-abe7-7e7b65f2a37f")]
    MicroFramework,
    [Display(Name = "Model-View-Controller v2 (MVC 2)")]
    [Guid("F85E285D-A4E0-4152-9332-AB1D724D3325")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ModelViewControllerv2MVC2,
    [Display(Name = "Model-View-Controller v3 (MVC 3)")]
    [Guid("E53F8FEA-EAE0-44A6-8774-FFD645390401")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ModelViewControllerv3MVC3,
    [Display(Name = "Model-View-Controller v4 (MVC 4)")]
    [Guid("E3E379DF-F4C6-4180-9B81-6769533ABE47")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ModelViewControllerv4MVC4,
    [Display(Name = "Model-View-Controller v5 (MVC 5)")]
    [Guid("349C5851-65DF-11DA-9384-00065B846F21")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    ModelViewControllerv5MVC5,
    [Display(Name = "Mono for Android")]
    [Guid("EFBA0AD7-5A72-4C68-AF49-83D382785DCF")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    MonoforAndroid,
    [Display(Name = "MonoTouch")]
    [Guid("6BC8ED88-2882-458C-8E55-DFD12B67127B")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    MonoTouch,
    [Display(Name = "MonoTouch Binding")]
    [Guid("F5B4F3BC-B597-4E2B-B552-EF5D8A32436F")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    MonoTouchBinding,
    [Display(Name = "Portable Class Library")]
    [Guid("786C830F-07A1-408B-BD7F-6EE04809D6DB")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    PortableClassLibrary,
    [Display(Name = "Project Folders")]
    [Guid("66A26720-8FB5-11D2-AA7E-00C04F688DDE")]
    ProjectFolders,
    [Display(Name = "SharePoint (C#)")]
    [Guid("593B0543-81F6-4436-BA1E-4747859CAAE2")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    SharePointCSharp,
    [Display(Name = "SharePoint (VB.NET)")]
    [Guid("EC05E597-79D4-47f3-ADA0-324C4F7C7484")]
    [FileExtensions(Extensions = ".vbproj")]
    SharePointVBNET,
    [Display(Name = "SharePoint Workflow")]
    [Guid("F8810EC1-6754-47FC-A15F-DFABD2E3FA90")]
    SharePointWorkflow,
    [Display(Name = "Silverlight")]
    [Guid("A1591282-1198-4647-A2B1-27E5FF5F6F3B")]
    [FileExtensions(Extensions = ".xaml")]
    Silverlight,
    [Display(Name = "Smart Device (C#)")]
    [Guid("4D628B5B-2FBC-4AA6-8C16-197242AEB884")]
    [FileExtensions(Extensions = ".csproj")]
    SmartDeviceCSharp,
    [Display(Name = "Smart Device (VB.NET)")]
    [Guid("68B1623D-7FB9-47D8-8664-7ECEA3297D4F")]
    [FileExtensions(Extensions = ".vbproj")]
    SmartDeviceVBNET,
    [Display(Name = "Solution Folder")]
    [Guid("2150E333-8FDC-42A3-9474-1A3956D46DE8")]
    SolutionFolder,
    [Display(Name = "Test")]
    [Guid("3AC096D0-A1C2-E12C-1390-A8335801FDAB")]
    Test,
    [Display(Name = "Universal Windows Class Library")]
    [Guid("A5A43C5B-DE2A-4C0C-9213-0A381AF9435A")]
    UniversalWindowsClassLibrary,
    [Display(Name = "VB.NET")]
    [Guid("F184B08F-C81C-45F6-A57F-5ABD9991F28F")]
    VBNET,
    [Display(Name = "Visual Database Tools")]
    [Guid("C252FEB5-A946-4202-B1D4-9916A0590387")]
    VisualDatabaseTools,
    [Display(Name = "Visual Studio 2015 Installer Project Extension")]
    [Guid("54435603-DBB4-11D2-8724-00A0C9A8B90C")]
    VisualStudio2015InstallerProjectExtension,
    [Display(Name = "Visual Studio Tools for Applications (VSTA)")]
    [Guid("A860303F-1F3F-4691-B57E-529FC101A107")]
    VisualStudioToolsforApplicationsVSTA,
    [Display(Name = "Visual Studio Tools for Office (VSTO)")]
    [Guid("BAA0C2D2-18E2-41B9-852F-F413020CAA33")]
    VisualStudioToolsforOfficeVSTO,
    [Display(Name = "Web Application")]
    [Guid("349C5851-65DF-11DA-9384-00065B846F21")]
    [FileExtensions(Extensions = ".asax")]
    WebApplication,
    [Display(Name = "Web Site")]
    [Guid("E24C65DC-7377-472B-9ABA-BC803B73C61A")]
    WebSite,
    [Display(Name = "Windows (C#)")]
    [Guid("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC")]
    [FileExtensions(Extensions = ".csproj")]
    WindowsCSharp,
    [Display(Name = "Windows (VB.NET)")]
    [Guid("F184B08F-C81C-45F6-A57F-5ABD9991F28F")]
    [FileExtensions(Extensions = "vbproj")]
    WindowsVBNET,
    [Display(Name = "Windows (Visual C++)")]
    [Guid("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942")]
    [FileExtensions(Extensions = ".vcxproj")]
    WindowsVisualCPlusPlus,
    [Display(Name = "Windows Communication Foundation (WCF)")]
    [Guid("3D9AD99F-2412-4246-B90B-4EAA41C64699")]
    WindowsCommunicationFoundationWCF,
    [Display(Name = "Windows Phone 8/8.1 Blank/Hub/Webview App")]
    [Guid("76F1466A-8B6D-4E39-A767-685A06062A39")]
    WindowsPhone8_81Blank_Hub_WebviewApp,
    [Display(Name = "Windows Phone 8/8.1 App (C#)")]
    [Guid("C089C8C0-30E0-4E22-80C0-CE093F111A43")]
    [FileExtensions(Extensions = ".csproj")]
    WindowsPhone8_81AppCSharp,
    [Display(Name = "Windows Phone 8/8.1 App (VB.NET)")]
    [Guid("DB03555F-0C8B-43BE-9FF9-57896B3C5E56")]
    [FileExtensions(Extensions = ".vbproj")]
    WindowsPhone8_81AppVBNET,
    [Display(Name = "Windows Presentation Foundation (WPF)")]
    [Guid("60DC8134-EBA5-43B8-BCC9-BB4BC16C2548")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    WindowsPresentationFoundationWPF,
    [Display(Name = "Windows Store (Metro) Apps & Components")]
    [Guid("BC8A1FFA-BEE3-4634-8014-F334798102B3")]
    WindowsStoreMetroAppsAndComponents,
    [Display(Name = "Workflow (C#)")]
    [Guid("14822709-B5A1-4724-98CA-57A101D1B079")]
    WorkflowCSharp,
    [Display(Name = "Workflow (VB.NET)")]
    [Guid("D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8")]
    [FileExtensions(Extensions = ".vbproj")]
    WorkflowVBNET,
    [Display(Name = "Workflow Foundation")]
    [Guid("32F31D43-81CC-4C15-9DE6-3FC5453562B6")]
    WorkflowFoundation,
    [Display(Name = "Xamarin.Android")]
    [Guid("EFBA0AD7-5A72-4C68-AF49-83D382785DCF")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    XamarinAndroid,
    [Display(Name = "Xamarin.iOS")]
    [Guid("6BC8ED88-2882-458C-8E55-DFD12B67127B")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    XamariniOS,
    [Display(Name = "XNA (Windows)")]
    [Guid("6D335F3A-9D43-41b4-9D22-F6F17C4BE596")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    XNAWindows,
    [Display(Name = "XNA (XBox)")]
    [Guid("2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    XNAXBox,
    [Display(Name = "XNA (Zune)")]
    [Guid("D399B71A-8929-442a-A9AC-8BEC78BB2433")]
    [FileExtensions(Extensions = ".csproj,.vbproj")]
    XNAZune
}
