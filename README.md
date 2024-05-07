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

Currently, a very basic series of image and container operations can be defined using the `docker` builder.

```fsharp
let dockerActions = docker {
    Image.create {
        fromImage "ubuntu"
        tag "latest"
    }
    Container.create "my-container" {
        entrypoint "bash"
    }
}
```

It's worth noting that no interaction with the docker API is actually performed.
The intent is to provide the ability to describe operations that a client can consume to perform operations.

The sister library, [Docker.DotNet.FSharp](https://github.com/UnstoppableMango/Docker.DotNet.FSharp), is one such consumer that provides `Docker.run` to execute operations using `Docker.DotNet`.

## Development

At a minimum, the [.NET SDK](https://dotnet.microsoft.com) is required.
At the time of writing this project is built with .NET 9.0 which you can find [here](https://dotnet.microsoft.com/download/dotnet/9.0).
The specific version is defined in [global.json](./global.json).

It might be a good idea to install [make](https://www.gnu.org/software/make/) but it is not required.

If you do however, you can just clone the repo and run `make`.

This will:

- Restore dependencies
- Restore tools (like fantomas)
- Build the solution
- Run the linter
- Run tests

There are a number of make targets for common tasks such as `build`, `test`, `lint`, `format` and `pack`.

You can also use the `dotnet` CLI like normal.

```shell
dotnet build
dotnet test
```

A solution file is provided for IDE's that support it, such as Rider, Visual Studio, and Ionide.

If you prefer a devcontainer, there is a barebones definition in `.devcontainer/devcontainer.json`.
It's not fully configured yet, so you may need to install some tools manually.

You can run `make devcontainer` to build the container with the devcontainers-cli.
This command requires [Node.js](https://nodejs.org) and `npx` (shipped with node).

## Q/A

### Why make?

It makes me feel smarter than I actually am.

### Why use the preview SDK?

I like living on the edge.

### The name seems like it was chosen deliberately to be confusing.

That's not a question, get off my back man.
