module Oware

type StartingPosition =
    | South
    | North

    

type Store = {
    capacity: int
    player: StartingPosition
}
type Board = {
    position: StartingPosition
    houses: int*int*int*int*int*int*int*int*int*int*int*int
    stores: Store*Store
}

let getSeeds n board =
    let a, b, c, d, e, _ = board.houses
    let z = x


let useHouse n board = failwith "Not implemented"

let start position = failwith "Not implemented"

let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
