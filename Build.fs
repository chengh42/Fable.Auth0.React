open Fake.Core
open Fake.IO
open Farmer
open Farmer.Builders

open Helpers

initializeContext()

let clientPath = Path.getFullName "docs"
let publishPath = Path.getFullName "publish/app"

Target.create "Clean" (fun _ ->
    Shell.cleanDir publishPath
    run dotnet "fable clean --yes" clientPath // Delete *.fs.js files created by Fable
)

Target.create "InstallClient" (fun _ -> run npm "install" ".")

Target.create "Bundle" (fun _ ->
    run dotnet "fable -o output -s --run webpack -p" clientPath
)

Target.create "Run" (fun _ ->
    run dotnet "fable watch -o output -s --run webpack-dev-server" clientPath
)

Target.create "Format" (fun _ ->
    run dotnet "fantomas . -r" "docs"
)

Target.create "Pack" (fun _ ->
    run dotnet "pack -c Release" "src/Fable.Auth0.React"
)

open Fake.Core.TargetOperators

let dependencies = [
    "Clean"
        ==> "InstallClient"
        ==> "Bundle"

    "Clean"
        ==> "InstallClient"
        ==> "Run"

    "Pack"
]

[<EntryPoint>]
let main args = runOrDefault args