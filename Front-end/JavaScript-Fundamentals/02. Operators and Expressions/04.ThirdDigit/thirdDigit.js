result(['5']);
result(['701']);
result(['9703']);
result(['877']);
result(['777877']);
result(['9999799']);

function result(args) {
    let digit = +args['0'];
    let result = ((digit / 100) % 10) | 0;
    if (result === 7) {
        console.log(true);
    } else {
        console.log(false + ' ' + result);
    }
}