module Oware

type StartingPosition =   //players are named after their startingpostition; south always starts
    | South of int 
    | North of int 

    

type Store = {                      // each player has their main store 
    capacity: int
    player: StartingPosition
    smallHouse: (int*int*int*int*int*int)
}
type Board = {
    position: StartingPosition
    stores: Store*Store    ///puting players on the board
}
type GameState = 
     |Ready
     |South'sTurn
     |North'sTurn
     |Draw 
     |SouthWin 
     |NorthWin


let getSeeds n board = failwith "Not implemented"

let useHouse n board = failwith "Not implemented"

let start position = failwith "Not implemented"
   
                        
        
             
      
let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
