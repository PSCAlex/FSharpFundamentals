module Assembler

open System.IO
open Parsing
open SignalGenerator
open WavePacker
open FSharpx.Choice

let tokenToSound token = 
    generateSamples (durationFromToken token) (frequency token) 

let assemble tokens = 
    List.map tokenToSound tokens |> Seq.concat

let assembleToPackedStream (score:string) = 
    match parse score with 
        | Choice1Of2 errorMsg -> Choice1Of2 errorMsg
        | Choice2Of2 tokens -> 
            assemble tokens 
            |> Array.ofSeq
            |> pack 
            |> Choice2Of2

//assembleToPackedStream "8b2 8c3 8d3 8#c3 8d3 8#c3 8d3 8g3 4e3 8- 8d3 8c3 8b2 8c3 8b2 8c3 8b2 8c3 8#f3 4d3 8- 8c3 8b2 8a2 8g2 8#f2 8g2 8#f2 8g2 8d3 8c3 8b2 8c3 8b2 8a2 8g2 8#f2 8g2 8e2 8#f2 4d2 8c3 8d3 8b2 8c3 4a2"


