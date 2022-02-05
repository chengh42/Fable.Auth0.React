module Pages.Acknowledgement

open Feliz
open Feliz.DaisyUI
open Feliz.Router
open Shared

let View () =
    Html.div [
        Html.p [
            Html.span "The library was (initially) created using the amazing "
            Html.a "ts2fable" "https://github.com/fable-compiler/ts2fable"
            Html.span " tool and, of course, is built upon the powerful "
            Html.a "Fable" "https://fable.io/"
            Html.span " engine."
        ]
        Html.p [
            Html.span "Furthermore, the docs site relies on "
            Html.a "Feliz" "https://zaid-ajaj.github.io/Feliz/"
            Html.span " and "
            Html.a "Feliz.DaisyUI" "https://dzoukr.github.io/Feliz.DaisyUI/"
            Html.span " – the wonderful work that makes building React application in F# enjoyable."
        ]
        Html.p [
            Html.span "This library was originally created by the author for their (personal) need of using "
            Html.a "Auth0" "https://auth0.com/"
            Html.span " for authentication in "
            Html.a "SAFE stack" "https://safe-stack.github.io/"
            Html.span ". As it might be useful for anyone of similar needs, the library was published to the NuGet package directory and this documentation site was built based on the Auth0 tutorials in JavaScript. "
            Html.span "As a F# beginner, the author does wish to acknowledge that, although the author has done their best to ensure that the library is well transpiled from JavaScript,"
            Html.span " the library could contain mistakes and/or further improvements can be made. "
            Html.span "Therefore, contributions are welcomed! If you wish to submit changes, have a look at the "
            Daisy.link [
                link.accent
                link.hover
                prop.href (Router.format("contributing"))
                prop.text "Contributing"
            ]
            Html.span " section."
        ]
        Html.p [
            Html.span "The work is distributed under the "
            Html.a "MIT license" "https://github.com/chengh42/Fable.Auth0.React/blob/main/LICENSE"
            Html.span "."
        ]
        Html.img [
            prop.src "./logo.png"
            prop.alt "Fable.Auth0.React"
            prop.style [ style.maxHeight (length.em 10) ]
        ]
    ]