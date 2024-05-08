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

    member inline _.Yield(builder: Containers.AttachBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(builder: Containers.CreateBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(builder: Containers.RemoveBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(builder: Containers.StartBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(builder: Containers.StopBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(builder: Containers.WaitBuilder) =
        [ builder.Yield() |> builder.Run |> Container ]

    member inline _.Yield(image: Images.Action) = [ Image image ]

    member inline _.Yield(images: Images.Action list) = images |> List.map Image

    member inline _.Yield(builder: Images.CreateBuilder) =
        [ builder.Yield() |> builder.Run |> Image ]

    member inline _.Zero() = []

let docker = DockerBuilder()
