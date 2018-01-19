function parseJSONObjects(input) {
    for (i = 0; i < input.length; i++){
        let obj = JSON.parse(input[i]);

        console.log(`Name: ${obj.name}`)
        console.log(`Age: ${obj.age}`)
        console.log(`Date: ${obj.date}`)
    }
}