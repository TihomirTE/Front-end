/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve(args) {
    return function(x, y) {
        if (x === null || y === null) {
            throw 'Error';
        }
        if (typeof(x) === "boolean" || typeof(y) === "boolean") {
            throw 'Error';
        }
        if (typeof(x) === "undefined" || typeof(y) === "undefined") {
            throw 'Error';
        }
        if (typeof(x) === "string" || typeof(y) === "string") {
            if (isNaN(+x) || isNaN(+y)) {
                throw 'Error';
            } else {
                x = +x;
                y = +y;
            }
        }

        let arr = [];
        for (let i = x; i <= y; i += 1) {
            let flag = true;

            for (let j = 2; j < i; j += 1) {
                if (i % j === 0) {
                    flag = false;
                    break;
                }
            }
            if (flag && i >= 2) {
                arr.push(i);
            }
        }
        return arr;
    };
}

module.exports = solve;