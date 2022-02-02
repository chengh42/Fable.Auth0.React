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
open Feliz.DaisyUI

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.text "Hello"
    ]