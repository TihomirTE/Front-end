function solve(args) {
    let text = args[0],
        pattern = '<a href="',
        indexUrl = 0,
        result = '',
        indexTextStart,
        indexTextEnd;


    while (indexUrl !== -1) {
        indexTextStart = text.indexOf('">');
        indexTextEnd = text.indexOf('</a>');
        indexUrl = text.indexOf(pattern);
        result += text.substring(0, indexUrl);
        if (indexUrl !== -1) {
            result += '[' + text.substring((indexTextStart + 2), indexTextEnd) + ']';
            result += '(' + text.substring(indexUrl + pattern.length - 1, indexTextStart) + ')';
            text = text.substring(indexTextEnd + 4);
        } else {
            result += text;
        }
    }
    console.log(result);
}

//solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);