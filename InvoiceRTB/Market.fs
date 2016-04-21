namespace IRTB
#nowarn "40"

module Market = 

    open IRTB.Bidding

    type clear = Bid list -> unit

    let highest_bidder bids = 
        bids 
            |> List.maxBy (fun (x : Bid) -> x.offered)

    let average_offer_amount bids = 
        bids 
            |> List.averageBy (fun (x : Bid) -> x.offered.amount)

    let market bid_resolution = 
        MailboxProcessor.Start(fun inbox ->

            let rec loop = async {
                let! msg = inbox.Receive()
                printfn "%A" msg
                return! loop
                }
            loop) 
