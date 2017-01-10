"It was the best of times,
it was the worst of times"

"""This "string" includes double quotes"""

@"This ""string"" includes double quotes"

//try without @
@"Verbatim strings\n don't\t encode\n escape sequences"

String.forall System.Char.IsDigit "03242asdf43"

String.init 10 (fun i -> i * 10 |> string)

let fizzbuzzer i = 
    match i with 
        | _ when i % 3 = 0 && i % 5 = 0 -> "fizzbuzz"
        | _ when i % 3 = 0 -> "fizz"
        | _ when i % 5 = 0 -> "buzz"
        | _ -> string i

[1..100] |> List.map fizzbuzzer


 