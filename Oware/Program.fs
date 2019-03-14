module Oware

type StartingPosition =
    | South
    | North

    
type House = {
    postion: StartingPosition
    locationnum: int
    seedCount: int
}
type Store = {
    capacity: int
    player: StartingPosition
}
type Board = {
    position: StartingPosition
    houses: House*House*House*House*House*House*House*House*House*House*House*House
    stores: Store*Store
}

let getSeeds n board = failwith "Not implemented"

let useHouse n board = failwith "Not implemented"

let start position = failwith "Not implemented"

let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
