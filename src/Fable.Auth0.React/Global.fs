// @auth0/auth0-spa-js/dist/typings/global.d.ts
// Generated using ts2fable 0.7.1
module rec Global

open Fable.Core
open Fable.Core.JS

type [<AllowNullLiteral>] IExports =
    abstract User: UserStatic

type [<AllowNullLiteral>] BaseLoginOptions =
    /// - `'page'`: displays the UI with a full page view
    /// - `'popup'`: displays the UI with a popup window
    /// - `'touch'`: displays the UI in a way that leverages a touch interface
    /// - `'wap'`: displays the UI with a "feature phone" type interface
    abstract display: BaseLoginOptionsDisplay option with get, set
    /// - `'none'`: do not prompt user for login or consent on reauthentication
    /// - `'login'`: prompt user for reauthentication
    /// - `'consent'`: prompt user for consent before processing request
    /// - `'select_account'`: prompt user to select an account
    abstract prompt: BaseLoginOptionsPrompt option with get, set
    /// Maximum allowable elasped time (in seconds) since authentication.
    /// If the last time the user authenticated is greater than this value,
    /// the user must be reauthenticated.
    abstract max_age: U2<string, float> option with get, set
    /// The space-separated list of language tags, ordered by preference.
    /// For example: `'fr-CA fr en'`.
    abstract ui_locales: string option with get, set
    /// Previously issued ID Token.
    abstract id_token_hint: string option with get, set
    /// Provides a hint to Auth0 as to what flow should be displayed.
    /// The default behavior is to show a login page but you can override
    /// this by passing 'signup' to show the signup page instead.
    /// 
    /// This only affects the New Universal Login Experience.
    abstract screen_hint: string option with get, set
    /// The user's email address or other identifier. When your app knows
    /// which user is trying to authenticate, you can provide this parameter
    /// to pre-fill the email box or select the right session for sign-in.
    /// 
    /// This currently only affects the classic Lock experience.
    abstract login_hint: string option with get, set
    abstract acr_values: string option with get, set
    /// The default scope to be used on authentication requests.
    /// The defaultScope defined in the Auth0Client is included
    /// along with this scope
    abstract scope: string option with get, set
    /// The default audience to be used for requesting API access.
    abstract audience: string option with get, set
    /// The name of the connection configured for your application.
    /// If null, it will redirect to the Auth0 Login Page and show
    /// the Login Widget.
    abstract connection: string option with get, set
    /// The Id of an organization to log in to.
    /// 
    /// This will specify an `organization` parameter in your user's login request and will add a step to validate
    /// the `org_id` claim in your user's ID Token.
    abstract organization: string option with get, set
    /// The Id of an invitation to accept. This is available from the user invitation URL that is given when participating in a user invitation flow.
    abstract invitation: string option with get, set
    /// If you need to send custom parameters to the Authorization Server,
    /// make sure to use the original parameter name.
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] AdvancedOptions =
    /// The default scope to be included with all requests.
    /// If not provided, 'openid profile email' is used. This can be set to `null` in order to effectively remove the default scopes.
    /// 
    /// Note: The `openid` scope is **always applied** regardless of this setting.
    abstract defaultScope: string option with get, set

