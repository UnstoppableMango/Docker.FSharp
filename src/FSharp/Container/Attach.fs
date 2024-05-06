[<AutoOpen>]
module UnMango.Docker.Container.Attach

// https://docs.docker.com/engine/api/v1.41/#tag/Container/operation/ContainerAttach
type Attach =
    { Id: string
      DetachKeys: string option
      Logs: bool
      Stream: bool
      Stdin: bool
      Stdout: bool
      Stderr: bool }

let create id =
    { Id = id
      DetachKeys = None
      Logs = false
      Stream = false
      Stdin = false
      Stdout = false
      Stderr = false }

type AttachBuilder(id: string) =
    [<CustomOperation("detachKeys")>]
    member inline _.DetachKeys(attach, keys) = { attach with DetachKeys = Some keys }

    [<CustomOperation("logs")>]
    member inline _.Logs(attach, logs) = { attach with Logs = logs }

    [<CustomOperation("stderr")>]
    member inline _.Stderr(attach, stderr) = { attach with Stderr = stderr }

    [<CustomOperation("stdin")>]
    member inline _.Stdin(attach, stdin) = { attach with Stdin = stdin }

    [<CustomOperation("stdout")>]
    member inline _.Stdout(attach, stdout) = { attach with Stdout = stdout }

    [<CustomOperation("stream")>]
    member inline _.Stream(attach, stream) = { attach with Stream = stream }

    member _.Yield(_: unit) = create id

let attach id = AttachBuilder(id)
