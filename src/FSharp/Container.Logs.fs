module UnMango.Docker.ContainerLogs

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

let create id =
    { Id = id
      Follow = false
      Stdout = false
      Stderr = false
      Since = 0
      Until = 0
      Timestamps = false
      Tail = None }
