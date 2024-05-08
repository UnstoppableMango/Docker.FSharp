module UnMango.Docker.DockerTests

open FsCheck.Xunit
open UnMango.Docker.Containers
open UnMango.Docker.Images

[<Property>]
let ``DockerBuilder builds container action`` (expected: Containers.Action) =
    let actual = docker { expected }

    [ Container expected ] = actual
    | [ Container x ] -> expected = x
    | _ -> false

[<Property>]
let ``DockerBuilder builds image action`` (expected: Images.Action) =
    let actual = docker { expected }

    match actual with
    | [ Image x ] -> expected = x
    | _ -> false

[<Property>]
let ``DockerBuilder preconfigures container from image`` name =
    let actual = docker {
        Image.create { fromImage "" }
        Container.create name { tty }
    }

    match actual with
    | [ Container (Containers.Create x); _ ] -> x
    | _ -> false
