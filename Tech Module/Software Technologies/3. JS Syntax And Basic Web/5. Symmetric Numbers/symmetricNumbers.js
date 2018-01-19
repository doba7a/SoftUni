function symmetricNumbers(input) {
    let givenNumber = input[0].split(' ').map(Number);

    let result = "";

    for (i = 1; i <= givenNumber; i++){
        let reversedNumber = Number(i.toString().split("").reverse().join(""));

        if (i == reversedNumber){
            result += i + " ";
        }
    }

    console.log(result)
}
