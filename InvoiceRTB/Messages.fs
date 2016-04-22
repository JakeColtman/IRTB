namespace IRTB

module Messages = 

    open IRTB.Bidding
    open IRTB.User
    open IRTB.UserMessages

    type SystemMessage = 
        | AddSeller of User
        | AddBuyer of User

    type MessageContent = 
        | SystemMessage of SystemMessage
        | UserMessage of UserMessage

    type Message = {
        from_user : User
        content : MessageContent
    }

