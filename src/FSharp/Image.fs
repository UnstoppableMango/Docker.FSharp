namespace UnMango.Docker.Images

// https://docs.docker.com/engine/api/v1.41/#tag/Image/operation/ImageCreate
type Create =
    { FromImage: string option
      FromSrc: string option
      Repo: string option
      Tag: string option
      Message: string option
      Changes: string list }

// https://docs.docker.com/engine/api/v1.41/#tag/Image
type Action =
    | List
    | Build
    | DeleteBuilderCache
    | Create of Create
    | Inspect
    | History
    | Push
    | Tag
    | Remove
    | Search
    | DeleteUnused
    | CreateFromContainer
    | Export
    | ExportAll
    | Import

module Create =
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

    member inline _.Run(action: Create) = Create action

    [<CustomOperation("tag")>]
    member inline _.Tag(create, tag) = { create with Tag = Some tag }

    member inline _.Yield(_: unit) = Create.empty

module Image =
    let create = CreateBuilder()
