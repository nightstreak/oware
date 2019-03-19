module Oware

type StartingPosition =   //players are named after their startingpostition 
    | South
    | North

    

type Store = {  //player
    capacity: int
    player: StartingPosition
    atCapacity : bool //I win (25)
}
type Board = {
    position: StartingPosition
    houses: (int*int*int*int*int*int*int*int*int*int*int*int) //first six belong to south 
    stores: Store*Store    ///puting players on the board
}

let getSeeds n board = failwith "Not implemented"

let useHouse n board = failwith "Not implemented"

let start p = "fail"

       
                        
        
             
      
let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
