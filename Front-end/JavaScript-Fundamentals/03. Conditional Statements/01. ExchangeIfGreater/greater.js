greater(['5', '2']);


function greater(args) {
    let a = parseInt(args['0']);
    let b = parseInt(args['1']);

    if (a > b) {
        console.log(b + ' ' + a);
    } else {
        console.log(a + ' ' + b);
    }
}