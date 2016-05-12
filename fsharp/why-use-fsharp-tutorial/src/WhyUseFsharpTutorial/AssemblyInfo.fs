namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("WhyUseFsharpTutorial")>]
[<assembly: AssemblyProductAttribute("WhyUseFsharpTutorial")>]
[<assembly: AssemblyDescriptionAttribute("Why Use F# tutorial at https://fsharpforfunandprofit.com/why-use-fsharp/")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
    let [<Literal>] InformationalVersion = "1.0"