type [<AllowNullLiteral>] Auth0ClientOptions =
    inherit BaseLoginOptions
    /// Your Auth0 account domain such as `'example.auth0.com'`,
    /// `'example.eu.auth0.com'` or , `'example.mycompany.com'`
    /// (when using [custom domains](https://auth0.com/docs/custom-domains))
    abstract domain: string with get, set
    /// The issuer to be used for validation of JWTs, optionally defaults to the domain above
    abstract issuer: string option with get, set
    /// The Client ID found on your Application settings page
    abstract client_id: string with get, set
    /// The default URL where Auth0 will redirect your browser to with
    /// the authentication result. It must be whitelisted in
    /// the "Allowed Callback URLs" field in your Auth0 Application's
    /// settings. If not provided here, it should be provided in the other
    /// methods that provide authentication.
    abstract redirect_uri: string option with get, set
    /// The value in seconds used to account for clock skew in JWT expirations.
    /// Typically, this value is no more than a minute or two at maximum.
    /// Defaults to 60s.
    abstract leeway: float option with get, set
    /// The location to use when storing cache data. Valid values are `memory` or `localstorage`.
    /// The default setting is `memory`.
    /// 
    /// Read more about [changing storage options in the Auth0 docs](https://auth0.com/docs/libraries/auth0-single-page-app-sdk#change-storage-options)
    abstract cacheLocation: CacheLocation option with get, set
    // @TODO
    // /// Specify a custom cache implementation to use for token storage and retrieval. This setting takes precedence over `cacheLocation` if they are both specified.
    // abstract cache: ICache option with get, set
    /// If true, refresh tokens are used to fetch new access tokens from the Auth0 server. If false, the legacy technique of using a hidden iframe and the `authorization_code` grant with `prompt=none` is used.
    /// The default setting is `false`.
    /// 
    /// **Note**: Use of refresh tokens must be enabled by an administrator on your Auth0 client application.
    abstract useRefreshTokens: bool option with get, set
    /// A maximum number of seconds to wait before declaring background calls to /authorize as failed for timeout
    /// Defaults to 60s.
    abstract authorizeTimeoutInSeconds: float option with get, set
    /// Internal property to send information about the client to the authorization server.
    abstract auth0Client: Auth0ClientOptionsAuth0Client option with get, set
    /// Sets an additional cookie with no SameSite attribute to support legacy browsers
    /// that are not compatible with the latest SameSite changes.
    /// This will log a warning on modern browsers, you can disable the warning by setting
    /// this to false but be aware that some older useragents will not work,
    /// See https://www.chromium.org/updates/same-site/incompatible-clients
    /// Defaults to true
    abstract legacySameSiteCookie: bool option with get, set
    /// If `true`, the SDK will use a cookie when storing information about the auth transaction while
    /// the user is going through the authentication flow on the authorization server.
    /// 
    /// The default is `false`, in which case the SDK will use session storage.
    abstract useCookiesForTransactions: bool option with get, set
    /// Changes to recommended defaults, like defaultScope
    abstract advancedOptions: AdvancedOptions option with get, set
    /// Number of days until the cookie `auth0.is.authenticated` will expire
    /// Defaults to 1.
    abstract sessionCheckExpiryDays: float option with get, set
    /// When true, data to the token endpoint is transmitted as x-www-form-urlencoded data instead of JSON. The default is false, but will default to true in a
    /// future major version.
    /// 
    /// **Note:** Setting this to `true` may affect you if you use Auth0 Rules and are sending custom, non-primative data. If you enable this, please verify that your Auth0 Rules
    /// continue to work as intended.
    abstract useFormData: bool option with get, set
    /// Modify the value used as the current time during the token validation.
    /// 
    /// **Note**: Using this improperly can potentially compromise the token validation.
    abstract nowProvider: (unit -> U2<Promise<float>, float>) option with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] CacheLocation =
    | Memory
    | Localstorage

type [<AllowNullLiteral>] AuthorizeOptions =
    inherit BaseLoginOptions
    abstract response_type: string with get, set
    abstract response_mode: string with get, set
    abstract redirect_uri: string with get, set
    abstract nonce: string with get, set
    abstract state: string with get, set
    /// The default scope to be used on authentication requests.
    /// The defaultScope defined in the Auth0Client is included
    /// along with this scope
    abstract scope: string with get, set
    abstract code_challenge: string with get, set
    abstract code_challenge_method: string with get, set

type RedirectLoginOptions =
    RedirectLoginOptions<obj>

type [<AllowNullLiteral>] RedirectLoginOptions<'TAppState> =
    inherit BaseLoginOptions
    /// The URL where Auth0 will redirect your browser to with
    /// the authentication result. It must be whitelisted in
    /// the "Allowed Callback URLs" field in your Auth0 Application's
    /// settings.
    abstract redirect_uri: string option with get, set
    /// Used to store state before doing the redirect
    abstract appState: 'TAppState option with get, set
    /// Used to add to the URL fragment before redirecting
    abstract fragment: string option with get, set
    /// Used to select the window.location method used to redirect
    abstract redirectMethod: RedirectLoginOptionsRedirectMethod option with get, set

type RedirectLoginResult =
    RedirectLoginResult<obj>

type [<AllowNullLiteral>] RedirectLoginResult<'TAppState> =
    /// State stored when the redirect request was made
    abstract appState: 'TAppState option with get, set

type [<AllowNullLiteral>] PopupLoginOptions =
    inherit BaseLoginOptions

type [<AllowNullLiteral>] PopupConfigOptions =
    /// The number of seconds to wait for a popup response before
    /// throwing a timeout error. Defaults to 60s
    abstract timeoutInSeconds: float option with get, set
    /// Accepts an already-created popup window to use. If not specified, the SDK
    /// will create its own. This may be useful for platforms like iOS that have
    /// security restrictions around when popups can be invoked (e.g. from a user click event)
    abstract popup: obj option with get, set

type [<AllowNullLiteral>] GetUserOptions =
    /// The scope that was used in the authentication request
    abstract scope: string option with get, set
    /// The audience that was used in the authentication request
    abstract audience: string option with get, set

type [<AllowNullLiteral>] GetIdTokenClaimsOptions =
    /// The scope that was used in the authentication request
    abstract scope: string option with get, set
    /// The audience that was used in the authentication request
    abstract audience: string option with get, set

