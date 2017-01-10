#r @"C:\Users\alexl\Research\F#\FSharpFundamentals\FSharp Fundamentals\packages\FParsec.1.0.2\lib\net40-client\FParsecCS.dll"
#r @"C:\Users\alexl\Research\F#\FSharpFundamentals\FSharp Fundamentals\packages\FParsec.1.0.2\lib\net40-client\FParsec.dll"

open FParsec

run anyChar "abcdefg"
    |> sprintf "%+A"

let parsesA = pchar 'a'
run parsesA "abcdefg"
    |> sprintf "%+A"

let plistoffloats = (sepBy pfloat (pchar ',' .>> spaces))
run plistoffloats "1.1,3.7"

type Point = {x: float; y: float}

let plistoffloats' = 
    pipe3 pfloat (pchar ',' .>> spaces) pfloat
    (fun x y z -> {x = x; y = y})

run plistoffloats' "1.1,3.7"

let ppoint' = 
    between 
        (pchar '(')
        (pchar ')')
        plistoffloats'
run ppoint' "(1.1, 3.7)"

