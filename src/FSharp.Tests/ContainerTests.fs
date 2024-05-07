module UnMango.Docker.Container.ContainerTests

open FsCheck.Xunit
open UnMango.Docker.Containers
open UnMango.Docker.Containers.Container

[<Property>]
let ``AttachBuilder builds attach action`` (expected: Attach) d =
    let expected = { expected with DetachKeys = Some d }

    let actual = attach expected.Id {
        detachKeys d
        logs expected.Logs
        stream expected.Stream
        stdin expected.Stdin
        stdout expected.Stdout
        stderr expected.Stderr
    }

    Attach expected = actual

[<Property>]
let ``AttachBuilder builds attach action with unary operations`` expected d =
    let expected =
        { expected with
            DetachKeys = Some d
            Logs = true
            Stream = true
            Stdin = true
            Stdout = true
            Stderr = true }

    let actual = attach expected.Id {
        detachKeys d
        logs
        stream
        stdin
        stdout
        stderr
    }

    Attach expected = actual

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

    Create expected = actual

[<Property>]
let ``CreateBuilder builds create action with unary operations`` expected p =
    let expected =
        { expected with
            Platform = Some p
            AttachStderr = true
            AttachStdin = true
            AttachStdout = true
            OpenStdin = true
            StdinOnce = true
            Tty = true }

    let actual = create expected.Name {
        attachStderr
        attachStdin
        attachStdout
        cmd expected.Cmd
        entrypoint expected.Entrypoint
        env expected.Env
        openStdin
        stdinOnce
        tty
        platform p
    }

    Create expected = actual

[<Property>]
let ``RemoveBuilder builds remove action`` (expected: Remove) =
    let actual = remove expected.Id {
        force expected.Force
        link expected.Link
        v expected.V
    }

    Remove expected = actual

[<Property>]
let ``RemoveBuilder builds remove action with unary operations`` expected =
    let expected =
        { expected with
            Force = true
            Link = true
            V = true }

    let actual = remove expected.Id {
        force
        link
        v
    }

    Remove expected = actual

[<Property>]
let ``StartBuilder builds start action`` (expected: Start) d =
    let expected = { expected with DetachKeys = Some d }

    let actual = start expected.Id { detachKeys d }

    Start expected = actual

[<Property>]
let ``StopBuilder builds start action`` (expected: Stop) d =
    let expected = { expected with T = Some d }

    let actual = stop expected.Id { t d }

    Stop expected = actual

[<Property>]
let ``WaitBuilder builds wait action`` (expected: Wait) d =
    let expected = { expected with Condition = Some d }

    let actual = wait expected.Id { condition d }

    Wait expected = actual