type getIdTokenClaimsOptions =
    GetIdTokenClaimsOptions

type [<AllowNullLiteral>] GetTokenSilentlyOptions =
    /// When `true`, ignores the cache and always sends a
    /// request to Auth0.
    abstract ignoreCache: bool option with get, set
    /// There's no actual redirect when getting a token silently,
    /// but, according to the spec, a `redirect_uri` param is required.
    /// Auth0 uses this parameter to validate that the current `origin`
    /// matches the `redirect_uri` `origin` when sending the response.
    /// It must be whitelisted in the "Allowed Web Origins" in your
    /// Auth0 Application's settings.
    abstract redirect_uri: string option with get, set
    /// The scope that was used in the authentication request
    abstract scope: string option with get, set
    /// The audience that was used in the authentication request
    abstract audience: string option with get, set
    /// A maximum number of seconds to wait before declaring the background /authorize call as failed for timeout
    /// Defaults to 60s.
    abstract timeoutInSeconds: float option with get, set
    /// If true, the full response from the /oauth/token endpoint (or the cache, if the cache was used) is returned
    /// (minus `refresh_token` if one was issued). Otherwise, just the access token is returned.
    /// 
    /// The default is `false`.
    abstract detailedResponse: bool option with get, set
    /// If you need to send custom parameters to the Authorization Server,
    /// make sure to use the original parameter name.
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] GetTokenWithPopupOptions =
    inherit PopupLoginOptions
    /// When `true`, ignores the cache and always sends a
    /// request to Auth0.
    abstract ignoreCache: bool option with get, set

type [<AllowNullLiteral>] LogoutUrlOptions =
    /// The URL where Auth0 will redirect your browser to after the logout.
    /// 
    /// **Note**: If the `client_id` parameter is included, the
    /// `returnTo` URL that is provided must be listed in the
    /// Application's "Allowed Logout URLs" in the Auth0 dashboard.
    /// However, if the `client_id` parameter is not included, the
    /// `returnTo` URL must be listed in the "Allowed Logout URLs" at
    /// the account level in the Auth0 dashboard.
    /// 
    /// [Read more about how redirecting after logout works](https://auth0.com/docs/logout/guides/redirect-users-after-logout)
    abstract returnTo: string option with get, set
    /// The `client_id` of your application.
    /// 
    /// If this property is not set, then the `client_id` that was used during initialization of the SDK is sent to the logout endpoint.
    /// 
    /// If this property is set to `null`, then no client ID value is sent to the logout endpoint.
    /// 
    /// [Read more about how redirecting after logout works](https://auth0.com/docs/logout/guides/redirect-users-after-logout)
    abstract client_id: string option with get, set
    /// When supported by the upstream identity provider,
    /// forces the user to logout of their identity provider
    /// and from Auth0.
    /// [Read more about how federated logout works at Auth0](https://auth0.com/docs/logout/guides/logout-idps)
    abstract federated: bool option with get, set

type [<AllowNullLiteral>] LogoutOptions =
    /// The URL where Auth0 will redirect your browser to after the logout.
    /// 
    /// **Note**: If the `client_id` parameter is included, the
    /// `returnTo` URL that is provided must be listed in the
    /// Application's "Allowed Logout URLs" in the Auth0 dashboard.
    /// However, if the `client_id` parameter is not included, the
    /// `returnTo` URL must be listed in the "Allowed Logout URLs" at
    /// the account level in the Auth0 dashboard.
    /// 
    /// [Read more about how redirecting after logout works](https://auth0.com/docs/logout/guides/redirect-users-after-logout)
    abstract returnTo: string option with get, set
    /// The `client_id` of your application.
    /// 
    /// If this property is not set, then the `client_id` that was used during initialization of the SDK is sent to the logout endpoint.
    /// 
    /// If this property is set to `null`, then no client ID value is sent to the logout endpoint.
    /// 
    /// [Read more about how redirecting after logout works](https://auth0.com/docs/logout/guides/redirect-users-after-logout)
    abstract client_id: string option with get, set
    /// When supported by the upstream identity provider,
    /// forces the user to logout of their identity provider
    /// and from Auth0.
    /// This option cannot be specified along with the `localOnly` option.
    /// [Read more about how federated logout works at Auth0](https://auth0.com/docs/logout/guides/logout-idps)
    abstract federated: bool option with get, set
    /// When `true`, this skips the request to the logout endpoint on the authorization server,
    /// effectively performing a "local" logout of the application. No redirect should take place,
    /// you should update local logged in state.
    /// This option cannot be specified along with the `federated` option.
    abstract localOnly: bool option with get, set

type [<AllowNullLiteral>] AuthenticationResult =
    abstract state: string with get, set
    abstract code: string option with get, set
    abstract error: string option with get, set
    abstract error_description: string option with get, set

