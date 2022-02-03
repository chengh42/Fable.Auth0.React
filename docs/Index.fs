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
               redirectUri = Browser.Dom.window.location.href |}
    Auth0Provider opts children

[<ReactComponent>]
let ProfileBox () =
    let ctxAuth0 = useAuth0 ()
    let handleLoginWithRedirect _ =
        let opts = unbox<RedirectLoginOptions> null
        ctxAuth0.loginWithRedirect opts
        |> Async.AwaitPromise
        |> Async.StartImmediate
    let handleLogoutWithRedirect _ =
        let returnTo = Browser.Dom.window.location.href
        let opts = unbox<LogoutOptions> {| returnTo = returnTo |}
        ctxAuth0.logout opts

    if not ctxAuth0.isAuthenticated then
        Mui.button [
            button.color.secondary
            button.variant.contained
            prop.onClick handleLoginWithRedirect
            prop.text "Login with Auth0"
        ]
    else
        let username, picture =
            match ctxAuth0.user with
            | Some (u: User) ->
                sprintf "%A" u.name,
                sprintf "%A" u.picture
            | None -> "", ""
        Mui.tooltip [
            tooltip.title "Click to logout"
            tooltip.arrow true
            tooltip.children (
                Mui.button [
                    button.color.inherit'
                    button.size.large
                    button.startIcon (
                        Mui.avatar [
                            avatar.alt username
                            avatar.src picture
                        ]
                    )
                    button.endIcon (
                        Mdi.exitToAppIcon [ ]
                    )
                    button.children (
                        Html.h4 username
                    )
                    prop.onClick handleLogoutWithRedirect
                ]
            )
        ]

// <a href="" target="_blank"><img src="" alt="Nuget" /></a>

let topBar =
    Mui.container [
        Mui.toolbar [
            toolbar.variant.dense
            toolbar.children [
                Html.div [
                    prop.style [ style.flexGrow 1 ]
                    prop.children [
                        Html.h1 [
                            prop.style [
                                style.display.inlineBlock
                                style.marginRight (length.em 0.5) ]
                            prop.text "Fable.Auth0.React"
                        ]
                        Html.a [
                            prop.href "https://www.nuget.org/packages/Fable.Auth0.React/"
                            prop.target "_blank"
                            prop.children [
                                Html.img [ prop.src "https://img.shields.io/nuget/v/Fable.Auth0.React" ]
                            ]
                        ]
                    ]
                ]
                Mui.button [
                    button.href "https://github.com/chengh42/Fable.Auth0.React"
                    button.size.large
                    button.color.inherit'
                    prop.children [ Mdi.gitHubIcon [] ]
                ]
                ProfileBox ()
            ]
        ]
    ]


let view (model: Model) (dispatch: Msg -> unit) =

    auth0App [
        Mui.appBar [
            appBar.color.primary
            appBar.position.sticky
            appBar.children topBar
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
                BodyContent.InstallationBox ()
                BodyContent.UsageBox ()
            ]
        ]
    ]