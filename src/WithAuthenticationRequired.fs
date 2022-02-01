// Generated using ts2fable 0.7.1
module rec WithAuthenticationRequired

open Fable.Core
open Fable.Core.JS
open Fable.React

type RedirectLoginOptions = Global.RedirectLoginOptions
type User = Global.User

/// ```js
/// const MyProtectedComponent = withAuthenticationRequired(MyComponent);
/// ```
///
/// When you wrap your components in this Higher Order Component and an anonymous user visits your component
/// they will be redirected to the login page and returned to the page they we're redirected from after login.
[<Import("withAuthenticationRequired","@auth0/auth0-react")>]
let withAuthenticationRequired (_: Component<'P, 'S>) (options: WithAuthenticationRequiredOptions) : FunctionComponent = jsNative

/// Options for the withAuthenticationRequired Higher Order Component
type [<AllowNullLiteral>] WithAuthenticationRequiredOptions =
    /// ```js
    /// withAuthenticationRequired(Profile, {
    ///    returnTo: '/profile'
    /// })
    /// ```
    /// 
    /// or
    /// 
    /// ```js
    /// withAuthenticationRequired(Profile, {
    ///    returnTo: () => window.location.hash.substr(1)
    /// })
    /// ```
    /// 
    /// Add a path for the `onRedirectCallback` handler to return the user to after login.
    abstract returnTo: U2<string, (unit -> string)> option with get, set
    /// ```js
    /// withAuthenticationRequired(Profile, {
    ///    onRedirecting: () => <div>Redirecting you to the login...</div>
    /// })
    /// ```
    /// 
    /// Render a message to show that the user is being redirected to the login.
    abstract onRedirecting: (unit -> ReactElement) option with get, set
    /// ```js
    /// withAuthenticationRequired(Profile, {
    ///    loginOptions: {
    ///      appState: {
    ///        customProp: 'foo'
    ///      }
    ///    }
    /// })
    /// ```
    /// 
    /// Pass additional login options, like extra `appState` to the login page.
    /// This will be merged with the `returnTo` option used by the `onRedirectCallback` handler.
    abstract loginOptions: RedirectLoginOptions option with get, set
    /// Check the user object for JWT claims and return a boolean indicating
    /// whether or not they are authorized to view the component.
    abstract claimCheck: (User -> bool) option with get, set
