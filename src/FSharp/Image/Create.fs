[<AutoOpen>]
module UnMango.Docker.Image.Create

// https://docs.docker.com/engine/api/v1.41/#tag/Image/operation/ImageCreate
type Create =
    { FromImage: string option
      FromSrc: string option
      Repo: string option
      Tag: string option
      Message: string option
      Changes: string list }

let empty: Create =
    { FromImage = None
      FromSrc = None
      Repo = None
      Tag = None
      Message = None
      Changes = List.empty }

type CreateBuilder() =
    [<CustomOperation("change")>]
    member inline _.Change(create, change) =
        { create with
            Changes = change :: create.Changes }

    [<CustomOperation("changes")>]
    member inline _.Changes(create, changes) =
        { create with
            Changes = changes @ create.Changes }

    [<CustomOperation("fromImage")>]
    member inline _.FromImage(create, image) = { create with FromImage = Some image }

    [<CustomOperation("fromSrc")>]
    member inline _.FromSrc(create, src) = { create with FromSrc = Some src }

    [<CustomOperation("message")>]
    member inline _.Message(create, message) = { create with Message = Some message }

    [<CustomOperation("repo")>]
    member inline _.Repo(create, repo) = { create with Repo = Some repo }

    [<CustomOperation("tag")>]
    member inline _.Tag(create, tag) = { create with Tag = Some tag }

    member inline _.Yield(_: unit) = empty

let create = CreateBuilder()
