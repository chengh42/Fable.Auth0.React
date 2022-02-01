// Generated using ts2fable 0.7.1
module rec Auth0Context

open Fable.Core
open Fable.Core.JS

open Global
type Auth0RedirectLoginOptions = Global.RedirectLoginOptions

[<Import("Auth0Context","@auth0/auth0-react")>]
let Auth0Context: obj = jsNative

type [<AllowNullLiteral>] RedirectLoginOptions =
    inherit BaseLoginOptions
    /// The URL where Auth0 will redirect your browser to with
    /// the authentication result. It must be whitelisted in
    /// the "Allowed Callback URLs" field in your Auth0 Application's
    /// settings.
    abstract redirectUri: string option with get, set
    /// Used to store state before doing the redirect
    abstract appState: obj option with get, set
    /// Used to add to the URL fragment before redirecting
    abstract fragment: string option with get, set

type Auth0ContextInterface =
    Auth0ContextInterface<obj>

/// Contains the authenticated state and authentication methods provided by the `useAuth0` hook.
type [<AllowNullLiteral>] Auth0ContextInterface<'TUser> =
    inherit AuthState.AuthState<'TUser>
    /// ```js
    /// const token = await getAccessTokenSilently(options);
    /// ```
    /// 
    /// If there's a valid token stored, return it. Otherwise, opens an
    /// iframe with the `/authorize` URL using the parameters provided
    /// as arguments. Random and secure `state` and `nonce` parameters
    /// will be auto-generated. If the response is successful, results
    /// will be valid according to their expiration times.
    /// 
    /// If refresh tokens are used, the token endpoint is called directly with the
    /// 'refresh_token' grant. If no refresh token is available to make this call,
    /// the SDK falls back to using an iframe to the '/authorize' URL.
    /// 
    /// This method may use a web worker to perform the token call if the in-memory
    /// cache is used.
    /// 
    /// If an `audience` value is given to this function, the SDK always falls
    /// back to using an iframe to make the token exchange.
    /// 
    /// Note that in all cases, falling back to an iframe requires access to
    /// the `auth0` cookie.
    abstract getAccessTokenSilently: Auth0ContextInterfaceGetAccessTokenSilently with get, set
    /// ```js
    /// const token = await getTokenWithPopup(options, config);
    /// ```
    /// 
    /// Get an access token interactively.
    /// 
    /// Opens a popup with the `/authorize` URL using the parameters
    /// provided as arguments. Random and secure `state` and `nonce`
    /// parameters will be auto-generated. If the response is successful,
    /// results will be valid according to their expiration times.
    abstract getAccessTokenWithPopup: (GetTokenWithPopupOptions -> PopupConfigOptions -> Promise<string>) with get, set
    /// ```js
    /// const claims = await getIdTokenClaims();
    /// ```
    /// 
    /// Returns all claims from the id_token if available.
    abstract getIdTokenClaims: (GetIdTokenClaimsOptions -> Promise<IdToken option>) with get, set
    /// ```js
    /// await loginWithRedirect(options);
    /// ```
    /// 
    /// Performs a redirect to `/authorize` using the parameters
    /// provided as arguments. Random and secure `state` and `nonce`
    /// parameters will be auto-generated.
    abstract loginWithRedirect: (RedirectLoginOptions -> Promise<unit>) with get, set
    /// ```js
    /// await loginWithPopup(options, config);
    /// ```
    /// 
    /// Opens a popup with the `/authorize` URL using the parameters
    /// provided as arguments. Random and secure `state` and `nonce`
    /// parameters will be auto-generated. If the response is successful,
    /// results will be valid according to their expiration times.
    /// 
    /// IMPORTANT: This method has to be called from an event handler
    /// that was started by the user like a button click, for example,
    /// otherwise the popup will be blocked in most browsers.
    abstract loginWithPopup: (PopupLoginOptions -> PopupConfigOptions -> Promise<unit>) with get, set
    /// ```js
    /// auth0.logout({ returnTo: window.location.origin });
    /// ```
    /// 
    /// Clears the application session and performs a redirect to `/v2/logout`, using
    /// the parameters provided as arguments, to clear the Auth0 session.
    /// If the `federated` option is specified, it also clears the Identity Provider session.
    /// If the `localOnly` option is specified, it only clears the application session.
    /// It is invalid to set both the `federated` and `localOnly` options to `true`,
    /// and an error will be thrown if you do.
    /// [Read more about how Logout works at Auth0](https://auth0.com/docs/logout).
    abstract logout: (LogoutOptions -> unit) with get, set
    /// ```js
    /// const authUrl = await buildAuthorizeUrl();
    /// ```
    /// 
    /// Builds an `/authorize` URL for loginWithRedirect using the parameters
    /// provided as arguments. Random and secure `state` and `nonce`
    /// parameters will be auto-generated.
    abstract buildAuthorizeUrl: (Auth0RedirectLoginOptions -> Promise<string>) with get, set
    /// ```js
    /// const logoutUrl = buildLogoutUrl();
    /// ```
    /// 
    /// returns a URL to the logout endpoint using the parameters provided as arguments.
    abstract buildLogoutUrl: (LogoutUrlOptions -> string) with get, set
    /// After the browser redirects back to the callback page,
    /// call `handleRedirectCallback` to handle success and error
    /// responses from Auth0. If the response is successful, results
    /// will be valid according to their expiration times.
    abstract handleRedirectCallback: (string -> Promise<RedirectLoginResult>) with get, set

type [<AllowNullLiteral>] Auth0ContextInterfaceGetAccessTokenSilently =
    [<Emit "$0($1...)">] abstract Invoke: options: obj -> Promise<GetTokenSilentlyVerboseResponse>
    [<Emit "$0($1...)">] abstract Invoke: ?options: GetTokenSilentlyOptions -> Promise<string>
    [<Emit "$0($1...)">] abstract Invoke: options: GetTokenSilentlyOptions -> Promise<U2<GetTokenSilentlyVerboseResponse, string>>
