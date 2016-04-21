namespace IRTB

module User = 
    
    open IRTB.Payment

    type User = {
        name: string;
        payments : Payment list
    }

    let add_payment (user: User) (payment: Payment) = 
        {name = user.name; payments = List.append user.payments [payment]}

    let create (name: string) : User = 
        {name = name; payments = []}



