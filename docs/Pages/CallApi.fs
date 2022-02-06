module Pages.CallApi

type Snippet =
    static member auth0App = """open Fable.Auth0.React

// JS equivalent: <Auth0Provider/>
let auth0App (children: seq<ReactElement>) =
    let opts =
        unbox<Auth0ProviderOptions>
            {| domain = "YOUR_AUTH0_DOMAIN"
               clientId = "YOUR_AUTO0_CLIENT_ID"
               redirectUri = "YOUR_REDIRECT_URI_AFTER_LOGGED_IN"
               audience = "https://{YOUR_AUTH0_DOMAIN}/api/v2/"
               scope = "read:current_user update:current_user_metadata" |}
    Auth0Provider opts children
"""
    static member auth0AppRefreshToken = """open Fable.Auth0.React

// JS equivalent: <Auth0Provider/>
let auth0App (children: seq<ReactElement>) =
    let opts =
        unbox<Auth0ProviderOptions>
            {| domain = "YOUR_AUTH0_DOMAIN"
               clientId = "YOUR_AUTO0_CLIENT_ID"
               redirectUri = "YOUR_REDIRECT_URI_AFTER_LOGGED_IN"
               audience = "https://{YOUR_AUTH0_DOMAIN}/api/v2/"
               scope = "read:current_user update:current_user_metadata"
               useRefreshTokens = true |}
    Auth0Provider opts children
"""
    static member useAuth0 = """open Fable.Core
open Fable.SimpleHttp
open Feliz

// Note that the `useAuth0` hook has to be used in a ReactComponent
[<ReactComponent>]
let ProfileBox () =
    let ctxAuth0 = useAuth0 ()
    let userMetadata, setUserMetadata = React.useState ""
    let usersub =
        ctxAuth0.user
        |> Option.bind (fun v -> v.sub)
        |> Option.defaultValue ""

    React.useEffect (fun () ->
        let opts =
            unbox<GetTokenSilentlyOptions>
                {| audience = "https://{YOUR_AUTH0_DOMAIN}/api/v2/"
                   scope = "read:current_user" |}
        try
            async {
                let! accessToken =
                    ctxAuth0.getAccessTokenSilently.Invoke opts
                    |> Async.AwaitPromise
                let tokenHeader =
                    "Bearer " + accessToken
                let userDetailsByIdUrl =
                    sprintf "https://{YOUR_AUTH0_DOMAIN}/api/v2/users/%s" usersub
                let! metadataResponse =
                    Http.request userDetailsByIdUrl
                    |> Http.method GET
                    |> Http.header (Headers.authorization tokenHeader)
                    |> Http.send

                // update component state
                setUserMetadata metadataResponse.responseText
            }
            |> Async.StartImmediate

        with ex ->
            // error handling
            JS.console.log(ex.Message)
    , [| usersub :> obj |]) // only re-run the effect if usersub changes

    // ...
"""

open Feliz
open Shared

[<ReactComponent>]
let View () =
    Html.div [
        Html.p [
            Html.span "This tutorial demonstrates how to make API calls to the "
            Html.a ("Auth0 Management API", "https://auth0.com/docs/api#management-api")
            Html.span ", following the tutorial "
            Html.a ("Auth0 React SDK Quickstarts: Call an API", "https://auth0.com/docs/quickstart/spa/react/02-calling-an-api")
            Html.span "."
        ]
        Html.p [
            Html.span "First, set up the Auth0 service. To request an access token in a format that the API can verify, passing the "
            Html.code "audience"
            Html.span " and "
            Html.code "scope"
            Html.span " props to "
            Html.code "Auth0Provider"
            Html.span "."
        ]
        Html.p [
            Html.span "In the case of the Auth0 Management API, we use the "
            Html.code "read:current_user"
            Html.span " and "
            Html.code "update:current_user_metadata"
            Html.span " scopes to get an access token that can retrieve user details and update the user's information."
        ]
        Highlight.highlight [
            highlight.language.fsharp
            prop.text Snippet.auth0App
        ]
        Html.p [
            Html.span "Once you configure Auth0Provider, you can easily get the access token using the "
            Html.code "getAccessTokenSilently()"
            Html.span " method from the "
            Html.code "useAuth0()"
            Html.span " custom React Hook wherever you need it."
        ]
        Highlight.highlight [
            highlight.language.fsharp
            prop.text Snippet.useAuth0
        ]
        Html.p [
            Html.span "The "
            Html.code "getAccessTokenSilently()"
            Html.span " method can renew the access and ID token for you using refresh tokens. To get a refresh token when a user logs in, pass "
            Html.code "useRefreshTokens={true}"
            Html.span " as a prop to "
            Html.code "Auth0Provider"
            Html.span ":"
        ]
        Highlight.highlight [
            highlight.language.fsharp
            prop.text Snippet.auth0AppRefreshToken
        ]
    ]