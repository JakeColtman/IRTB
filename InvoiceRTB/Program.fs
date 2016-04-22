// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open IRTB.Market

[<EntryPoint>]
let main argv = 
    IRTB.Market.MarketMessages.Send "user1"
    IRTB.Market.MarketMessages.Send "user2"
    printfn "%A" "here"
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
