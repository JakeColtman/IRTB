namespace IRTB

module Payment = 

    type Time = int
    type Amount = float

    type Payment = Time * Amount

    let create date (time: Time) (amount: Amount) = 
        (time, amount)