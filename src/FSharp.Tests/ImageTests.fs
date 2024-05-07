module UnMango.Docker.ImageTests

open FsCheck.Xunit
open UnMango.Docker.Image.Create
open UnMango.Docker.Images

[<Property>]
let ``CreateBuilder builds create action`` i s r t m c =
    let expected =
        { FromImage = Some i
          FromSrc = Some s
          Repo = Some r
          Tag = Some t
          Message = Some m
          Changes = c }

    let actual = create {
        fromImage i
        fromSrc s
        repo r
        tag t
        message m
        changes c
    }

    expected = actual

[<Property>]
let ``ImagesBuilder builds create action`` img =
    let expected = create { fromImage img }

    let actual = image { expected }

    match actual with
    | [ Create x ] -> expected = x
    | _ -> false
