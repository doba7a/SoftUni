function multipleValuesForAKey(input) {
    let dict = {};

    for (i = 0; i < input.length - 1; i++){
        let currentKVP = input[i].split(" ").filter(function(e){return e});

        let key = currentKVP[0];
        let value = currentKVP[1];

        if (!(key in dict)){
            dict[key] = new Array();
        }

        dict[key].push(value);
    }

    let keySearched = input[input.length - 1];

    if (keySearched in dict){
        for (let value of dict[keySearched]){
            console.log(value);
        }
    }
    else{
        console.log("None");
    }
}
