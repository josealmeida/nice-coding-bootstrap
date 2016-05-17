//https://fsharpforfunandprofit.com/posts/fvsc-sum-of-squares/

// define the square function
let square x = x * x
// define the sumOfSquares function
let sumOfSquares n = 
   [1..n] |> List.map square |> List.sum
// try it
sumOfSquares 100 |> printfn "%i"

// define the square function
let squareF x = x * x
// define the sumOfSquares function
let sumOfSquaresF n = 
   [1.0 .. n] |> List.map squareF |> List.sum  // "1.0" is a float
sumOfSquaresF 100.0 |> printfn "%f"