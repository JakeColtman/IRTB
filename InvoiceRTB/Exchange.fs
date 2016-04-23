namespace IRTB 

module Exchange = 

    open IRTB.Payment

    type Exchange = {
        offered: Payment.Payment
        requested: Payment.Payment
    }

