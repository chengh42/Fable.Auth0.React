module App

open Elmish
open Elmish.React

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkSimple Index.init Index.update Index.view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "root"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
