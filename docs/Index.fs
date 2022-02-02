module Index

open Elmish

type Model = { Input: string }

type Msg =
    | AddTodo

let init () : Model * Cmd<Msg> =
    let model = { Input = "" }

    let cmd = Cmd.none

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | AddTodo ->
        model, Cmd.none

open Feliz
open Feliz.DaisyUI

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.text "Hello"
    ]