﻿// from https://fsharpforfunandprofit.com/posts/fvsc-download/

// "open" brings a .NET namespace into visibility
open System.Net
open System
open System.IO

// Fetch the contents of a web page
let fetchUrl callback url =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    callback reader url

let myCallback (reader:IO.StreamReader) url = 
    let html = reader.ReadToEnd()
    let html20 = html.Substring(0,20)
    printfn "Downloaded %s. First 20 is %s" url html20
    html      // return all the html

//test
let google = fetchUrl myCallback "http://google.com"



// build a function with the callback "baked in"
let fetchUrl2 = fetchUrl myCallback 

// test
let googleuk = fetchUrl2 "http://www.google.co.uk"
let bbc    = fetchUrl2 "http://news.bbc.co.uk"

// test with a list of sites
let sites = ["http://www.bing.com";
             "http://www.google.com";
             "http://www.yahoo.com"]

// process each site in the list
sites |> List.map fetchUrl2 