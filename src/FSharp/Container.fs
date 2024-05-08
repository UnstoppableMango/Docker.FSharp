namespace UnMango.Docker.Containers

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerAttach
type Attach =
    { Id: string
      DetachKeys: string option
      Logs: bool
      Stream: bool
      Stdin: bool
      Stdout: bool
      Stderr: bool }

module Attach =
    let init id =
        { Id = id
          DetachKeys = None
          Logs = false
          Stream = false
          Stdin = false
          Stdout = false
          Stderr = false }

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
      Entrypoint: string list
      Image: string option
      WorkingDir: string option
      ExposedPorts: Map<string, unit> }

module Create =
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
          Entrypoint = List.empty
          Image = None
          WorkingDir = None
          ExposedPorts = Map.empty }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerKill
type Kill = { Id: string; Signal: string option }

module Kill =
    let init id = { Id = id; Signal = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerLogs
type Logs =
    { Id: string
      Follow: bool
      Stdout: bool
      Stderr: bool
      Since: int
      Until: int
      Timestamps: bool
      Tail: string option }

module Logs =
    let init id =
        { Id = id
          Follow = false
          Stdout = false
          Stderr = false
          Since = 0
          Until = 0
          Timestamps = false
          Tail = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerDelete
type Remove =
    { Id: string
      V: bool
      Force: bool
      Link: bool }

module Remove =
    let init id =
        { Id = id
          V = false
          Force = false
          Link = false }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStart
type Start =
    { Id: string
      DetachKeys: string option }

module Start =
    let init id = { Id = id; DetachKeys = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStop
type Stop = { Id: string; T: int option }

module Stop =
    let init id = { Id = id; T = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerWait
type Wait =
    { Id: string; Condition: string option }

module Wait =
    let init id = { Id = id; Condition = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container
type Action =
    | List
    | Create of Create
    | Inspect
    | ListProcesses
    | Logs of Logs
    | FileSystemChanges
    | Export
    | Stats
    | ResizeTty
    | Start of Start
    | Stop of Stop
    | Restart
    | Kill of Kill
    | Update
    | Rename
    | Pause
    | Unpause
    | Attach of Attach
    | AttachWebSocket
    | Wait of Wait
    | Remove of Remove
    | Files
    | Archive
    | ExtractArchive
    | Delete

type AttachBuilder(id: string) =
    [<CustomOperation("detachKeys")>]
    member inline _.DetachKeys(attach: Attach, keys) = { attach with DetachKeys = Some keys }

    [<CustomOperation("logs")>]
    member inline _.Logs(attach, logs) = { attach with Logs = logs }

    [<CustomOperation("logs")>]
    member inline this.Logs(attach) = this.Logs(attach, true)

    member inline _.Run(action: Attach) = Attach action

    [<CustomOperation("stderr")>]
    member inline _.Stderr(attach: Attach, stderr) = { attach with Stderr = stderr }

    [<CustomOperation("stderr")>]
    member inline this.Stderr(attach) = this.Stderr(attach, true)

    [<CustomOperation("stdin")>]
    member inline _.Stdin(attach, stdin) = { attach with Stdin = stdin }

    [<CustomOperation("stdin")>]
    member inline this.Stdin(attach) = this.Stdin(attach, true)

    [<CustomOperation("stdout")>]
    member inline _.Stdout(attach: Attach, stdout) = { attach with Stdout = stdout }

    [<CustomOperation("stdout")>]
    member inline this.Stdout(attach) = this.Stdout(attach, true)

    [<CustomOperation("stream")>]
    member inline _.Stream(attach, stream) = { attach with Stream = stream }

    [<CustomOperation("stream")>]
    member inline this.Stream(attach) = this.Stream(attach, true)

    member _.Yield(_: unit) = Attach.init id

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

    [<CustomOperation("exposedPort")>]
    member inline _.ExposedPort(create, port) =
        { create with
            ExposedPorts = create.ExposedPorts |> Map.add port () }

    [<CustomOperation("exposedPorts")>]
    member inline _.ExposedPorts(create, ports) = { create with ExposedPorts = ports }

    [<CustomOperation("exposedPorts")>]
    member inline _.ExposedPorts(create, ports) =
        let kv x = (x, ())
        let folder acc key value = Map.add key value acc
        let (+) = List.map kv >> Map.ofList >> Map.fold folder

        { create with
            ExposedPorts = ports + create.ExposedPorts }

    [<CustomOperation("image")>]
    member inline _.Image(create, image) = { create with Image = Some image }

    [<CustomOperation("openStdin")>]
    member inline _.OpenStdin(create, stdin) = { create with OpenStdin = stdin }

    [<CustomOperation("openStdin")>]
    member inline this.OpenStdin(create) = this.OpenStdin(create, true)

    [<CustomOperation("platform")>]
    member inline _.Platform(create, platform) =
        { create with Platform = Some platform }

    member _.Run(action: Create) = Create action

    [<CustomOperation("stdinOnce")>]
    member inline _.StdinOnce(create, stdin) = { create with StdinOnce = stdin }

    [<CustomOperation("stdinOnce")>]
    member inline this.StdinOnce(create) = this.StdinOnce(create, true)

    [<CustomOperation("tty")>]
    member inline _.Tty(create, tty) = { create with Tty = tty }

    [<CustomOperation("tty")>]
    member inline this.Tty(create) = this.Tty(create, true)

    [<CustomOperation("workingDir")>]
    member inline _.WorkingDir(create, dir) = { create with WorkingDir = Some dir }

    member _.Yield(_: unit) = Create.init name

type RemoveBuilder(id) =
    [<CustomOperation("force")>]
    member inline _.Force(remove, force) = { remove with Force = force }

    [<CustomOperation("force")>]
    member inline this.Force(remove) = this.Force(remove, true)

    [<CustomOperation("link")>]
    member inline _.Link(remove, link) = { remove with Link = link }

    [<CustomOperation("link")>]
    member inline this.Link(remove) = this.Link(remove, true)

    member inline _.Run(action: Remove) = Remove action

    [<CustomOperation("v")>]
    member inline _.V(remove, v) = { remove with V = v }

    [<CustomOperation("v")>]
    member inline this.V(remove) = this.V(remove, true)

    member _.Yield(_: unit) = Remove.init id

type StartBuilder(id) =
    [<CustomOperation("detachKeys")>]
    member inline _.DetachKeys(start: Start, keys) = { start with DetachKeys = Some keys }

    member _.Run(action: Start) = Start action

    member _.Yield(_: unit) = Start.init id

type StopBuilder(id) =
    member inline _.Run(action: Stop) = Stop action

    [<CustomOperation("t")>]
    member inline _.T(stop, t) = { stop with T = Some t }

    member _.Yield(_: unit) = Stop.init id

type WaitBuilder(id) =
    [<CustomOperation("condition")>]
    member inline _.Condition(wait, condition) =
        { wait with Condition = Some condition }

    member _.Run(action: Wait) = Wait action

    member _.Yield(_: unit) = Wait.init id

module Container =
    let attach id = AttachBuilder(id)
    let create name = CreateBuilder(name)
    let remove id = RemoveBuilder(id)
    let start id = StartBuilder(id)
    let stop id = StopBuilder(id)
    let wait id = WaitBuilder(id)
