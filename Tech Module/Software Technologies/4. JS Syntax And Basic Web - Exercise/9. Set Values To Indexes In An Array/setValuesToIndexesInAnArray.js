function setValuesToIndexesInAnArray(input) {
    let array = new Array(+input[0]);

    for (i = 0; i < array.length; i++){
        array[i] = 0;
    }

    for (i = 1; i < input.length; i++){
        let currentCommand = input[i].split(" - ").filter(function(e){return e});

        let index = +currentCommand[0];
        let value = +currentCommand[1];

        array[index] = value;
    }

    for (let value of array){
        console.log(value)
    }
}