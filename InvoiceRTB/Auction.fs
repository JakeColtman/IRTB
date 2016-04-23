namespace IRTB 

module Auction = 

    open IRTB.DomainEvents

    type Resolution = Bid list -> AuctionResult

    let highest_amount bids = 
        bids 
            |> List.maxBy (fun (x : Bid) -> x.bid.amount)
            |> Won 

    type Auction = {
        resolution : Resolution;
        auction_id: int;
        bids: Bid list;
        active: bool
    }

    let resolve_auction auction = 
        auction.resolution auction.bids

    let is_auction_active (auction: Auction) = 
        auction.bids.Length < 3

    let bid_on_auction (auction: Auction) (bid: Bid) = 
        let pre_state = is_auction_active auction
        let updated_auction = 
            match pre_state with 
                | true -> {auction with bids = List.append auction.bids [bid]}
                | false -> auction
        let post_state = is_auction_active updated_auction
        match post_state with 
            | true -> updated_auction
            | false -> {auction with active = false}
            