namespace IRTB

module User = 
    
    open IRTB.Payment
    open IRTB.Interaction
    type Book = Map<Payment.Time, Payment.Amount>

        

    type User = {
        name: string;
        book: Book;
        connection: IRTB.Interaction.ConnectionApi
    }

    type BookUpdateResult = 
        | Success of User
        | Failure of string

    let add_payment (user: User) (payment: Payment) = 
        Success {user with book = user.book.Add (payment.time, payment.amount)} 
        
    let get_value_for_time (user: User) (time: Time) = 
        user.book.Item time

    let remove_payment (user: User) (payment: Payment) = 

        if (not (user.book.ContainsKey payment.time))
            then Failure "User doesn't have a payment for that date"
        else 
            let update_value = (get_value_for_time user payment.time) - payment.amount
            if update_value < 0.0 then 
                Failure "Insufficient funds"
            else
                add_payment user {payment with amount = update_value}

    let create (name: string) : User = 
        let book = [] |> Map.ofList
        let connection = create_connection
        {name = name; book =  book; connection = Interaction.create_connection}



