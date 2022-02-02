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

open Fable.Core
open Fable.Auth0.React
open Feliz
open Feliz.MaterialUI
module Mdi = Fable.MaterialUI.Icons

let auth0App (children: seq<ReactElement>) =
    let opts =
        unbox<Auth0ProviderOptions>
            {| domain = "dev-nik3xlx8.us.auth0.com"
               clientId = "sGGwICcD2Cnp3DX1A0kacQmcsY0Ri7nu"
               redirectUri = "http://localhost:8080" |}
    Auth0Provider opts children

let topBar =
    Mui.container [
        Mui.toolbar [
            toolbar.variant.dense
            toolbar.children [
                Html.h1 "Fable.Auth0.React"
                Mui.button [
                    button.href "https://github.com/chengh42/Fable.Auth0.React"
                    button.size.large
                    button.color.inherit'
                    prop.children [ Mdi.gitHubIcon [] ]
                ]
            ]
        ]
    ]

[<ReactComponent>]
let LoginBtn () =
    let ctxAuth0 = useAuth0 ()
    let handleLoginWithRedirect _ =
        let opts = unbox<RedirectLoginOptions> null

        ctxAuth0.loginWithRedirect opts
        |> Async.AwaitPromise
        |> Async.StartImmediate

    Mui.button [
        button.color.primary
        button.variant.contained
        prop.onClick handleLoginWithRedirect
        prop.text "Login with Auth0"
    ]

let view (model: Model) (dispatch: Msg -> unit) =

    auth0App [
        Mui.appBar [
            appBar.color.primary
            appBar.position.sticky
            appBar.children (topBar)
        ]

        Mui.container [
            container.maxWidth.lg
            container.children [
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
                LoginBtn ()
            ]
        ]
    ]