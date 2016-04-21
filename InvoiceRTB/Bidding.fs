namespace IRTB 

module Bidding = 

    open IRTB.Payment

    type Bid = {
        offered: Payment.Payment
        requested: Payment.Payment
    }

