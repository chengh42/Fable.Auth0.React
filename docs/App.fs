module App

open Elmish
open Elmish.React
open Feliz
open Feliz.Router

type State = { CurrentUrl : string list }
type Msg = UrlChanged of string list

let init() = { CurrentUrl = Router.currentUrl() }
let update (UrlChanged segments) state = { state with CurrentUrl = segments }

let view state dispatch =
    React.router [
        router.onUrlChanged (UrlChanged >> dispatch)
        router.children [
            match state.CurrentUrl with
            | [ ] -> Html.h1 "Home"
            | [ "users" ] -> Html.h1 "Users page"
            | [ "users"; Route.Int userId ] -> Html.h1 (sprintf "User ID %d" userId)
            | _ -> Html.h1 "Not found"
        ]
    ]

Program.mkSimple init update view
|> Program.withReactSynchronous "root"
|> Program.run
