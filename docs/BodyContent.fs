[<RequireQualifiedAccess>]
module BodyContent

open Feliz

open CodeSnippet

type Snippet =
    static member auth0App = """// JS equivalent: <Auth0Provider/>
let auth0App (children: seq<ReactElement>): ReactElement =
    let opts =
        unbox<Auth0ProviderOptions>
            {| domain = "your auth0 domain"
               clientId = "your auth0 clientId"
               redirectUri = "your redirect uri after logged-in" |}
    Auth0Provider opts children
"""
    static member useAuth0 = """// Note that the `useAuth0` hook has to be used in a ReactComponent
[<ReactComponent>]
let AuthenticationBox () =
    let ctxAuth0 = useAuth0 ()

    // correspond to authentication method `loginWithRedirect()` in JS
    let handleLoginWithRedirect _ =
        let opts = unbox<RedirectLoginOptions> null
        ctxAuth0.loginWithRedirect opts
        |> Async.AwaitPromise
        |> Async.StartImmediate

    // correspond to authentication method `logout({ returnTo: window.location.href })` in JS
    let handleLogoutWithRedirect _ =
        let returnTo = Browser.Dom.window.location.href
        let opts = unbox<LogoutOptions> {| returnTo = returnTo |}
        ctxAuth0.logout opts

    let loginButton =
        Html.button [
            prop.onClick handleLoginWithRedirect
            prop.text "Login"
        ]

    let logoutButton =
        Html.button [
            prop.onClick handleLogoutWithRedirect
            prop.text "Logout"
        ]

    if not isAuthenticated then
        // if not signed in, show login button
        loginButton
    else
        // if signed in, show user profile and logout button
        let userProfile =
            let username, picture =
                match ctxAuth0.user with
                | Some (u: User) ->
                    sprintf "%A" u.name,
                    sprintf "%A" u.picture
                | None -> "", ""
            Html.div [
                Html.p username
                Html.img [ prop.src picture ]
            ]

        Html.div [
            userProfile
            logoutButton
        ]
"""


[<ReactComponent>]
let InstallationBox () =
    Html.div [
        Html.h2 "Installation"
        Html.p "Install npm dependencies:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using npm
npm install @auth0/auth0-react

# using yarn
yarn add @auth0/auth0-react
"""
        ]
        Html.p "And install nuget package:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using nuget
Install-Package Fable.Auth0.React

# using paket
paket add Fable.Auth0.React
"""
        ]
    ]

[<ReactComponent>]
let UsageBox () =
    Html.div [
        Html.h2 "Basic usage"
        Html.p [
            Html.span "Before adjusting your F# codebase, configure Auth0 for your React application following the tutorial "
            Html.a [
                prop.href "https://auth0.com/docs/quickstart/spa/react"
                prop.target "_blank"
                prop.text "Auth0 React SDK Quickstarts"
            ]
            Html.span "."
        ]
        Html.h3 "Integrate Auth0 in F# application"
        Html.p [
            Html.span "Configure the SDK by wrapping your application in "
            Html.codeBlock "Auth0Provider"
            Html.span ":"
        ]
        Highlight.highlight [
            highlight.language.fsharp
            prop.text Snippet.auth0App
        ]
        Html.p [
            Html.span "Use the "
            Html.codeBlock "useAuth0"
            Html.span " hook in your components to access authentication state ("
            Html.codeBlock "isLoading"
            Html.span ", "
            Html.codeBlock "isAuthenticated"
            Html.span " and "
            Html.codeBlock "user"
            Html.span ") and authentication methods ("
            Html.codeBlock "loginWithRedirect"
            Html.span " and "
            Html.codeBlock "logout"
            Html.span "):"
        ]
        Highlight.highlight [
            highlight.language.fsharp
            prop.text Snippet.useAuth0
        ]
        Html.p [
            Html.span "For a working example, see "
            Html.a [
                prop.href "https://github.com/chengh42/Fable.Auth0.React/tree/main/docs"
                prop.text "https://github.com/chengh42/Fable.Auth0.React/tree/main/docs"
            ]
            Html.span "."
        ]
    ]