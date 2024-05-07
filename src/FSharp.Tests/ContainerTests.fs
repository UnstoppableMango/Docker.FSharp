module UnMango.Docker.Container.ContainerTests

open FsCheck.Xunit
open UnMango.Docker.Containers

[<Property>]
let ``AttachBuilder builds attach action`` i d l s n o e =
    let expected =
        { Id = i
          DetachKeys = Some d
          Logs = l
          Stream = s
          Stdin = n
          Stdout = o
          Stderr = e }

    let actual = attach i {
        detachKeys d
        logs l
        stream s
        stdin n
        stdout o
        stderr e
    }

    expected = actual

[<Property>]
let ``ContainerBuilder builds attach action`` id s =
    let expected = attach id { stream s }

    let actual = container { expected }

    match actual with
    | [ Attach x ] -> expected = x
    | _ -> false
