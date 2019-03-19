module Oware

type StartingPosition =   //players are named after their startingpostition; south always starts
    | South 
    | North  

    


type Store = {                      // each player has their main store 
    capacity: int
    player: StartingPosition
    smallHouse: (int*int*int*int*int*int)
}

type GameState =
     |South'sTurn
     |North'sTurn
     |Draw 
     |SouthWin 
     |NorthWin

type Board = {
    position: StartingPosition
    stores: Store*Store
    gameState: GameState
}



let getSeeds n board = failwith "Not implement3ed"

let useHouse n board = failwith "Not implemented"

let start pos = 
    let pie = 
        match pos with
        | South-> South'sTurn 
        | North-> North'sTurn
        
    let A = {Store.capacity=0;player=pos;smallHouse=(4,4,4,4,4,4)}
    let B = {Store.capacity=0;player=pos;smallHouse=(4,4,4,4,4,4)}

    {Board.position=pos;stores=(A,B);gameState=pie}
   
                        
        
             
      
let score board = failwith "Not implemented"

let gameState board = 
    match board.gameState with
    |South'sTurn -> "South's Turn"
    |North'sTurn -> "North's Turn"
    |Draw -> "Draw"
    |SouthWin -> "South Won"
    |NorthWin -> "North Won"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
