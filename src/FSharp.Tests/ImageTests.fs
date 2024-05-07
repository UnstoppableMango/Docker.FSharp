module UnMango.Docker.ImageTests

open FsCheck.Xunit
open UnMango.Docker.Images.Image
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

    Create expected = actual
