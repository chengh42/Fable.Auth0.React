module Index

open Elmish
open Feliz.Router

[<RequireQualifiedAccess>]
type Page =
    | Index
    | Usage with
    static member parseUrl (url: string list) =
        match url with
        | [ "usage" ] -> Page.Usage
        | [ "home" ] | _ -> Page.Index

    static member parsePage (page: Page) =
        match page with
        | Index -> "Installation", Pages.Index.View ()
        | Usage -> "Usage", Pages.Usage.View ()

type Model = { CurrentUrl : string list; CurrentPage : Page }

type Msg = UrlChanged of string list

let init () : Model =
    { CurrentUrl = Router.currentUrl()
      CurrentPage = Router.currentUrl() |> Page.parseUrl }

let update (UrlChanged url) (model: Model) : Model =
    { CurrentUrl = url; CurrentPage = Page.parseUrl url }

open Fable.Core
open Fable.Auth0.React
open Feliz
open Feliz.DaisyUI
open Feliz.DaisyUI.Operators

let auth0App (children: seq<ReactElement>) =
    let opts =
        unbox<Auth0ProviderOptions>
            {| domain = "dev-nik3xlx8.us.auth0.com"
               clientId = "sGGwICcD2Cnp3DX1A0kacQmcsY0Ri7nu"
               redirectUri = Browser.Dom.window.location.href
               audience = "https://dev-nik3xlx8.us.auth0.com/api/v2/"
               scope = "read:current_user update:current_user_metadata" |}
    Auth0Provider opts children

[<ReactComponent>]
let Auth0Box () =
    let ctxAuth0 = useAuth0 ()
    let userMetadata, setUserMetadata = React.useState None
    let handle _ =
        ctxAuth0.getAccessTokenSilently
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
        Daisy.tooltip [
            tooltip.text "Click to login"
            prop.children [
                Daisy.button.a [
                    button.primary
                    button.outline
                    ++ prop.className "mx-3"
                    prop.onClick handleLoginWithRedirect
                    prop.children [
                        Html.p [
                            prop.style [ style.paddingRight (length.em 0.5) ]
                            prop.text "Try Auth0" ]
                        Html.i [ prop.className "fas fa-sign-in-alt" ]
                    ]
                ]
            ]
        ]
    else
        let username, picture =
            match ctxAuth0.user with
            | Some (u: User) ->
                sprintf "%A" u.given_name,
                sprintf "%A" u.picture
            | None -> "", ""
        let userMetadataJson =
            userMetadata |> function
            | Some m ->
                sprintf "User metadata: %A" m
                // JS.JSON.stringify (m, JS.undefined, 2)
            | None -> "No user metadata defined"

        Daisy.tooltip [
            tooltip.text "Click to logout"
            prop.children [
                Daisy.button.button [
                    button.primary
                    button.outline
                    ++ prop.className "ml-3"
                    prop.style [ style.alignContent.center ]
                    prop.children [
                        Daisy.avatar [
                            Html.div [
                                prop.className "rounded-btn w-8 h-8"
                                prop.children [
                                    Html.img [ prop.src picture ]
                                ]
                            ]
                        ]
                        Html.p [
                            prop.className "mx-3"
                            prop.text username
                        ]
                        Html.i [ prop.className "fas fa-sign-out-alt" ]
                    ]
                    prop.onClick handleLogoutWithRedirect
                ]
            ]
        ]


let private leftSide (model: Model) (dispatch: Msg -> unit) =
    let pages =
        [ Page.Index, "/"
          Page.Usage, "usage" ]

    Daisy.drawerSide [
        Daisy.drawerOverlay [ prop.htmlFor "main-menu" ]
        Html.aside [
            prop.className "flex flex-col border-r w-80 bg-base-100 text-base-content"
            prop.children [
                Html.div [
                    prop.className "font-title px-5 py-5"
                    prop.children [
                        Html.div [
                            color.textPrimary
                            ++ prop.className "text-3xl font-bold py-1"
                            prop.text "Fable.Auth0.React"
                        ]
                        Html.div [
                            prop.className "py-1"
                            prop.children [
                                Html.a [
                                    prop.href "https://www.nuget.org/packages/Fable.Auth0.React/"
                                    prop.target "_blank"
                                    prop.children [
                                        Html.img [ prop.src "https://img.shields.io/nuget/v/Fable.Auth0.React?style=for-the-badge&?logo=nuget" ]
                                    ]
                                ]
                            ]
                        ]
                        Html.div [
                            prop.className "py-2"
                            prop.children [
                                Html.p [
                                    Html.span "Fable library for "
                                    Html.a [
                                        prop.href "https://github.com/auth0/auth0-react"
                                        prop.target "_blank"
                                        prop.children [ Html.span "@auth0/auth0-react" ]
                                    ]
                                    Html.span ", the Auth0 SDK for React Single Page Applications (SPA)."
                                ]
                            ]
                        ]
                        Html.div [
                            prop.className "py-2"
                            prop.style [ style.display.flex; style.alignContent.center ]
                            prop.children [
                                Daisy.button.a [
                                    button.secondary
                                    prop.href "https://github.com/chengh42/Fable.Auth0.React"
                                    prop.target "_blank"
                                    prop.children [
                                        Html.i [ prop.className "fab fa-github px-1" ]
                                        Html.i [ prop.className "fas fa-code px-1" ]
                                    ]
                                ]
                                Auth0Box ()
                            ]
                        ]
                    ]
                ]
                Daisy.menu [
                    menu.compact
                    prop.className "flex flex-col p-4 pt-0"
                    prop.children [
                        for (page, url) in pages do
                            let title, _ = Page.parsePage page
                            Html.li [
                                Html.a [
                                    if page = model.CurrentPage then menuItem.active
                                    prop.text title
                                    prop.onClick (fun _ -> UrlChanged [url] |> dispatch)
                                ]
                            ]
                    ]
                ]
            ]
        ]
    ]

let rightSide (model: Model) (dispatch: Msg -> unit) =
    let title, content = model.CurrentPage |> Page.parsePage
    Daisy.drawerContent [
        Html.div [
            prop.className "px-5 py-5"
            prop.children [
                Html.h2 [
                    color.textPrimary
                    ++ prop.className "my-6 text-5xl font-bold"
                    prop.text title
                ]
                content
            ]
        ]
    ]

let private pageLayout (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.className "bg-base-100 text-base-content h-screen"
        theme.cupcake
        prop.children [
            Daisy.drawer [
                drawer.mobile
                prop.children [
                    Daisy.drawerToggle [ prop.id "main-menu" ]
                    rightSide model dispatch
                    leftSide model dispatch
                ]
            ]
        ]
    ]

let view (model: Model) (dispatch: Msg -> unit) =

    auth0App [
        React.router [
            router.hashMode
            router.onUrlChanged (UrlChanged >> dispatch)
            router.children [ pageLayout model dispatch ]
        ]
    ]