function largestThreeNumbers(input) {
    let arrayOfNumbers = input.map(Number);

    arrayOfNumbers.sort((b, a) => b - a).reverse();

    let largestThree = arrayOfNumbers.slice(0, 3);

    for (let num of largestThree){
        console.log(num)
    }
}