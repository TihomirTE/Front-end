//result(['15']);
//result(['1024']);

function result(args) {
    var num = +args['0'],
        pos = 3,
        bit = num & (1 << pos);
    bit = bit >> pos;
    console.log(bit);
}