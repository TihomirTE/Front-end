function solve(args) {
    let pattern = JSON.parse(args[0]);

    String.prototype.format = function(pattern) {
        let prop,
            output = this;
        for (prop in pattern) {
            output = output.replace(new RegExp('#{' + prop + '}', 'g'), pattern[prop]);
        }
        console.log(output);
    };

    output = args[1].format(pattern);
}

/*solve([
    '{ "name": "John", "age": 13 }',
    "My name is #{name} and I am #{age}-years-old"
]);*/