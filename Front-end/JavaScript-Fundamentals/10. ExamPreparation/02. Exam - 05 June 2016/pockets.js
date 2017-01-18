function solve(args) {
    let heights = args[0].split(' ').map(Number),
        len = heights.length,
        sum = 0;

    for (let i = 2; i < len - 2; i += 1) {
        if (heights[i - 1] > heights[i - 2] && heights[i + 1] > heights[i + 2]) {
            if (heights[i - 1] > heights[i] && heights[i + 1] > heights[i]) {
                sum += heights[i];
            }
        }
    }

    console.log(sum);
}

//solve(["53 20 1 30 2 40 3 3 10 1"]);