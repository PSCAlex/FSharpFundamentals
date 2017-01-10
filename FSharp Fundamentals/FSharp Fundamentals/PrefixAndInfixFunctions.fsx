let distance x y = x - y |> abs

//prefix 
distance 5 2

//infix in prefix Format
(+) 1 3 

let add1 = (+) 1

//define infix function
let (|><|) x y = x - y |> abs

5 |><| 2

5 |><| 2 |><| 10

