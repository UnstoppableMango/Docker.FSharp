[<AutoOpen>]
module UnMango.Docker.Image

open ImageCreate

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

type ImageBuilder() =
    member inline _.Combine(actions: Action list, xs: Action list) = actions @ xs
    member inline _.Delay(f) = f ()
    member inline _.Yield(create: Create) = [ Create create ]
    member inline _.Zero() = []

let image = ImageBuilder()
