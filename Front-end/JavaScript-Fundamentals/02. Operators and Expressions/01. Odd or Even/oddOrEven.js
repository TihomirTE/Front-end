result(['3']);
result(['2']);
result(['-2']);
result(['-1']);
result(['0']);

function result(args) {
    let number = +args[0];
    if (number % 2 === 0) {
        console.log('even ' + number);
    } else {
        console.log('odd ' + number);
    }
}