module UnMango.Docker.Container.Stop

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStop
type Stop = { Id: string; T: int option }

let create id = { Id = id; T = None }
