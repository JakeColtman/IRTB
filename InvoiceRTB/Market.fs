namespace IRTB


module Market = 

    open IRTB.Bidding
    open IRTB.UserMessages
    open IRTB.Payment
    open IRTB.User

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

    let add_buyer market buyer = 
        {market with users = List.append market.users [buyer]}

    let add_seller market seller = 
        {market with users = List.append market.users [seller]}

    let process_offer market offer = 
        printfn "%A" market
        printfn "%A" offer
        market.users
            |> List.iter (fun (user: User) -> printfn "%A" offer )//user.connection.send_message offer)
        market

    let process_bid market bid = 
        printfn "%A" market
        printfn "%A" bid
        market.users
            |> List.iter (fun (user: User) -> printfn "%A" bid)//user.connection.send_message bid)
        market




