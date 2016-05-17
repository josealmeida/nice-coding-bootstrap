// https://fsharpforfunandprofit.com/posts/conciseness-functions-as-building-blocks/

//functions
let add2 x = x+2
let mult3 x = x*3
let square x = x * x
[1..10] |> List.map add2 |> printfn "add2 %A"
[1..10] |> List.map mult3 |> printfn "mult3 %A"
[1..10] |> List.map square |> printfn "square %A"


// new composed functions
let add2ThenMult3 = add2 >> mult3
let mult3ThenSquare = mult3 >> square
// test
add2ThenMult3 5
mult3ThenSquare 5
[1..10] |> List.map add2ThenMult3 |> printfn "add2ThenMult3 %A"
[1..10] |> List.map mult3ThenSquare |> printfn "mult3ThenSquare %A"


// helper functions;
let logMsg msg x = printf "%s%i" msg x; x     //without linefeed 
let logMsgN msg x = printfn "%s%i" msg x; x   //with linefeed
// new composed function with new improved logging!
let mult3ThenSquareLogged = 
   logMsg "before=" 
   >> mult3 
   >> logMsg " after mult3=" 
   >> square
   >> logMsgN " and after square result=" 
//test
mult3ThenSquareLogged 5
[1..10] |> List.map mult3ThenSquareLogged //apply to a whole list


//composition operator to collapse a list of functions into a single operation
let listOfFunctions = [
   mult3; 
   square;
   add2;
   logMsgN "result=";
   ]
// compose all functions in the list into a single one
let allFunctions = List.reduce (>>) listOfFunctions 
//test
allFunctions 5
