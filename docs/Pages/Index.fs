[<RequireQualifiedAccess>]
module Pages.Index

open Feliz
open CodeSnippet

[<ReactComponent>]
let View () =
    Html.div [
        Html.h2 "Installation"
        Html.p "Install npm dependencies:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using npm
npm install @auth0/auth0-react

# using yarn
yarn add @auth0/auth0-react
"""
        ]
        Html.p "And install nuget package:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using nuget
Install-Package Fable.Auth0.React

# using paket
paket add Fable.Auth0.React
"""
        ]
    ]