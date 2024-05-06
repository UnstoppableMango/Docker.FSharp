module UnMango.Docker.Container.Wait

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerWait
type Wait =
    { Id: string; Condition: string option }

let create id = { Id = id; Condition = None }
