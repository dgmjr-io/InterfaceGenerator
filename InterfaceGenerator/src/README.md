---
authors:
  - dgmjr
title: The DGMJR Interface Generator
lastmod: 2023-10-08-09T12:07:00.0000Z
date: 2022-11-12-09T12:07:00.0000Z
license: MIT
description: This package contains a code generator that creates partial interface declarations from extant classes.
type: readme
slug: dgmjr-interface-generator
---

# The DGMJR Interface Generator

This package contains a code generator that creates partial interface declarations from extant classes, struct, or interface.

!!! Usage

=== "Without the DGMJR SDK"

  Add the `PackageReference`:

  === "Using `dotnet add package`"

    ```shell
    dotnet add package dgmjr.interfacegenerator --version <VERSION>
    ```

  === "Using PowerShell `Install-Package`"

    ```pwsh
    Install-Package Dgmjr.InterfaceGenerator
    ```

  === "Using `PackageReference`"

    ```xml
    <ItemGroup>
      <PackageReference Include="Dgmjr.InterfaceGenerator" IncludeAssets="Build;Analyzers" ExcludeAssets="Runtime;Native;ContentFiles;" />
    </ItemGroup>

    ```

=== "With the [DGMJR SDK](https://github.com/dgmjr-io/DgmjrSdk):

  When using the [DGMJR SDK](https://github.com/dgmjr-io/DgmjrSdk), you can add a `SourceGenerator` item like so:

  ```xml
  <IremGroup>
    <SourceGeneratorPackageReference Include="Dgmjr.InterfaceGenerator" />
  </IremGroup>
  ```
