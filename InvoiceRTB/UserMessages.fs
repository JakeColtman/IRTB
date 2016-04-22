namespace IRTB

module UserMessages = 
    open IRTB.Payment
    open IRTB.Bidding

    type UserMessage = 
        | Offer of Payment
        | Bid of Bid
         

