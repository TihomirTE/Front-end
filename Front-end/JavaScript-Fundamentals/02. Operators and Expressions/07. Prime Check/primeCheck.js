/*prime(['2']);
prime(['23']);
prime(['-3']);
prime(['0']);
prime(['1']);*/
console.log(prime(['100']));


function prime(args) {
    var num = +args[0],
        prime = true;

    if (num === 2) {
        prime = true;
        return prime;
    }
    if (num < 2) {
        prime = false;
        return prime;
    }
    for (var i = 2; i < (Math.sqrt(num) | 1); i += 1) {
        if (num % i === 0) {
            prime = false;
            return prime;
        }
    }
    return prime;
}