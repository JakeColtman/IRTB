// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open IRTB.User
open IRTB.Payment
open IRTB.UserMessages
open IRTB.Messages
open IRTB.MarketPlace

[<EntryPoint>]
let main argv = 
//    IRTB.Market.MarketMessages.Send (IRTB.Messages.AddBuyer (IRTB.User.create "Test User")
//    IRTB.Market.MarketMessages.Send "user2"
//    printfn "%A" "here"

    let user = IRTB.User.create "Test User"
    let msg = process_user_message_for_sending user (IRTB.UserMessages.Offer (IRTB.Payment.create (10) (100.0)))
    IRTB.MarketPlace.MarketPlace.add_to_market_place msg
    //IRTB.Market.MarketMessages.Send (IRTB.Messages.UserMessage ((IRTB.UserMessages.Offer (IRTB.Payment.create (10) (100.0)))))

    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
