namespace IRTB

module Seller = 
    
    open IRTB.Payment

    type Seller = {
        name: string;
        payments : Payment list
    }

    let add_invoice (seller: Seller) (payment: Payment) = 
        {name = seller.name; payments = List.append seller.payments [payment]}

    let create (name: string) : Seller = 
        {name = name; payments = []}

