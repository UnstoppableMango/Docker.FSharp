module UnMango.Docker.ContainerStart

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStart
type Start =
    { Id: string
      DetachKeys: string option }

let create id = { Id = id; DetachKeys = None }
