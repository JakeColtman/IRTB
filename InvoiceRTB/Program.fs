// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open IRTB.Market

[<EntryPoint>]
let main argv = 
    let market = IRTB.Market.market highest_bidder
    market.Post "hello"
    printfn "%A" argv
    0 // return an integer exit code
