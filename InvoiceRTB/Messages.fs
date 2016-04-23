namespace IRTB

module Messages = 

    open IRTB.Bidding
    open IRTB.User
    open IRTB.UserMessages
    open IRTB.Market

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

    let message_fold sys_function user_function message = 
        match message with 
            | UserMessage user_message -> user_function user_message
            | SystemMessage sys_message -> sys_function sys_message

    let user_message_fold offer_funct bid_funct market message = 
        match message with 
            | Offer payment -> offer_funct market payment 
            | Bid bid -> bid_funct market bid

    let sys_message_fold add_seller_funct add_buyer_funct market message = 
        match message with 
            | AddSeller seller -> add_seller_funct market seller
            | AddBuyer buyer -> add_buyer_funct market buyer

    type user_message_api = {
        payment: Market -> Payment.Payment -> Market;
        bid: Market -> Bid -> Market
    }

    type sys_message_api = {
        add_buyer: Market -> User -> Market;
        add_seller: Market -> User -> Market
    }

    type market_api = {
        user_api: user_message_api;
        sys_api: sys_message_api
    }

    let process_message market_api market message = 
        let user_function = 
            user_message_fold market_api.user_api.payment market_api.user_api.bid market
        let sys_function = 
            sys_message_fold market_api.sys_api.add_seller market_api.sys_api.add_buyer market
            
        let processing_funct = 
            message_fold sys_function user_function

        processing_funct message

    let process_user_message_for_sending from_user message = 
        {
            from_user = from_user;
            content =  UserMessage message
        }

    let process_system_message_for_sending message = 
        {
            from_user = User.create "System";
            content =  UserMessage message
        }