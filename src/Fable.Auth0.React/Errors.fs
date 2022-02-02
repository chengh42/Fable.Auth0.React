// Generated using ts2fable 0.7.1
module rec Errors

open Fable.Core
open Fable.Core.JS

type Error = {
    Name: string
    Message: string
    Stack: string option
}

type [<AllowNullLiteral>] IExports =
    abstract OAuthError: OAuthErrorStatic

/// An OAuth2 error will come from the authorization server and will have at least an `error` property which will
/// be the error code. And possibly an `error_description` property
/// 
/// See: https://openid.net/specs/openid-connect-core-1_0.html#rfc.section.3.1.2.6
type [<AllowNullLiteral>] OAuthError =
    // inherit Error
    abstract name: string with get, set
    abstract message: string with get, set
    abstract stack: string option with get, set
    abstract error: string with get, set
    abstract error_description: string option with get, set

/// An OAuth2 error will come from the authorization server and will have at least an `error` property which will
/// be the error code. And possibly an `error_description` property
/// 
/// See: https://openid.net/specs/openid-connect-core-1_0.html#rfc.section.3.1.2.6
type [<AllowNullLiteral>] OAuthErrorStatic =
    [<Emit "new $0($1...)">] abstract Create: error: string * ?error_description: string -> OAuthError
