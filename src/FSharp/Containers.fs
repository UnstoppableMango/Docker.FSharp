module UnMango.Docker.Containers

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
    let create id =
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
      Entrypoint: string list }

module Create =
    let create name =
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

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerKill
type Kill = { Id: string; Signal: string option }

module Kill =
    let create id = { Id = id; Signal = None }

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
    let create id =
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
    let create id =
        { Id = id
          V = false
          Force = false
          Link = false }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStart
type Start =
    { Id: string
      DetachKeys: string option }

module Start =
    let create id = { Id = id; DetachKeys = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStop
type Stop = { Id: string; T: int option }

module Stop =
    let create id = { Id = id; T = None }

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerWait
type Wait =
    { Id: string; Condition: string option }

module Wait =
    let create id = { Id = id; Condition = None }

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
