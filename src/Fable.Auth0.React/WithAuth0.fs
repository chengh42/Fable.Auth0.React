// Generated using ts2fable 0.7.1
module rec WithAuth0

open Fable.Core
open Fable.Core.JS
open Fable.React

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
[<Import("withAuth0","@auth0/auth0-react")>]
let withAuth0 (_: Component<'P, 'S>) : Component<'PP, 'SS> = jsNative

/// Components wrapped in `withAuth0` will have an additional `auth0` prop
type [<AllowNullLiteral>] WithAuth0Props =
    abstract auth0: Auth0Context.Auth0ContextInterface with get, set
