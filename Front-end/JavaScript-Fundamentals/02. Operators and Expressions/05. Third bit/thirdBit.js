result(['15']);
result(['1024']);

function result(args) {
    let num = +args['0'];
    let pos = 3;
    let bit = num & (1 << pos);
    bit = bit >> pos;
    console.log(bit);
}