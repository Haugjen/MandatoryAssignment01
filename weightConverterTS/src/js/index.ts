
let toOunces : HTMLButtonElement = <HTMLButtonElement> document.getElementById("toOunces")
let toGrams : HTMLButtonElement= <HTMLButtonElement> document.getElementById("toGrams")
let result : HTMLDivElement = <HTMLDivElement> document.getElementById("result")
let weight : HTMLInputElement = <HTMLInputElement> document.getElementById("weight")

let toGramsRatio : number = 28.34952
let toOuncesRatio : number = 1/toGramsRatio

function unitConvert (ratio : number) :string
{
    let inputValue :string = weight.value
    let inputValueNumber : number = Number(inputValue)  
    let result : number = (inputValueNumber*ratio)

    return String(result)
}

function toGramsCalc () 
{
    result.innerHTML= unitConvert(toGramsRatio)
}
toGrams.addEventListener("click", toGramsCalc)


function toOuncesCalc ()
{
    result.innerHTML = unitConvert(toOuncesRatio)
}
toOunces.addEventListener("click", toOuncesCalc)









// interface Person {
//     firstName: string;
//     lastName: string;
// }

// function greeter(person: Person): string {
//     return "Hello, " + person.firstName + " " + person.lastName;
// }
// let user: Person = { firstName: "John", lastName: "Doe" };

// let element: HTMLDivElement = <HTMLDivElement> document.getElementById("content");
// element.innerHTML = greeter(user);