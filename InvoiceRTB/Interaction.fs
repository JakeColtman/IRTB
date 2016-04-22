namespace IRTB

module Interaction = 

    open System.Net.Sockets
    open System

    let send_message (socket: Socket) (message: string) = 
        async {
            System.Text.Encoding.ASCII.GetBytes(message)
                |> socket.Send
                |> ignore
            }

    open System.Net.Sockets

    type InMemoryConnection() = 
        let recieved = new System.Collections.Queue()

        member this.send_message msg = 
            printfn "%A" msg
            recieved.Enqueue msg

        member this.read = "Im a message"


    type ConnectionApi = {
        send_message: string -> unit
        read: string
    }

    let InMemoryConnectionAPI (connection: InMemoryConnection) = {
        send_message = connection.send_message;
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
//
//
//    let propogate_events_to_client (client: TcpClient) = async {
//        let stream = client.GetStream()
//        while true do
//            do! stream.
//            do! Async.Sleep 1000.0 // sleep one second
//    }