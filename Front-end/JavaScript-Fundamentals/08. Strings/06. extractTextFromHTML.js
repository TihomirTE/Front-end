function solve(args) {
    let len = args.length,
        text = '',
        insideTag = false,
        index,
        result = '';

    for (let i = 0; i < len; i += 1) {
        text = args[i].trim();

        for (let j = 0; j < text.length; j += 1) {
            index = text[j].indexOf('<');
            if (index !== -1) {
                insideTag = true;
            }
            index = text[j].indexOf('>');
            if (index !== -1) {
                insideTag = false;
                continue;
            }
            if (!insideTag && j !== text.length) {
                result += text[j];
            }
        }
    }
    console.log(result);
}

/*solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);*/