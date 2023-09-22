---
authors:
  - dgmjr
title: The DGMJR Interface Generator
modified: 2022-11-12-09:12:07
date: 2022-11-12-09:12:07
license: MIT
description: This package contains a code generator that creates partial interface declarations from extant classes.
---

# The DGMJR Interface Generator

This package contains a code generator that creates partial interface declarations from extant classes.

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
    <SourgGenerator Include="Dgmjr.InterfaceGenerator" />
  </IremGroup>
  ```
