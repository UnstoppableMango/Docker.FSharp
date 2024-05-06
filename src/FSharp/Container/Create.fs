module UnMango.Docker.ContainerCreate

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
