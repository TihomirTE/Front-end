/*prime(['2']);
prime(['23']);
prime(['-3']);
prime(['0']);
prime(['1']);*/


function prime(args) {
    var num = +args[0],
        prime = true;

    for (var i = 2; i < Math.sqrt(num); i += 1) {
        if (num % i === 0) {
            prime = false;
            break;
        }
    }
    if (num === 2) {
        prime = true;
    }
    if (num < 2) {
        prime = false;
    }

    console.log(prime);

}