---
author: David G. Moore, Jr.
author_email: david@dgmjr.io
title: README.md
lastmod: 2023-03-24-05:58:52
created: 2023-03-24-05:58:52
license: MIT
keywords:
  - dgmjr
tags:
  - dgmjr
categories:
  - dgmjr
---

# Interface Generator

You can use this library to generate an interface from an extant class.  Let's say you want to create an interface for the DbContext class.  You can do that with the following code:

```csharp
[InterfaceGenerator(typeof(Microsoft.EntityFrameworkCore.DbContext))]
public partial interface IDbContext
{
}
```

Make sure to mark the interface as `partial` or it won't work.
