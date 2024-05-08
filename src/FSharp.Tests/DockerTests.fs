module UnMango.Docker.DockerTests

open FsCheck.Xunit
open UnMango.Docker.Containers
open UnMango.Docker.Images

[<Property>]
let ``DockerBuilder builds container action`` (expected: Containers.Action) =
    let actual = docker { expected }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder builds image action`` (expected: Images.Action) =
    let actual = docker { expected }

    [ Image expected ] = actual

[<Property>]
let ``DockerBuilder handles empty image create`` () =
    let expected = Create.empty |> Action.Create

    let actual = docker { Image.create }

    [ Image expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container attach`` id =
    let expected = Attach.init id |> Containers.Action.Attach

    let actual = docker { Container.attach id }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container create`` id =
    let expected = Create.init id |> Containers.Action.Create

    let actual = docker { Container.create id }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container remove`` id =
    let expected = Remove.init id |> Containers.Action.Remove

    let actual = docker { Container.remove id }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container start`` id =
    let expected = Start.init id |> Containers.Action.Start

    let actual = docker { Container.start id }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container stop`` id =
    let expected = Stop.init id |> Containers.Action.Stop

    let actual = docker { Container.stop id }

    [ Container expected ] = actual

[<Property>]
let ``DockerBuilder handles empty container wait`` id =
    let expected = Wait.init id |> Containers.Action.Wait

    let actual = docker { Container.wait id }

    [ Container expected ] = actual
