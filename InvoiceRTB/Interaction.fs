namespace IRTB

module Interaction = 

    open System.Net.Sockets
    open System
    open IRTB.UserMessages
//
//    let send_message (socket: Socket) (message: string) = 
//        async {
//            System.Text.Encoding.ASCII.GetBytes(message)
//                |> socket.Send
//                |> ignore
//            }

    type InMemoryConnection() = 
        let recieved = new System.Collections.Queue()

        member this.send_message msg = 
            printfn "%A" msg
            recieved.Enqueue msg

        member this.read = "Im a message"


    type user_communication = {
        send: UserMessage -> unit
        read: string
    }

    let InMemoryConnectionAPI (connection: InMemoryConnection) = {
        send = connection.send_message;
        read = connection.read
    }

    let create_connection = 
        let connection = InMemoryConnection()
        InMemoryConnectionAPI connection

    type EventPropogator = Destination

    let rec asyncSendInput (stream : NetworkStream) =
        async {
            let input = Console.Read() |> BitConverter.GetBytes
            input |> Array.iter stream.WriteByte
            return! asyncSendInput stream
        }

    type UserMailBox (api: user_communication) = 
        member this.api = api
        member this.outbound_box = MailboxProcessor.Start(fun inbox ->
            async { while true do

                        let! (msg : UserMessage) = inbox.Receive()
 
                        api.send msg

                  }
                )

        member this.inbound_box = MailboxProcessor.Start(fun inbox ->
            async { while true do

                        let! (msg : UserMessage) = inbox.Receive()
                        printfn "%A" "User recieved message"
                        printfn "%A" msg
                        api.send msg

                  }
                )

        member this.send msg = this.outbound_box.Post msg
        member this.read = "Hello"

    let create_user_communication = 
        let low_level_api = create_connection 
        let mailboxes = new UserMailBox(low_level_api)
        {
            read = mailboxes.read;
            send = mailboxes.send
        }

//
//
//    let propogate_events_to_client (client: TcpClient) = async {
//        let stream = client.GetStream()
//        while true do
//            do! stream.
//            do! Async.Sleep 1000.0 // sleep one second
//    }