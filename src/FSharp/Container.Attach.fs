module UnMango.Docker.ContainerAttach

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerAttach
type Attach =
    { Id: string
      DetachKeys: string option
      Logs: bool
      Stream: bool
      Stdin: bool
      Stdout: bool
      Stderr: bool }

let create id =
    { Id = id
      DetachKeys = None
      Logs = false
      Stream = false
      Stdin = false
      Stdout = false
      Stderr = false }
