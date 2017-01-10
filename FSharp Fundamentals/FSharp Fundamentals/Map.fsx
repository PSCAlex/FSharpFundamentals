
let mapOption f opt =
    match opt with
    | None -> 
        None
    | Some x ->
        Some(f x)

let rec mapList f list = 
    match list with 
    | [] ->
        []
    | head::tail ->
        (f head) :: (mapList f tail)


//function in the normal world
let add1 x = x + 1

//lift into world of options 
let add1IfSomething = Option.map add1

//lift into world of lists 
let add1ToEachElement = List.map add1

Some 2 |> Option.map add1
[1;2;3] |> List.map add1