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
    let msg = IRTB.Messages.convert_message_to_message_content (IRTB.Messages.AddBuyer user)
    IRTB.MarketPlace.MarketPlace.Send (IRTB.Messages.SystemMessage (IRTB.Messages.AddBuyer user)  )
    //IRTB.Market.MarketMessages.Send (IRTB.Messages.UserMessage ((IRTB.UserMessages.Offer (IRTB.Payment.create (10) (100.0)))))

    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
