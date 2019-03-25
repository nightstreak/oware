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
    match n with 
    |1 -> match board with //structuly decomposing board
          |{position=_;stores=(a,b);gameState=_} -> match a with //structuly decomposing (south's) store
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> q
    |2 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match a with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> w
    |3 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match a with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> e
    |4 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match a with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> r
    |5 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match a with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> t
    |6 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match a with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> y
    |7 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with //structuly decomposing (north's) store
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> q
    |8 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> w
    |9 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> e
    |10 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> r
    |11 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> t
    |12 -> match board with 
          |{position=_;stores=(a,b);gameState=_} -> match b with 
                                                    |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)} -> y // i know there is a better way to do this but im to lazy to do the typing
    |_ -> failwith "invalid house number"

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

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
