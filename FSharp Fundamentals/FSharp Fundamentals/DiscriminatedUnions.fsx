

type Note = A | ASharp | B | C | CSharp  | D | DSharp  | E | F | FSharp  | G | GSharp  

type Octave = One | Two | Three

type Sound = Rest | Tone of Note * Octave

Rest 

Tone (C, Two)

match Tone (C, Two) with 
    | Tone (note, octave) -> sprintf "%A %A" note octave 
    | Rest -> "---"
