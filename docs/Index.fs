module Index

open Elmish

type Model = { Input: string }

type Msg =
    | AddTodo

let init () : Model =
    let model = { Input = "" }

    model

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | AddTodo ->
        model

open Feliz
open Feliz.MaterialUI

let view (model: Model) (dispatch: Msg -> unit) =
    Mui.container [
        container.maxWidth.lg
        container.children [
            Html.h1 "Fable.Auth0.React"
            Html.p [
                Html.span "Fable library for "
                Html.a [
                    prop.href "https://github.com/auth0/auth0-react"
                    prop.target "_blank"
                    prop.children [ Html.span "@auth0/auth0-react" ]
                ]
                Html.span ", the Auth0 SDK for React Single Page Applications (SPA)."
            ]
            Html.p "Note: Still a work-in-progress!"
            Mui.button [
                button.color.primary
                button.variant.contained
                prop.text "Hello"
            ]
        ]
    ]