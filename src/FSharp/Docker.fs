[<AutoOpen>]
module UnMango.Docker.Docker

type Action =
    | Image of Images.Action
    | Container of Containers.Action

type DockerBuilder() =
    member inline _.Combine(actions: Action list, xs: Action list) = actions @ xs
    member inline _.Delay(f) = f ()
    member inline _.Yield(container: Containers.Action) = [ Container container ]
    member inline _.Yield(containers: Containers.Action list) = containers |> List.map Container
    member inline _.Yield(image: Images.Action) = [ Image image ]
    member inline _.Yield(images: Images.Action list) = images |> List.map Image
    member inline _.Zero() = []

let docker = DockerBuilder()
