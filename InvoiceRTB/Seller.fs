namespace IRTB

module Seller = 
    
    open IRTB.Payment

    type Seller = {
        name: string;
        payments : Payment list
    }

    let create (name: string) : Seller = 
        {name = name; payments = []}

