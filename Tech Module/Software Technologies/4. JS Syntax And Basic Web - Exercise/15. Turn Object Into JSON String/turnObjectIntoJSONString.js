function turnObjectIntoJSONString(input) {
    let obj = {};

    for (i = 0; i < input.length; i++){
        let currentKVP = input[i].split(" -> ").filter(function(e){return e});

        let key = currentKVP[0];
        let value = currentKVP[1];

        if (key === "age" || key === "grade"){
            obj[key] = +value;
        }
        else{
            obj[key] = value;
        }
    }

    let result = JSON.stringify(obj);

    console.log(result)
}