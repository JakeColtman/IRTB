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
        bids: Bid list
    }

    let resolve_auction auction = 
        auction.resolution auction.bids

