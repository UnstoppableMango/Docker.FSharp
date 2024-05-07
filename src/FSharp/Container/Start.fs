module UnMango.Docker.Container.Start

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerStart
type Start =
    { Id: string
      DetachKeys: string option }

let init id = { Id = id; DetachKeys = None }

type StartBuilder(id) =
    [<CustomOperation("detachKeys")>]
    member inline _.DetachKeys(start: Start, keys) = { start with DetachKeys = Some keys }

    member _.Yield(_: unit) = init id

let start id = StartBuilder(id)
