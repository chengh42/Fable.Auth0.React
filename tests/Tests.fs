module Tests

open Fable.Mocha
open Fable.Auth0.React

let all =
    testList "Example tests" [
        testCase "say hi" <| fun () ->
            Expect.notEqual typeof<string> typeof<Auth0ContextInterface> "type Auth0ContextInterface"
    ]

[<EntryPoint>]
let main _ = Mocha.runTests all