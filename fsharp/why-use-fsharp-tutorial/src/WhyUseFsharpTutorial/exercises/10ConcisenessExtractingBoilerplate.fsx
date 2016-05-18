//https://fsharpforfunandprofit.com/posts/conciseness-extracting-boilerplate/

//product of numbers
let product n = 
    let initialValue = 1
    let action productSoFar x = productSoFar * x
    [1..n] |> List.fold action initialValue
//test
product 10


//sum of odd numbers
let sumOfOdds n = 
    let initialValue = 0
    let action sumSoFar x = if x%2=0 then sumSoFar else sumSoFar+x 
    [1..n] |> List.fold action initialValue
//test
sumOfOdds 10


//alternating sum of the numbers
let alternatingSum n = 
    let initialValue = (true,0)
    let action (isNeg,sumSoFar) x = if isNeg then (false,sumSoFar-x)
                                             else (true ,sumSoFar+x)
    [1..n] |> List.fold action initialValue |> snd
//test
alternatingSum 100


//sum of squares
let sumOfSquaresWithFold n = 
    let initialValue = 0
    let action sumSoFar x = sumSoFar + (x*x)
    [1..n] |> List.fold action initialValue 
//test
sumOfSquaresWithFold 100


//"maximum" element of a list
type NameAndSize= {Name:string;Size:int}
//let maxNameAndSize list = 
//    
//    let innerMaxNameAndSize initialValue rest = 
//        let action maxSoFar x = if maxSoFar.Size < x.Size then x else maxSoFar
//        rest |> List.fold action initialValue 
//
//    // handle empty lists
//    match list with
//    | [] -> 
//        None
//    | first::rest -> 
//        let max = innerMaxNameAndSize first rest
//        Some max


// use the built in maxBy function
//list |> List.maxBy (fun item -> item.Size)
//[] |> List.maxBy (fun item -> item.Size)

// use the built in maxBy function
// but safely
let maxNameAndSize list = 
    match list with
    | [] -> 
        None
    | _ -> 
        let max = list |> List.maxBy (fun item -> item.Size)
        Some max

//test
let list = [
    {Name="Alice"; Size=10}
    {Name="Bob"; Size=1}
    {Name="Carol"; Size=18}
    {Name="David"; Size=5}
    ]    
maxNameAndSize list
//maxNameAndSize []
