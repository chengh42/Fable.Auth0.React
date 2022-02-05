module Shared

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

module Helpers =
    let [<Literal>] private ClassName = "className"

    let inline private getClasses (xs:IReactProperty list) =
        xs
        |> List.choose (unbox<string * obj> >> function
            | (k, v) when k = ClassName -> Some (string v)
            | _ -> None)

    let private extractClasses (xs:IReactProperty list) =
        xs
        |> List.rev
        |> List.fold (fun (classes, props) x ->
            match unbox<string * obj> x with
            | (k, v) when k = ClassName -> string v :: classes, props
            | _ -> classes, x :: props) ([], [])

    let combineClasses cn (xs:IReactProperty list) =
        xs
        |> extractClasses
        |> fun (classes, props) -> (cn :: classes |> prop.classes) :: props

    module Elm =
        let inline props buildFn (xs:IReactProperty list) (cn:string) = buildFn (combineClasses cn xs)

[<RequireQualifiedAccess>]
module highlight =
    [<Erase>]
    type language =
        static member inline bash = prop.className "bash"
        static member inline fsharp = prop.className "fsharp"
        static member inline javascript = prop.className "javascript"

let reactHighlight (props : IReactProperty list) : ReactElement =
    let propsObject = keyValueList CaseRules.LowerFirst props
    ofImport "default" "react-highlight" propsObject []

open Feliz.DaisyUI
open Feliz.DaisyUI.Operators

[<Erase>]
type Highlight =
    static member inline highlight props =
        Helpers.Elm.props reactHighlight props "highlight"
        |> Daisy.mockupCode

type Html =
    static member inline codeBlock (text: string) =
        Html.code [ prop.className "md-block"; prop.text text ]
    static member p (text: string) =
        Html.div [ prop.className "description"; prop.text text ]
    static member p (children :seq<ReactElement>) =
        Html.div [ prop.className "description"; prop.children children ]
    static member h1 (text: string) =
        Html.div [ color.textPrimary ++ prop.className "text-3xl font-bold"; prop.text text ]
    static member h2 (text: string) =
        Html.div [ color.textPrimary ++ prop.className "text-3xl font-bold"; prop.text text ]
    static member h3 (text: string) =
        Html.div [ color.textPrimary ++ prop.className "text-2xl font-bold"; prop.text text ]