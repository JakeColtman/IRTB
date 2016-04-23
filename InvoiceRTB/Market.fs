namespace IRTB


module Market = 

    open IRTB.Bidding
    open IRTB.UserMessages
    open IRTB.Payment
    open IRTB.User

    type Market = {
        users: User list
        auctions: Auction list
    }

    let add_buyer market buyer = 
        {market with users = List.append market.users [buyer]}

    let add_seller market seller = 
        {market with users = List.append market.users [seller]}

    let inform_all_users market message = 
        market.users
            |> List.iter (fun (user: User) -> user.connection.send message)

    let auction_start market start = 
        printfn "%A" market
        printfn "%A" start
        inform_all_users market start
        market

    let process_bid market bid = 
        printfn "%A" market
        printfn "%A" bid
        market

    let auction_end market ending = 
        printfn "%A" market
        printfn "%A" ending
        inform_all_users market ending
        market





