module UnMango.Docker.Container.Stop

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStop
type Stop = { Id: string; T: int option }

let init id = { Id = id; T = None }

type StopBuilder(id) =
    [<CustomOperation("t")>]
    member inline _.T(stop, t) = { stop with T = Some t }

    member _.Yield(_: unit) = init id

let stop id = StopBuilder(id)
