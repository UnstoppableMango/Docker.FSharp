module UnMango.Docker.Container.Remove

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerDelete
type Remove =
    { Id: string
      V: bool
      Force: bool
      Link: bool }

let init id =
    { Id = id
      V = false
      Force = false
      Link = false }

type RemoveBuilder(id) =
    [<CustomOperation("force")>]
    member inline _.Force(remove, force) = { remove with Force = force }

    [<CustomOperation("force")>]
    member inline this.Force(remove) = this.Force(remove, true)

    [<CustomOperation("link")>]
    member inline _.Link(remove, link) = { remove with Link = link }

    [<CustomOperation("link")>]
    member inline this.Link(remove) = this.Link(remove, true)

    [<CustomOperation("v")>]
    member inline _.V(remove, v) = { remove with V = v }

    [<CustomOperation("v")>]
    member inline this.V(remove) = this.V(remove, true)

    member _.Yield(_: unit) = init id

let remove id = RemoveBuilder(id)
