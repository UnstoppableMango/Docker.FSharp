module UnMango.Docker.Container.ContainerTests

open FsCheck.Xunit
open UnMango.Docker.Container.Create
open UnMango.Docker.Containers

[<Property>]
let ``AttachBuilder builds attach action`` expected d =
    let expected = { expected with DetachKeys = Some d }

    let actual = attach expected.Id {
        detachKeys d
        logs expected.Logs
        stream expected.Stream
        stdin expected.Stdin
        stdout expected.Stdout
        stderr expected.Stderr
    }

    expected = actual

[<Property>]
let ``AttachBuilder builds attach action with unary operations`` i d =
    let expected =
        { Id = i
          DetachKeys = Some d
          Logs = true
          Stream = true
          Stdin = true
          Stdout = true
          Stderr = true }

    let actual = attach i {
        detachKeys d
        logs
        stream
        stdin
        stdout
        stderr
    }

    expected = actual

[<Property>]
let ``CreateBuilder builds create action`` expected p =
    let expected = { expected with Platform = Some p }

    let actual = create expected.Name {
        attachStderr expected.AttachStderr
        attachStdin expected.AttachStdin
        attachStdout expected.AttachStdout
        cmd expected.Cmd
        entrypoint expected.Entrypoint
        env expected.Env
        openStdin expected.OpenStdin
        stdinOnce expected.StdinOnce
        tty expected.Tty
        platform p
    }

    expected = actual

[<Property>]
let ``ContainerBuilder builds attach action`` id s =
    let expected = attach id { stream s }

    let actual = container { expected }

    match actual with
    | [ Attach x ] -> expected = x
    | _ -> false

[<Property>]
let ``ContainerBuilder builds create action`` name =
    let expected = create name { tty }

    let actual = container { expected }

    match actual with
    | [ Create x ] -> expected = x
    | _ -> false
