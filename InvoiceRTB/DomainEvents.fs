namespace IRTB

module DomainEvents = 

    open IRTB.User
    open IRTB.Payment
    open IRTB.Exchange

    type AuctionStart = {
        auction_id: int;
        selling_user: User;
        payment: Payment
    }

    type Bid = {
        auction_id: int;
        bidding_user: User;
        bid: Payment
    }

    type AuctionResult = 
        | Won of Bid
        | UnMet

    type AuctionEnd = {
        auction_id: int;
        auction_start: AuctionStart;
        result: AuctionResult
    }

    type DomainEvent = 
        | AuctionStart of AuctionStart
        | Bid of Bid
        | AuctionEnd of AuctionEnd



