function workingWithKVP(input) {
    let dict = {};

    for (i = 0; i < input.length - 1; i++){
        let currentKVP = input[i].split(" ").filter(function(e){return e});

        let key = currentKVP[0];
        let value = currentKVP[1];

        dict[key] = value;
    }

    let valueSearched = input[input.length - 1];

    if (valueSearched in dict){
        console.log(dict[valueSearched]);
    }
    else{
        console.log("None");
    }
}