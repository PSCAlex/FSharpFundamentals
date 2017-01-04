
module Option = 

    let apply fOpt xOpt =
        match fOpt, xOpt with 
        | Some f, Some x -> Some (f x)
        | _ -> None

module List = 

    let apply (fList: ('a->'b) list) (xList: 'a list) = 
        [ for f in fList do
          for x in xList do
                yield f x ]



let add x y = x + y

let resultOption = 
    let (<*>) = Option.apply

    (Some add) <*> (Some 2) <*> (Some 3)

let reaultList =
    let (<*>) = List.apply

    [add] <*> [1;2] <*> [10;20]


let resultOption2 =  
    let (<!>) = Option.map
    let (<*>) = Option.apply

    add <!> (Some 2) <*> (Some 3)

let resultList2 =  
    let (<!>) = List.map
    let (<*>) = List.apply

    add <!> [1;2] <*> [10;20]

