﻿#r @"C:\Users\alexl\Research\F#\FSharpFundamentals\FSharp Fundamentals\packages\FParsec.1.0.2\lib\net40-client\FParsecCS.dll"
#r @"C:\Users\alexl\Research\F#\FSharpFundamentals\FSharp Fundamentals\packages\FParsec.1.0.2\lib\net40-client\FParsec.dll"

open FParsec

let test p str =
    match run p str with 
    | Success(result, _, _) -> printfn "Success: %A" result
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg

type MeasureFraction = Half | Quarter | Eighth | Sixteenth | Thirtysecondth
type Length = { fraction: MeasureFraction; extended: bool}
type Note =  A | ASharp | B | C | CSharp | D | DSharp | E | F | FSharp | G | GSharp
type Octave = One | Two | Three 
type Sound = Rest | Tone of note: Note * octave: Octave
type Token = { length: Length; sound: Sound}

let aspiration = "32.#d3"

let pmeasurefraction = 
    (stringReturn "2" Half)
    <|> (stringReturn "4" Quarter)
    <|> (stringReturn "8" Eighth)
    <|> (stringReturn "16" Sixteenth)
    <|> (stringReturn "32" Thirtysecondth)

let pextendedparser = (stringReturn "." true) <|> (stringReturn "" false)

let plength = 
    pipe2
        pmeasurefraction
        pextendedparser
        (fun t e -> {fraction = t; extended = e}) 

let pnotsharpablenote = anyOf "be" |>> (function
                                    | 'b' -> B
                                    | 'e' -> E
                                    | unknown -> sprintf "Unknown note %c" unknown |> failwith)

let psharp = (stringReturn "#" true) <|> (stringReturn "" false)

let psharpnote = pipe2
                    psharp
                    (anyOf "acdfg")
                    (fun isSharp note ->
                        match (isSharp, note ) with
                        | (false, 'a') -> A
                        | (true, 'a') -> ASharp
                        | (false, 'c') -> C
                        | (true, 'c') -> CSharp
                        | (false, 'd') -> D
                        | (true, 'd') -> DSharp
                        | (false, 'f') -> F
                        | (true, 'f') -> FSharp
                        | (false, 'g') -> G
                        | (true, 'g') -> GSharp
                        | (_,unknown) -> sprintf "Unknown note %c" unknown |> failwith)

let pnote = pnotsharpablenote <|> psharpnote


test pnote "#c"

test pmeasurefraction aspiration