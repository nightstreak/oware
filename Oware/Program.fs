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
    stores: Store*Store    ///puting players on the board   (first store belongs to south)
    gameState: GameState
}



let getSeeds n board = //houses are numbered 1 to 12 with the first 6 being the houses in South (first store belongs to south)
    match board with //structuly decomposing board
    |{position=_;stores=(a,b);gameState=_} -> match n with 
                                              |1|2|3|4|5|6 -> match a with //structuly decomposing (south's) store
                                                              |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> match n with 
                                                                                                                 |1 -> q
                                                                                                                 |2 -> w
                                                                                                                 |3 -> e
                                                                                                                 |4 -> r
                                                                                                                 |5 -> t
                                                                                                                 |6 -> y
                                              |7|8|9|10|11|12 -> match a with //structuly decomposing (norths's) store
                                                                   |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> match n with 
                                                                                                                      |7 -> q
                                                                                                                      |8 -> w
                                                                                                                      |9 -> e
                                                                                                                      |10 -> r
                                                                                                                      |11 -> t
                                                                                                                      |12 -> y
    




let useHouse n board = failwith "Not implemented"

let start pos =
    let pie = 
        match pos with
        | South-> South'sTurn 
        | North-> North'sTurn
   
    let A = {Store.capacity=0;player=South;smallHouse=(4,4,4,4,4,4)}
    let B = {Store.capacity=0;player=North;smallHouse=(4,4,4,4,4,4)}

    {Board.position=pos;stores=(A,B);gameState=pie}

let score board = 
    let storeA,storeB = board.stores    //tapiwas part 
    storeA.capacity,storeB.capacity
    

let gameState board = 
    match board.gameState with
    |South'sTurn -> "South's turn"
    |North'sTurn -> "North's turn"
    |Draw -> "Draw"
    |SouthWin -> "South won"
    |NorthWin -> "North won"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
