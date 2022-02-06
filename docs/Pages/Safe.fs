module Pages.SafeStack

open Feliz
open Feliz.DaisyUI
open Shared

let View () =
    Html.div [
        Html.p [
            Html.span "See also: The Auth0 tutorial "
            Html.a ("ASP.NET Core Web API: Authorization", "https://auth0.com/docs/quickstart/backend/aspnet-core-webapi")
        ]
        Daisy.alert [
            alert.error
            prop.children [
                Html.div [
                    prop.style [ style.display.inlineElement ]
                    prop.children [
                        Html.span "This tutorial is still WIP! The corresponding WIP codebase and site are here: "
                        Html.a ([ link.primary; link.hover ], "https://github.com/chengh42/safe-auth0")
                        Html.span " and "
                        Html.a ([ link.primary; link.hover ], "https://safe-auth0.herokuapp.com/")
                    ]
                ]
            ]
        ]
    ]