[<AutoOpen>]
module UnMango.Docker.Container

open ContainerAttach
open ContainerCreate
open ContainerKill
open ContainerLogs
open ContainerRemove
open ContainerStart
open ContainerStop
open ContainerWait

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
