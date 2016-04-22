namespace IRTB
#nowarn "40"

module Market = 

    open IRTB.Bidding
    open IRTB.UserMessages
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

    type MarketMessages () = 

        static let add_user (market: Market) (user: User) = 
            {market with users = List.append market.users [user]}

        static let send_to_users users message = 
            printfn "%A" users
            printfn "%A" message
            users
                |> List.iter (fun (user: User) -> user.connection.send_message message)

        static let process_message market message = 
            match message with 
                | UserMessage usermessage -> 
                    send_to_users market.users usermessage
                    market
                | SystemMessage systemmessage -> 
                    match systemmessage with 
                        | AddSeller x -> 
                            add_user market x
                        | AddBuyer x -> 
                            add_user market x

        static let agent = MailboxProcessor.Start(fun inbox -> 

            let rec messageLoop (market : Market) = async{

                let! msg = inbox.Receive()

                let updated_market = process_message market msg

                return! messageLoop updated_market 
                }

            messageLoop {users = []}
            )

        static member Send i = agent.Post i
