namespace Fable.Auth0.React

[<AutoOpen>]
module Core =
    /// The state of the application before the user was redirected to the login page.
    type AppState = Auth0Provider.AppState
    /// The main configuration to instantiate the `Auth0Provider`.
    type Auth0ProviderOptions = Auth0Provider.Auth0ProviderOptions
    /// Components wrapped in `withAuth0` will have an additional `auth0` prop
    type WithAuth0Props = WithAuth0.WithAuth0Props
    /// Options for the withAuthenticationRequired Higher Order Component
    type WithAuthenticationRequiredOptions = WithAuthenticationRequired.WithAuthenticationRequiredOptions
    /// Contains the authenticated state and authentication methods provided by the `useAuth0` hook.
    type Auth0ContextInterface = Auth0Context.Auth0ContextInterface
    type RedirectLoginOptions = Auth0Context.RedirectLoginOptions
    type PopupLoginOptions = Global.PopupLoginOptions
    type PopupConfigOptions = Global.PopupConfigOptions
    type GetIdTokenClaimsOptions = Global.GetIdTokenClaimsOptions
    type GetTokenWithPopupOptions = Global.GetTokenWithPopupOptions
    type LogoutOptions = Global.LogoutOptions
    type LogoutUrlOptions = Global.LogoutUrlOptions
    type CacheLocation = Global.CacheLocation
    type GetTokenSilentlyOptions = Global.GetTokenSilentlyOptions
    type IdToken = Global.IdToken
    type User = Global.User
    type OAuthError = Errors.OAuthError

    // @TODO
    // type ICache = Global.ICache
    // type InMemoryCache = Global.InMemoryCache
    // type LocalStorageCache = Global.LocalStorageCache
    // type Cacheable = Global.Cacheable

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
    let Auth0Provider opts = Auth0Provider.Auth0Provider opts

    /// ```js
    /// const {
    ///   // Auth state:
    ///   error,
    ///   isAuthenticated,
    ///   isLoading,
    ///   user,
    ///   // Auth methods:
    ///   getAccessTokenSilently,
    ///   getAccessTokenWithPopup,
    ///   getIdTokenClaims,
    ///   loginWithRedirect,
    ///   loginWithPopup,
    ///   logout,
    /// } = useAuth0<TUser>();
    /// ```
    /// Use the `useAuth0` hook in your components to access the auth state and methods.
    /// 
    /// TUser is an optional type param to provide a type to the `user` field.
    let useAuth0 () = UseAuth0.useAuth0 ()

    /// ```jsx
    /// class MyComponent extends Component {
    ///   render() {
    ///     // Access the auth context from the `auth0` prop
    ///     const { user } = this.props.auth0;
    ///     return <div>Hello {user.name}!</div>
    ///   }
    /// }
    /// // Wrap your class component in withAuth0
    /// export default withAuth0(MyComponent);
    /// ```
    /// 
    /// Wrap your class components in this Higher Order Component to give them access to the Auth0Context
    let withAuth0 = WithAuth0.withAuth0

    /// ```js
    /// const MyProtectedComponent = withAuthenticationRequired(MyComponent);
    /// ```
    ///
    /// When you wrap your components in this Higher Order Component and an anonymous user visits your component
    /// they will be redirected to the login page and returned to the page they we're redirected from after login.
    let withAuthenticationRequired = WithAuthenticationRequired.withAuthenticationRequired

    /// The Auth0 Context
    let Auth0Context = Auth0Context.Auth0Context