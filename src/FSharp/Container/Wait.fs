module UnMango.Docker.Container.Wait

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerWait
type Wait =
    { Id: string; Condition: string option }

let init id = { Id = id; Condition = None }

type WaitBuilder(id) =
    [<CustomOperation("condition")>]
    member inline _.Condition(wait, condition) =
        { wait with Condition = Some condition }

    member _.Yield(_: unit) = init id

let wait id = WaitBuilder(id)
