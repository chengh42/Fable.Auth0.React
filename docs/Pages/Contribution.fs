module Pages.Contribution

open Feliz
open Shared

type Snippet =
    static member devCmd = """# docs
dotnet run # development
dotnet run build # production

# package
dotnet run pack
"""
    static member xmlFsproj = """<?xml version="1.0" encoding="utf-8"?>
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <Version>{ Package version }</Version>
    <PackageReleaseNotes>
      { Release note }
    </PackageReleaseNotes>
    <!-- other properties -->
  </PropertyGroup>
  <!-- other items -->
</Project>
"""

[<ReactComponent>]
let View () =
    Html.div [
        Html.p [
            Html.span "Contribution is welcomed! You can find the source code on "
            Html.a "GitHub repository" "https://github.com/chengh42/Fable.Auth0.React"
            Html.span "."
        ]
        Html.p "For development, run"
        Highlight.highlight [
            highlight.language.bash
            prop.text Snippet.devCmd
        ]
        Html.p "The packed NuGet package can be found under the src/Fable.Auth0.React/bin/Release directory."
        Html.p "Don't forget to, before packing, update NuGet package metadata. To do so, edit in the .fsproj file,"
        Highlight.highlight [
            highlight.language.xml
            prop.text Snippet.xmlFsproj
        ]
        Html.p [
            Html.span "Feel free to put up a pull request! Or if you wish to (jointly) maintain the site and library, get in touch via GitHub "
            Html.span [ Html.i [ prop.className "far fa-smile-wink" ] ]
        ]
    ]