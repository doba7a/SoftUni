function addOrRemoveElements(input) {
    let array = new Array();

    for (i = 0; i < input.length; i++){
        let currentCommand = input[i].split(" ").filter(function(e){return e});

        let action = currentCommand[0];

        if (action === "add"){
            let value = +currentCommand[1];
            array.push(value)
        }
        else if (action === "remove"){
            let index = +currentCommand[1];

            if (index >= 0 && index < array.length){
                array.splice(index, 1);
            }
        }
    }

    for (let value of array){
        console.log(value)
    }
}