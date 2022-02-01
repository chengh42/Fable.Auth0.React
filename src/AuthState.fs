// Generated using ts2fable 0.7.1
module rec AuthState
open System
open Fable.Core
open Fable.Core.JS
open Global

type Error = System.Exception

[<Import("initialAuthState","@auth0/auth0-react")>]
let initialAuthState: AuthState = jsNative

type AuthState =
    AuthState<obj>

/// The auth state which, when combined with the auth methods, make up the return object of the `useAuth0` hook.
type [<AllowNullLiteral>] AuthState<'TUser> =
    abstract error: Error option with get, set
    abstract isAuthenticated: bool with get, set
    abstract isLoading: bool with get, set
    abstract user: 'TUser option with get, set
