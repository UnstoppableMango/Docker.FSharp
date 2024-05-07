[<AutoOpen>]
module UnMango.Docker.Containers

open Container.Attach
open Container.Create
open Container.Kill
open Container.Logs
open Container.Remove
open Container.Start
open Container.Stop
open Container.Wait

// https://docs.docker.com/engine/api/v1.41/#tag/Container
type Action =
    | List
    | Create of Create
    | Inspect
    | ListProcesses
    | Logs of Logs
    | FileSystemChanges
    | Export
    | Stats
    | ResizeTty
    | Start of Start
    | Stop of Stop
    | Restart
    | Kill of Kill
    | Update
    | Rename
    | Pause
    | Unpause
    | Attach of Attach
    | AttachWebSocket
    | Wait of Wait
    | Remove of Remove
    | Files
    | Archive
    | ExtractArchive
    | Delete

type ContainerBuilder() =
    member inline _.Combine(actions: Action list, xs: Action list) = actions @ xs
    member inline _.Delay(f) = f ()
    member inline _.Yield(attach: Attach) = [ Attach attach ]
    member inline _.Yield(create: Create) = [ Create create ]
    member inline _.Yield(remove: Remove) = [ Remove remove ]
    member inline _.Yield(start: Start) = [ Start start ]
    member inline _.Yield(stop: Stop) = [ Stop stop ]
    member inline _.Yield(wait: Wait) = [ Wait wait ]
    member inline _.Zero() = []

let container = ContainerBuilder()
