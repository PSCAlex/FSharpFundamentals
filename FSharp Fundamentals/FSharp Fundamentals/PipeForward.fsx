sin 7.

7. |> sin

7.
    |> sin
    |> ((*)2.)



[1;2;3;4]
    |> List.filter (fun i -> i % 2 = 0)
    |> List.map ((*)2)
    |> List.sum

let square x = x * x

let double x = x * 2

3 |> double |> square 

let (|<><><>|) a f = f a

3 |<><><>| double |<><><>| square
