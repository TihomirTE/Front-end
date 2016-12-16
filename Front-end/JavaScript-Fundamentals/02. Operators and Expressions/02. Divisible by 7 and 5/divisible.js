result(['3']);
result(['0']);
result(['5']);
result(['7']);
result(['35']);
result(['140']);

function result(args) {
    let num = +args[0];
    if (num % 5 === 0 && num % 7 === 0) {
        console.log('true ' + num);
    } else {
        console.log('false ' + num);
    }
}