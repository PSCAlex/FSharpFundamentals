
type Person = {
    name : string;
    age : int
}

{name = "bob"; age = 55}

{name = "bob"; age = 55}.age

type Person2 = {
    name : string;
    age : int
} with member this.canDrive = this.age > 17

{name = "bob"; age = 55}.canDrive 

let bob = {name = "bob"; age = 55}

{bob with age = 56}





