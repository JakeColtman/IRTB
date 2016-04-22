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
        users: string list
    }

    let message_handler msg = 
        match msg with 
            | AddSeller seller -> printfn "%A" "Added seller"
            | AddBuyer buyer -> printfn "%A" "Added buyer"
            | MakeBuyBid bid -> printfn "%A" "Registered a bid to buy"

    type MarketMessages () = 

        static let add_user (market: Market) (user: string) = 
            {market with users = List.append market.users [user]}

        static let agent = MailboxProcessor.Start(fun inbox -> 

            let rec messageLoop old_market = async{

                let! msg = inbox.Receive()

                message_handler msg

                return! messageLoop old_market 
                }

            messageLoop {users = []}
            )

        static member Send i = agent.Post i
