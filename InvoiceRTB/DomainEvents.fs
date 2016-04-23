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

    type AuctionEnd = {
        auction_id: int;
        auction_start: AuctionStart;
        winning_bid: Bid
    }



