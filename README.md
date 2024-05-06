# Docker.FSharp

[![Build](https://img.shields.io/github/actions/workflow/status/UnstoppableMango/Docker.FSharp/main.yml?branch=main)](https://github.com/UnstoppableMango/Docker.FSharp/actions)
[![Codecov](https://img.shields.io/codecov/c/github/UnstoppableMango/Docker.FSharp)](https://app.codecov.io/gh/UnstoppableMango/Docker.FSharp)
[![GitHub Release](https://img.shields.io/github/v/release/UnstoppableMango/Docker.FSharp)](https://github.com/UnstoppableMango/Docker.FSharp/releases)
[![NuGet Version](https://img.shields.io/nuget/v/UnMango.Docker.FSharp)](https://nuget.org/packages/UnMango.Docker.FSharp)
[![NuGet Downloads](https://img.shields.io/nuget/dt/UnMango.Docker.FSharp)](https://nuget.org/packages/UnMango.Docker.FSharp)

This library defines a computation expression that can be used to describe Docker operations.

Not to be confused with [Docker.DotNet.FSharp](https://github.com/UnstoppableMango/Docker.DotNet.FSharp)!

## Install

- [NuGet](https://nuget.org/packages/UnMango.Docker.FSharp): `dotnet add package UnMango.Docker.FSharp`
- [GitHub Packages](https://github.com/UnstoppableMango/Docker.FSharp/pkgs/nuget/UnMango.Docker.FSharp): `dotnet add package UnMango.Docker.FSharp -s github`
  - [Authenticating to GitHub Packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#authenticating-to-github-packages)
  - [Installing from GitHub Packages](https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry#installing-a-package)

## Usage

The majority of the library is still a work in progress.

Right now an image builder is available for defining a create image operation.

```fsharp
let myImage = image {
    create {
        fromImage "ubuntu"
        tag: "latest"
    }
}
```

It's worth noting that no interaction with the docker API is actually performed.
The intent is to provide a definition that a client can use to perform operations.

## Q/A

### Idiomatic? This looks nothing like the F# I write!

If something looks off please open an issue! I've only recently been diving further into the F# ecosystem.
