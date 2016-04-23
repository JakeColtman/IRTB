namespace IRTB


module Market = 

    open IRTB.Auction
    open IRTB.DomainEvents
    open IRTB.Payment
    open IRTB.User

    type Market = {
        users: User list
        auctions: Map<int, Auction>
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
        let new_auction = Auction.create start
        {market with auctions = Map.add new_auction.auction_id new_auction market.auctions}

    let make_bid_on_auction market (bid: Bid) = 
        if market.auctions.ContainsKey bid.auction_id then 
            let auction = market.auctions.Item bid.auction_id
            let update = IRTB.Auction.bid_on_auction auction bid
            let updated_auctions = Map.add bid.auction_id update market.auctions 
            {market with auctions = updated_auctions}
        else 
            market
        

    let auction_end market ending = 
        printfn "%A" market
        printfn "%A" ending
        inform_all_users market ending
        market





