
let (a,b) = (1,2)

let addPair (f,s) = f + s

addPair(2,4)

let addPair2 p = 
    match p with 
        | (f,0) -> f
        | (0,s) -> s
        | (f,s) -> f + s

addPair2(0,2)


