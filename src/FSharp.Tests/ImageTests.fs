module ImageTests

open UnMango.Docker.Images
open FsCheck.Xunit

[<Property>]
let ``ImagesBuilder builds create action`` img =
    let expected = Create.create { fromImage img }

    let actual = image { expected }

    match actual with
    | [ Create x ] -> expected = x
    | _ -> false
