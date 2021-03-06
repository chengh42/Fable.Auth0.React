module Index

open Elmish
open Feliz.Router

type Url = Url of string with member this.UrlSegment = this |> function Url v -> [v]

[<RequireQualifiedAccess>]
type Page =
    | Index
    | Usage
    | CallApi
    | SafeStack
    | Contributing
    | Acknowledgement with
    static member parseUrl (url: string list) =
        match url with
        | [ "usage" ] -> Page.Usage
        | [ "call-api" ] -> Page.CallApi
        | [ "safe" ] -> Page.SafeStack
        | [ "contributing" ] -> Page.Contributing
        | [ "acknowledgement" ] -> Page.Acknowledgement
        | [ "/" ] | _ -> Page.Index

    static member parsePage (page: Page) =
        match page with
        | Index -> Url "/", "Installation", Pages.Installation.View ()
        | Usage -> Url "usage", "Basic usage", Pages.Usage.View ()
        | CallApi -> Url "call-api", "Call an API", Pages.CallApi.View ()
        | SafeStack -> Url "safe", "Using with SAFE stack", Pages.SafeStack.View ()
        | Contributing -> Url "contributing", "Contributing", Pages.Contributing.View ()
        | Acknowledgement -> Url "acknowledgement", "Acknowledgement", Pages.Acknowledgement.View ()

type Model = { CurrentUrl : string list; CurrentPage : Page; UserMetadata : string }

type Msg = UrlChanged of string list | SetUserMetadata of string

let init () : Model =
    { CurrentUrl = Router.currentUrl()
      CurrentPage = Router.currentUrl() |> Page.parseUrl
      UserMetadata = "" }

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | UrlChanged url -> { model with CurrentUrl = url; CurrentPage = Page.parseUrl url }
    | SetUserMetadata md -> { model with UserMetadata = md }

open Fable.Core
open Fable.Auth0.React
open Fable.SimpleHttp
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
               scope = "read:current_user update:current_user_metadata"
               useRefreshTokens = true |}
    Auth0Provider opts children

[<ReactComponent>]
let LoginButton () =
    let ctxAuth0 = useAuth0 ()
    let handleLoginWithRedirect _ =
        let opts = unbox<RedirectLoginOptions> null
        ctxAuth0.loginWithRedirect opts
        |> Async.AwaitPromise
        |> Async.StartImmediate

    match ctxAuth0.isLoading, ctxAuth0.isAuthenticated with
    | false, false ->
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
    | _ ->
        Html.none

