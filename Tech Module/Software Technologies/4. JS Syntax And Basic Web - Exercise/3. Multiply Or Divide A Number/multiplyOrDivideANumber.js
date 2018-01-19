function multiplyOrDivideANumber(input) {
    let firstNumber = +input[0];
    let secondNumber = +input[1];

    if (secondNumber >= firstNumber){
        let result = firstNumber * secondNumber;
        console.log(result);
    }
    else{
        let result = firstNumber / secondNumber;
        console.log(result);
    }
}