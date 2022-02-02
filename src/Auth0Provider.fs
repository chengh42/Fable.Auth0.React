// Generated using ts2fable 0.7.1
module rec Auth0Provider

open Fable.Core
open Fable.Core.JS
open Fable.React
open Fable.Core.JsInterop

// @TODO
// type CacheLocation = @auth0_auth0_spa_js.CacheLocation
// type ICache = @auth0_auth0_spa_js.ICache

/// ```jsx
/// <Auth0Provider
///   domain={domain}
///   clientId={clientId}
///   redirectUri={window.location.origin}>
///   <MyApp />
/// </Auth0Provider>
/// ```
///
/// Provides the Auth0Context to its child components.
let Auth0Provider (opts : Auth0ProviderOptions) children : ReactElement =
    let propsObject = opts |> JS.Constructors.Object.entries |> createObj
    ofImport "Auth0Provider" "@auth0/auth0-react" propsObject children

/// The state of the application before the user was redirected to the login page.
type [<AllowNullLiteral>] AppState =
    abstract returnTo: string option with get, set
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

/// The main configuration to instantiate the `Auth0Provider`.
type [<AllowNullLiteral>] Auth0ProviderOptions =
    /// The child nodes your Provider has wrapped
    abstract children: ReactElement option with get, set
    /// By default this removes the code and state parameters from the url when you are redirected from the authorize page.
    /// It uses `window.history` but you might want to overwrite this if you are using a custom router, like `react-router-dom`
    /// See the EXAMPLES.md for more info.
    abstract onRedirectCallback: (AppState -> unit) option with get, set
    /// By default, if the page url has code/state params, the SDK will treat them as Auth0's and attempt to exchange the
    /// code for a token. In some cases the code might be for something else (another OAuth SDK perhaps). In these
    /// instances you can instruct the client to ignore them eg
    /// 
    /// ```jsx
    /// <Auth0Provider
    ///    clientId={clientId}
    ///    domain={domain}
    ///    skipRedirectCallback={window.location.pathname === '/stripe-oauth-callback'}
    /// >
    /// ```
    abstract skipRedirectCallback: bool option with get, set
    /// Your Auth0 account domain such as `'example.auth0.com'`,
    /// `'example.eu.auth0.com'` or , `'example.mycompany.com'`
    /// (when using [custom domains](https://auth0.com/docs/custom-domains))
    abstract domain: string with get, set
    /// The issuer to be used for validation of JWTs, optionally defaults to the domain above
    abstract issuer: string option with get, set
    /// The Client ID found on your Application settings page
    abstract clientId: string with get, set
    /// The default URL where Auth0 will redirect your browser to with
    /// the authentication result. It must be whitelisted in
    /// the "Allowed Callback URLs" field in your Auth0 Application's
    /// settings. If not provided here, it should be provided in the other
    /// methods that provide authentication.
    abstract redirectUri: string option with get, set
    /// The value in seconds used to account for clock skew in JWT expirations.
    /// Typically, this value is no more than a minute or two at maximum.
    /// Defaults to 60s.
    abstract leeway: float option with get, set
    
    // @TODO
    // /// The location to use when storing cache data. Valid values are `memory` or `localstorage`.
    // /// The default setting is `memory`.
    // /// 
    // /// Read more about [changing storage options in the Auth0 docs](https://auth0.com/docs/libraries/auth0-single-page-app-sdk#change-storage-options)
    // abstract cacheLocation: CacheLocation option with get, set
    
    // @TODO
    // /// Specify a custom cache implementation to use for token storage and retrieval. This setting takes precedence over `cacheLocation` if they are both specified.
    // /// 
    // /// Read more about [creating a custom cache](https://github.com/auth0/auth0-spa-js#creating-a-custom-cache)
    // abstract cache: ICache option with get, set
    /// If true, refresh tokens are used to fetch new access tokens from the Auth0 server. If false, the legacy technique of using a hidden iframe and the `authorization_code` grant with `prompt=none` is used.
    /// The default setting is `false`.
    /// 
    /// **Note**: Use of refresh tokens must be enabled by an administrator on your Auth0 client application.
    abstract useRefreshTokens: bool option with get, set
    /// A maximum number of seconds to wait before declaring background calls to /authorize as failed for timeout
    /// Defaults to 60s.
    abstract authorizeTimeoutInSeconds: float option with get, set
    /// Changes to recommended defaults, like defaultScope
    abstract advancedOptions: Auth0ProviderOptionsAdvancedOptions option with get, set
    /// Maximum allowable elapsed time (in seconds) since authentication.
    /// If the last time the user authenticated is greater than this value,
    /// the user must be reauthenticated.
    abstract maxAge: U2<string, float> option with get, set
    /// The default scope to be used on authentication requests.
    /// The defaultScope defined in the Auth0Client is included
    /// along with this scope
    abstract scope: string option with get, set
    /// The default audience to be used for requesting API access.
    abstract audience: string option with get, set
    /// The Id of an organization to log in to.
    /// 
    /// This will specify an `organization` parameter in your user's login request and will add a step to validate
    /// the `org_id` claim in your user's ID Token.
    abstract organization: string option with get, set
    /// The Id of an invitation to accept. This is available from the user invitation URL that is given when participating in a user invitation flow.
    abstract invitation: string option with get, set
    /// The name of the connection configured for your application.
    /// If null, it will redirect to the Auth0 Login Page and show
    /// the Login Widget.
    abstract connection: string option with get, set
    /// If you need to send custom parameters to the Authorization Server,
    /// make sure to use the original parameter name.
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] Auth0ProviderOptionsAdvancedOptions =
    /// The default scope to be included with all requests.
    /// If not provided, 'openid profile email' is used. This can be set to `null` in order to effectively remove the default scopes.
    /// 
    /// Note: The `openid` scope is **always applied** regardless of this setting.
    abstract defaultScope: string option with get, set
