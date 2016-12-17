function solve(args) {
    var str = args[0];
    console.log(reverse(str));

    function reverse(str) {
        return str.split('').reverse().join('');
    }
}

//solve(['sample']);