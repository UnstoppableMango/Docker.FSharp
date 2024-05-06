﻿module UnMango.Docker.ImageTests

open FsCheck.Xunit
open UnMango.Docker.Image.Create
open UnMango.Docker.Images

[<Property>]
let ``ImagesBuilder builds create action`` img =
    let expected = create { fromImage img }

    let actual = image { expected }

    match actual with
    | [ Create x ] -> expected = x
    | _ -> false