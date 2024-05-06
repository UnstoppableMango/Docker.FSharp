module UnMango.Docker.Container.Remove

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerDelete
type Remove =
    { Id: string
      V: bool
      Force: bool
      Link: bool }

let create id =
    { Id = id
      V = false
      Force = false
      Link = false }
