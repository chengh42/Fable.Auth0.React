// Generated using ts2fable 0.7.1
module rec UseAuth0

open Fable.Core
open Fable.Core.JS
open Fable.Core.JsInterop

[<Import("useAuth0","@auth0/auth0-react")>]
let useAuth0 (): Auth0Context.Auth0ContextInterface<'TUser> = jsNative
