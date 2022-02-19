[<RequireQualifiedAccess>]
module Pages.Installation

open Feliz
open Shared

[<ReactComponent>]
let FemtoInstallation () =
    Html.div [
        Html.p [
            Html.span "The easiest way is to use "
            Html.a ("Femto CLI", "https://github.com/zaid-ajaj/femto")
            Html.span ", which will take care of all dependencies including npm libraries."
        ]
        Highlight.highlight [
            highlight.language.bash
            prop.text """femto install Fable.Auth0.React"""
        ]
    ]

[<ReactComponent>]
let ManualInstallation () =
    Html.div [
        Html.p "Install npm dependencies with npm or yarn:"
        Highlight.highlight [
            highlight.language.bash
            prop.text """# using npm
npm install @auth0/auth0-react@1.9.0

# using yarn
yarn add @auth0/auth0-react@1.9.0
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

[<ReactComponent>]
let View () =
    Html.div [
        Html.h3 "Using femto"
        FemtoInstallation ()
        Html.p [ ]
        Html.h3 "Manual installation"
        ManualInstallation ()
    ]