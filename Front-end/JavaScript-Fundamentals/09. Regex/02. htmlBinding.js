function solve(args) {
    let options = JSON.parse(args[0]),
        inputStr = args[1].replace(/'/, '"');

    String.prototype.bind = function(parameters) {
        let result = this,
            currentMatch,
            regExAttr = new RegExp('data-bind-(.*?)="(.*?)"', 'gmi');

        while (currentMatch = regExAttr.exec(result)) {
            let arr,
                index = result.indexOf('>');

            if (result[index - 1] === '/') {
                index--;
            }

            if (currentMatch[1] !== 'content') {
                arr = result.split('');
                arr.splice(index, 0, " " + currentMatch[1] + '="' + parameters[currentMatch[2]] + '"');
                result = arr.join('');
            } else {
                arr = result.split('');
                arr.splice(index + 1, 0, parameters[currentMatch[2]]);
                result = arr.join('');
            }
        }

        return result;
    };

    return inputStr.bind(options);
}

/*solve([
'{ "name": "Steven" }',
'<div data-bind-content="name"></div>'
]);
solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
]);*/