[<ReactComponent>]
let Profile (props: {| SetUserMetadata: string -> unit |}) =
    let ctxAuth0 = useAuth0 ()
    let username, picture, usersub =
        match ctxAuth0.user with
        | Some (u: User) -> $"{u.name}", $"{u.picture}", $"{u.sub}"
        | None -> "", "", ""
    let userDetailsByIdUrl =
        sprintf "https://dev-nik3xlx8.us.auth0.com/api/v2/users/%s" usersub
    let handleLogoutWithRedirect _ =
        let returnTo = Browser.Dom.window.location.href
        let opts = unbox<LogoutOptions> {| returnTo = returnTo |}
        ctxAuth0.logout opts

    React.useEffect (fun () ->
        let opts =
            unbox<GetTokenSilentlyOptions>
                {| audience = "https://dev-nik3xlx8.us.auth0.com/api/v2/"
                   scope = "read:current_user" |}
        try
            async {
                let! accessToken =
                    ctxAuth0.getAccessTokenSilently.Invoke opts
                    |> Async.AwaitPromise
                let tokenHeader = "BEARER " + accessToken
                let! metadataResponse =
                    Http.request userDetailsByIdUrl
                    |> Http.method GET
                    |> Http.headers [
                        Headers.authorization tokenHeader
                        Headers.contentType "application/json"
                    ]
                    |> Http.send

                match metadataResponse with
                | res when res.statusCode = 200 ->
                    props.SetUserMetadata metadataResponse.responseText
                | res ->
                    // JS.console.log($"Failed to fetch metadata: {res}")
                    ()
            }
            |> Async.StartImmediate

        with ex ->
            // @TODO: error handling
            JS.console.log(ex.Message)
    , [| ctxAuth0.isAuthenticated :> obj |])

    match ctxAuth0.isLoading, ctxAuth0.isAuthenticated with
    | true, _ ->
        Daisy.card [
            Daisy.cardBody [
                Shared.Spinner ()
            ]
        ]
    | _, true ->
        Daisy.card [
            card.bordered
            card.compact
            color.bgPrimaryContent
            ++ prop.className "m-5"
            prop.style [ style.overflow.initial ]
            prop.children [
                Daisy.cardBody [
                    Daisy.cardTitle [
                        prop.className "mx-3"
                        prop.style [
                            style.display.flex
                            style.justifyContent.spaceAround
                            style.alignContent.center
                        ]
                        prop.children [
                            Daisy.avatar [
                                Html.div [
                                    prop.className "rounded-btn w-14 h-14"
                                    prop.children [
                                        Html.img [ prop.src picture ]
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.style [
                                    style.margin length.auto
                                    style.paddingBottom (length.em 0.25)
                                ]
                                prop.text username
                            ]
                        ]
                    ]
                    Daisy.cardActions [
                        Daisy.button.label [
                            button.primary
                            ++ prop.className "lg:btn-md btn-sm"
                            prop.htmlFor "modal-user-access-token"
                            prop.text "Metadata"
                        ]
                        Daisy.button.button [
                            button.primary
                            button.outline
                            ++ prop.className "lg:btn-md btn-sm"
                            prop.onClick handleLogoutWithRedirect
                            prop.children [
                                Html.p [
                                    prop.className "mr-3"
                                    prop.text "Logout"
                                ]
                                Html.i [ prop.className "fas fa-sign-out-alt" ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    | false, false ->
        Html.none

let private menuPages (title: string) pages model dispatch =
    Daisy.menu [
        menu.compact
        prop.className "flex flex-col p-3 pt-0"
        prop.children [
            Daisy.menuTitle title
            for page in pages do
                let url, title, _ = Page.parsePage page
                Html.li [
                    Html.a [
                        if page = model.CurrentPage then menuItem.active
                        prop.text title
                        prop.href (Router.format(url.UrlSegment))
                    ]
                ]
        ]
    ]

let private leftSide (model: Model) (dispatch: Msg -> unit) =
    let pagesDocs =
        [ Page.Index
          Page.Usage
          Page.CallApi
          Page.SafeStack ]
    let pagesAbout =
        [ Page.Contributing
          Page.Acknowledgement ]

    Daisy.drawerSide [
        Daisy.drawerOverlay [ prop.htmlFor "main-menu" ]
        Html.aside [
            prop.className "flex flex-col border-r w-80 bg-base-100 text-base-content"
            prop.style [ style.overflowY.auto ]
            prop.children [
                Html.div [
                    Html.div [
                        prop.className "font-title px-5 py-5"
                        prop.children [
                            Shared.Html.h1 "Fable.Auth0.React"
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
                                        Daisy.link [
                                            link.hover
                                            link.accent
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
                                    LoginButton ()
                                ]
                            ]
                        ]
                    ]
                    menuPages "Docs" pagesDocs model dispatch
                    menuPages "About" pagesAbout model dispatch
                ]
                Profile ({| SetUserMetadata = SetUserMetadata >> dispatch |})
            ]
        ]
    ]

let rightSide (model: Model) (dispatch: Msg -> unit) =
    let _, title, content = model.CurrentPage |> Page.parsePage
    Daisy.drawerContent [
        Daisy.navbar [
            color.bgPrimary
            ++ color.textPrimaryContent
            ++ prop.className "w-full lg:hidden fixed z-50"
            prop.children [
                Daisy.button.label [
                    prop.htmlFor "main-menu"
                    button.square
                    button.ghost
                    prop.children [ Html.i [ prop.className "fa-2x fas fa-bars" ] ]
                ]
                Html.h1 [
                    prop.className "text-2xl font-bold ml-2"
                    prop.text "Fable.Auth0.React"
                ]
            ]
        ]
        Html.div [
            prop.className "px-5 py-5"
            prop.children [
                Html.h2 [
                    color.textPrimary
                    ++ prop.className "mb-6 text-4xl font-bold"
                    prop.text title
                ]
                content
            ]
        ]
    ]

[<ReactComponent>]
let UserMetadataContent (props: {| UserMetadata: string |}) =
    let ctxAuth0 = useAuth0 ()
    match props.UserMetadata, ctxAuth0.isLoading with
    | "", true -> Shared.Spinner ()
    | "", false -> Shared.Html.p "No user's metadata received yet."
    | userMd, _ ->
        let userMetadataEntries =
            try
                userMd |> JS.JSON.parse |> JS.Constructors.Object.entries |> List.ofSeq
            with ex ->
                [ ]
        Html.div [
            Shared.Html.p "User's metadata:"
            match userMetadataEntries with
            | [ ] -> Html.text "Loading ..."
            | entries ->
                Html.div [
                    prop.style [
                        style.overflowX.hidden
                        style.maxHeight (length.em 13)
                        style.wordWrap.breakWord
                    ]
                    prop.children [
                        Daisy.table [
                            table.compact
                            table.zebra
                            ++ prop.className "w-full"
                            prop.children [
                                Html.thead [
                                    Html.tr [
                                        Html.th "Key"
                                        Html.th "Value"
                                    ]
                                ]
                                Html.tbody [
                                    for (key, value) in entries do
                                    Html.tr [
                                        Html.td key
                                        Html.td $"{value}"
                                    ]
                                ]
                            ]
                        ]
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
                    Daisy.modalToggle [ prop.id "modal-user-access-token" ]
                    Daisy.modal [
                        prop.children [
                            Daisy.modalBox [
                                UserMetadataContent {| UserMetadata = model.UserMetadata |}
                                Daisy.modalAction [
                                    Daisy.button.label [
                                        prop.htmlFor "modal-user-access-token"
                                        prop.text "I see"
                                        button.primary
                                    ]
                                ]
                            ]
                        ]
                    ]
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