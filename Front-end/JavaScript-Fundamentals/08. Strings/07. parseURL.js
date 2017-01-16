function solve(args) {
    let text = args[0],
        len = text.length,
        indexProtocol,
        indexServer;

    indexProtocol = text.indexOf('://');
    console.log('protocol: ' + text.slice(0, indexProtocol));

    indexServer = text.indexOf('/', indexProtocol + 4);
    console.log('server: ' + text.slice(indexProtocol + 3, indexServer));

    console.log('resource: ' + text.slice(indexServer));

}

//solve(['http://telerikacademy.com/Courses/Courses/Details/239']);