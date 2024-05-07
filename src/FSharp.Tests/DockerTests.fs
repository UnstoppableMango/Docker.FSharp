module UnMango.Docker.DockerTests

open FsCheck.Xunit

[<Property>]
let ``DockerBuilder builds container action`` (expected: Containers.Action) =
    let actual = docker { expected }

    match actual with
    | [ Container x ] -> expected = x
    | _ -> false

[<Property>]
let ``DockerBuilder builds image action`` (expected: Images.Action) =
    let actual = docker { expected }

    match actual with
    | [ Image x ] -> expected = x
    | _ -> false