type [<AllowNullLiteral>] TokenEndpointOptions =
    abstract baseUrl: string with get, set
    abstract client_id: string with get, set
    abstract grant_type: string with get, set
    abstract timeout: float option with get, set
    abstract auth0Client: obj option with get, set
    abstract useFormData: bool option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] TokenEndpointResponse =
    abstract id_token: string with get, set
    abstract access_token: string with get, set
    abstract refresh_token: string option with get, set
    abstract expires_in: float with get, set
    abstract scope: string option with get, set

type [<AllowNullLiteral>] OAuthTokenOptions =
    inherit TokenEndpointOptions
    abstract code_verifier: string with get, set
    abstract code: string with get, set
    abstract redirect_uri: string with get, set
    abstract audience: string with get, set
    abstract scope: string with get, set

type [<AllowNullLiteral>] RefreshTokenOptions =
    inherit TokenEndpointOptions
    abstract refresh_token: string with get, set

type [<AllowNullLiteral>] JWTVerifyOptions =
    abstract iss: string with get, set
    abstract aud: string with get, set
    abstract id_token: string with get, set
    abstract nonce: string option with get, set
    abstract leeway: float option with get, set
    abstract max_age: float option with get, set
    abstract organizationId: string option with get, set
    abstract now: float option with get, set

type [<AllowNullLiteral>] IdToken =
    abstract __raw: string with get, set
    abstract name: string option with get, set
    abstract given_name: string option with get, set
    abstract family_name: string option with get, set
    abstract middle_name: string option with get, set
    abstract nickname: string option with get, set
    abstract preferred_username: string option with get, set
    abstract profile: string option with get, set
    abstract picture: string option with get, set
    abstract website: string option with get, set
    abstract email: string option with get, set
    abstract email_verified: bool option with get, set
    abstract gender: string option with get, set
    abstract birthdate: string option with get, set
    abstract zoneinfo: string option with get, set
    abstract locale: string option with get, set
    abstract phone_number: string option with get, set
    abstract phone_number_verified: bool option with get, set
    abstract address: string option with get, set
    abstract updated_at: string option with get, set
    abstract iss: string option with get, set
    abstract aud: string option with get, set
    abstract exp: float option with get, set
    abstract nbf: float option with get, set
    abstract iat: float option with get, set
    abstract jti: string option with get, set
    abstract azp: string option with get, set
    abstract nonce: string option with get, set
    abstract auth_time: string option with get, set
    abstract at_hash: string option with get, set
    abstract c_hash: string option with get, set
    abstract acr: string option with get, set
    abstract amr: string option with get, set
    abstract sub_jwk: string option with get, set
    abstract cnf: string option with get, set
    abstract sid: string option with get, set
    abstract org_id: string option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] User =
    abstract name: string option with get, set
    abstract given_name: string option with get, set
    abstract family_name: string option with get, set
    abstract middle_name: string option with get, set
    abstract nickname: string option with get, set
    abstract preferred_username: string option with get, set
    abstract profile: string option with get, set
    abstract picture: string option with get, set
    abstract website: string option with get, set
    abstract email: string option with get, set
    abstract email_verified: bool option with get, set
    abstract gender: string option with get, set
    abstract birthdate: string option with get, set
    abstract zoneinfo: string option with get, set
    abstract locale: string option with get, set
    abstract phone_number: string option with get, set
    abstract phone_number_verified: bool option with get, set
    abstract address: string option with get, set
    abstract updated_at: string option with get, set
    abstract sub: string option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] UserStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> User

type [<AllowNullLiteral>] FetchOptions =
    abstract ``method``: string option with get, set
    // @TODO
    // abstract headers: Record<string, string> option with get, set
    abstract credentials: FetchOptionsCredentials option with get, set
    abstract body: string option with get, set
    // @TODO
    // abstract signal: AbortSignal option with get, set

type GetTokenSilentlyVerboseResponse =
    // note: originally Omit<TokenEndpointResponse, string>
    abstract id_token: string with get, set
    abstract access_token: string with get, set
    abstract expires_in: float with get, set
    abstract scope: string option with get, set    

type [<StringEnum>] [<RequireQualifiedAccess>] BaseLoginOptionsDisplay =
    | Page
    | Popup
    | Touch
    | Wap

type [<StringEnum>] [<RequireQualifiedAccess>] BaseLoginOptionsPrompt =
    | None
    | Login
    | Consent
    | Select_account

type [<AllowNullLiteral>] Auth0ClientOptionsAuth0Client =
    abstract name: string with get, set
    abstract version: string with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] RedirectLoginOptionsRedirectMethod =
    | Replace
    | Assign

type [<StringEnum>] [<RequireQualifiedAccess>] FetchOptionsCredentials =
    | Include
    | Omit
