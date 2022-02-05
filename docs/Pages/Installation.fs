[<RequireQualifiedAccess>]
module Pages.Installation

open Feliz
open Shared

[<ReactComponent>]
let View () =
    Html.div [
        Html.p "Install npm dependencies with npm or yarn:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using npm
npm install @auth0/auth0-react

# using yarn
yarn add @auth0/auth0-react
"""
        ]
        Html.p "And install nuget package with nuget or paket:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using nuget
Install-Package Fable.Auth0.React

# using paket
paket add Fable.Auth0.React
"""
        ]
    ]