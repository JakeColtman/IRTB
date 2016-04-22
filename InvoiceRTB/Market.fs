namespace IRTB
#nowarn "40"

module Market = 

    open IRTB.Bidding
    open IRTB.Payment
    open IRTB.User
    open IRTB.Messages

    type clear = Bid list -> unit

    let highest_bidder bids = 
        bids 
            |> List.maxBy (fun (x : Bid) -> x.offered)

    let average_offer_amount bids = 
        bids 
            |> List.averageBy (fun (x : Bid) -> x.offered.amount)

    type Market = {
        users: User list
    }

    let message_handler message_content = 
        match message_content with 
            | AddSeller seller -> printfn "%A" "Added seller"
            | AddBuyer buyer -> printfn "%A" "Added buyer"
            | MakeBuyBid bid -> printfn "%A" "Registered a bid to buy"

    type MarketMessages () = 

        static let add_user (market: Market) (user: User) = 
            {market with users = List.append market.users [user]}

        static let send_to_users users message = 
            users
                |> List.iter (fun (user: User) -> user.connection.send_message message)

        static let agent = MailboxProcessor.Start(fun inbox -> 

            let rec messageLoop (market : Market) = async{

                let! msg = inbox.Receive()

                send_to_users market.users msg

                return! messageLoop market 
                }

            messageLoop {users = []}
            )

        static member Send i = agent.Post i
