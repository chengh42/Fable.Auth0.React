module Tests

open Fable.Mocha
open Fable.Auth0.React

let all =
    testList "Example tests" [

        testCase "say hi" <| fun () ->
            Expect.equal (Say.hello "John") "Hello John" "say hi works"

    ]

[<EntryPoint>]
let main _ = Mocha.runTests all