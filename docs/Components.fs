module Components

open Feliz
open Feliz.Router

/// <summary>
/// The simplest possible React component.
/// Shows a header with the text Hello World
/// </summary>
[<ReactComponent>]
let HelloWorld() = Html.h1 "Hello World"

/// <summary>
/// A stateful React component that maintains a counter
/// </summary>
[<ReactComponent>]
let Counter() =
    let (count, setCount) = React.useState(0)
    Html.div [
        Html.h1 count
        Html.button [
            prop.onClick (fun _ -> setCount(count + 1))
            prop.text "Increment"
        ]
    ]
