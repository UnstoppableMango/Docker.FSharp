module UnMango.Docker.Container.Kill

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerKill
type Kill = { Id: string; Signal: string option }

let create id = { Id = id; Signal = None }
