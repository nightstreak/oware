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
    

let useHouse n board = 
    let num = getSeeds n board
    let OrinH = n //original house number 
    let rec add n num board =               //acsepts a house number and number of seeds and a board
                match board with 
                |{position=_;stores=(S,N);gameState=_} -> match S,N with
                                                          |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)},{capacity=_;player=_;smallHouse=(a,s,d,f,g,h)} -> match num>0 with 
                                                                                                                                                            |false -> board,n
                                                                                                                                                            |true -> match n with 
                                                                                                                                                                     |OrinH -> add (n+1) num b //skip the house started at
                                                                                                                                                                     |1 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q,w+1,e,r,t,y)},N)}
                                                                                                                                                                     |2 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q,w,e+1,r,t,y)},N)}
                                                                                                                                                                     |3 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q,w,e,r+1,t,y)},N)}
                                                                                                                                                                     |4 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q,w,e,r,t+1,y)},N)}
                                                                                                                                                                     |5 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q,w,e,r,t,y+1)},N)}
                                                                                                                                                                     |6 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a+1,s,d,f,g,h)})}
                                                                                                                                                                     |7 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a,s+1,d,f,g,h)})}
                                                                                                                                                                     |8 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a,s,d+1,f,g,h)})}
                                                                                                                                                                     |9 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a,s,d,f+1,g,h)})}
                                                                                                                                                                     |10 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a,s,d,f,g+1,h)})}
                                                                                                                                                                     |11 -> add (n+1) (num-1) {board with stores=(S,{N with smallHouse = (a,s,d,f,g,h+1)})}
                                                                                                                                                                     |12 -> add (n+1) (num-1) {board with stores=({S with smallHouse = (q+1,w,e,r,t,y)},N)}
    let bd,h = add n num board 
    let eat h = 
            match getSeeds h bd with
            |2|3 -> match bd with 
                    |{position=_;stores=(S,N);gameState=gs} ->  match S,N with
                                                                |{capacity=_;player=_;smallHouse=(q,w,e,r,t,y)},{capacity=_;player=_;smallHouse=(a,s,d,f,g,h)} -> match gs = S.player with
                                                                                                                                                                  | true -> S.capacity + h
                                                                                                                                                                  |_ -> N.capacity + h
            |_ -> 0
    eat h
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
