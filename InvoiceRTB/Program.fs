// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open IRTB.User

[<EntryPoint>]
let main argv = 
//    IRTB.Market.MarketMessages.Send (IRTB.Messages.AddBuyer (IRTB.User.create "Test User")
//    IRTB.Market.MarketMessages.Send "user2"
//    printfn "%A" "here"

    let user = IRTB.User.create "Test User"
    user.connection.send_message "hello"

    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
