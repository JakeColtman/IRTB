namespace IRTB

module Messages = 

    open IRTB.Bidding
    open IRTB.User

    type Message = 
        | AddSeller of User
        | AddBuyer of User
        | MakeBuyBid of Bid

