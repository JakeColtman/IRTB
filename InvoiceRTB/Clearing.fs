namespace IRTB

module Clearing = 

    open IRTB.Bidding

    type clear = Bid list -> unit

    let highest_bidder_clearing bids = 
        bids 
            |> List.maxBy (fun (x : Bid) -> x.offered)

