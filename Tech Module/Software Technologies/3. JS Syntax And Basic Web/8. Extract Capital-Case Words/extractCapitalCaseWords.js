function extractCapitalCaseWords(input) {
    let text = input.join(",");

    let words = text.split(/\W+/).filter(function(e){return e});

    let result = new Array();

    for (let word of words){
        let wordInUpperCase = word.toUpperCase();

        if (word === wordInUpperCase){
            result.push(word);
        }
    }

    console.log(result.join(", "));
}