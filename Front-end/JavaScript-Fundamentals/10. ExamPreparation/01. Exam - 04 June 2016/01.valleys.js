function solve(args) {
    "use strict";
    let heights = args[0].split(' ')
        .map(Number),
        result = 0,
        len = heights.length,
        sum = 0,
        index = 0;

    for (let i = 0; i < len; i += 1) {
        if (heights[i] > heights[i + 1]) {
            index = i;
            sum += heights[index];
            index += 1;
            while (heights[index] < heights[index - 1] ||
                heights[index] < heights[index + 1]) {

                sum += heights[index];
                index += 1;
            }
            sum += heights[index];
            if (sum > result) {
                result = sum;
            }
            sum = 0;
        }
    }

    console.log(result);
}

//solve(["5 1 7 4 8"]);
//solve(["5 1 7 6 5 6 4 2 3 8"]);