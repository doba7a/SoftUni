function productOfThreeNumbers(input) {
    let firstNumber = +input[0];
    let secondNumber = +input[1];
    let thirdNumber = +input[2];

    let result = firstNumber * secondNumber * thirdNumber;

    if (result >= 0){
        console.log("Positive");
    }
    else{
        console.log("Negative");
    }
}