function threeIntegersSum(input) {
    let arrayOfNumbers = input[0].split(' ').map(Number);

    let firstNumber = +arrayOfNumbers[0];
    let secondNumber = +arrayOfNumbers[1];
    let thirdNumber = +arrayOfNumbers[2];

    console.log(checkIfSumOfTwoIntegersEqualsThird(firstNumber, secondNumber, thirdNumber) ||
        checkIfSumOfTwoIntegersEqualsThird(firstNumber, thirdNumber, secondNumber) ||
        checkIfSumOfTwoIntegersEqualsThird(secondNumber, thirdNumber, firstNumber) ||
        "No")

    function checkIfSumOfTwoIntegersEqualsThird(firstNumber, secondNumber, sum) {
        if (firstNumber + secondNumber != sum){
            return false;
        }
        else if (secondNumber > firstNumber){
            return `${firstNumber} + ${secondNumber} = ${sum}`;
        }
        return `${secondNumber} + ${firstNumber} = ${sum}`;
    }
}
