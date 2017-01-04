module Option = 

    // The bind function for Options
    let bind f xOpt = 
        match xOpt with
        | Some x -> f x
        | _ -> None

module List = 

    // The bind function for lists
    let bindList (f: 'a->'b list) (xList: 'a list)  = 
        [ for x in xList do 
          for y in f x do 
              yield y ]

let parseInt str = 
    match str with
    | "-1" -> Some -1
    | "0" -> Some 0
    | "1" -> Some 1
    | "2" -> Some 2
    // etc
    | _ -> None

type OrderQty = OrderQty of int

let toOrderQty qty = 
    if qty >= 1 then 
        Some (OrderQty qty)
    else
        // only positive numbers allowed
        None

let parseOrderQty str =
    parseInt str
    |> Option.bind toOrderQty


// map defined in terms of bind and return (Some)
let map f = 
    Option.bind (f >> Some) 

// apply defined in terms of bind and return (Some)
let apply fOpt xOpt = 
    fOpt |> Option.bind (fun f -> 
        let map = Option.bind (f >> Some)
        map xOpt)


