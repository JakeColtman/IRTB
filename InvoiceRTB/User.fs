namespace IRTB

module User = 
    
    open IRTB.Payment

    type Book = Map<Payment.Time, Payment.Amount>

    type User = {
        name: string;
        book: Book
    }

    let add_payment (user: User) (payment: Payment) = 
        user.book.Add payment

    let create (name: string) : User = 
        let book = [] |> Map.ofList
        {name = name; book =  book}



