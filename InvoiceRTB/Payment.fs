namespace IRTB

module Payment = 

    type Time = int
    type Amount = float

    type Payment = {time :Time ; amount: Amount}

    let create (time: Time) (amount: Amount) = 
        {time = time ; amount = amount}