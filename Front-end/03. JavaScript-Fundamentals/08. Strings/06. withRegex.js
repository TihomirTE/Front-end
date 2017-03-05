function solve(args) {
    let result = '',
        len = args.length,
        regex = /<.*?>/gm;
    for (let i = 0; i < len; i++) {
        let line = args[i];
        if (regex.test(line)) {
            line = line.replace(regex, '').trim();

        } else {
            line = line.trim();
        }

        result += line;
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