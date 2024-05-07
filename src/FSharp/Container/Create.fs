module UnMango.Docker.Container.Create

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerCreate
type Create =
    { Name: string
      Platform: string option
      AttachStdin: bool
      AttachStdout: bool
      AttachStderr: bool
      Tty: bool
      OpenStdin: bool
      StdinOnce: bool
      Cmd: string list
      Env: string list
      Entrypoint: string list }

let init name =
    { Name = name
      Platform = None
      AttachStdin = false
      AttachStdout = false
      AttachStderr = false
      Tty = false
      OpenStdin = false
      StdinOnce = false
      Cmd = List.empty
      Env = List.empty
      Entrypoint = List.empty }

type CreateBuilder(name) =
    [<CustomOperation("attachStderr")>]
    member inline _.AttachStderr(create, stderr) = { create with AttachStderr = stderr }

    [<CustomOperation("attachStderr")>]
    member inline this.AttachStderr(create) = this.AttachStderr(create, true)

    [<CustomOperation("attachStdin")>]
    member inline _.AttachStdin(create, stdin) = { create with AttachStdin = stdin }

    [<CustomOperation("attachStdin")>]
    member inline this.AttachStdin(create) = this.AttachStdin(create, true)

    [<CustomOperation("attachStdout")>]
    member inline _.AttachStdout(create, stdout) = { create with AttachStdout = stdout }

    [<CustomOperation("attachStdout")>]
    member inline this.AttachStdout(create) = this.AttachStdout(create, true)

    [<CustomOperation("cmd")>]
    member inline _.Cmd(create, cmd) = { create with Cmd = cmd :: create.Cmd }

    [<CustomOperation("cmd")>]
    member inline _.Cmd(create, cmd) = { create with Cmd = cmd @ create.Cmd }

    [<CustomOperation("entrypoint")>]
    member inline _.Entrypoint(create, entrypoint) =
        { create with
            Entrypoint = entrypoint :: create.Entrypoint }

    [<CustomOperation("entrypoint")>]
    member inline _.Entrypoint(create, entrypoint) =
        { create with
            Entrypoint = entrypoint @ create.Entrypoint }

    [<CustomOperation("env")>]
    member inline _.Env(create, env) = { create with Env = env :: create.Env }

    [<CustomOperation("env")>]
    member inline _.Env(create, env) = { create with Env = env @ create.Env }

    [<CustomOperation("openStdin")>]
    member inline _.OpenStdin(create, stdin) = { create with OpenStdin = stdin }

    [<CustomOperation("openStdin")>]
    member inline this.OpenStdin(create) = this.OpenStdin(create, true)

    [<CustomOperation("platform")>]
    member inline _.Platform(create, platform) =
        { create with Platform = Some platform }

    [<CustomOperation("stdinOnce")>]
    member inline _.StdinOnce(create, stdin) = { create with StdinOnce = stdin }

    [<CustomOperation("stdinOnce")>]
    member inline this.StdinOnce(create) = this.StdinOnce(create, true)

    [<CustomOperation("tty")>]
    member inline _.Tty(create, tty) = { create with Tty = tty }

    [<CustomOperation("tty")>]
    member inline this.Tty(create) = this.Tty(create, true)

    member _.Yield(_: unit) = init name

let create name = CreateBuilder(name)
