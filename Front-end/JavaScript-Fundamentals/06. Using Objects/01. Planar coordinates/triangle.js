/* requarements
    a < b + c
    b < a + c
    c < a + b*/

function triangleLines(args) {
    let startPos = 0,
        endPos = 3,
        arr,
        arrPoints = [],
        arrLines = [];

    arr = [].slice.apply(args);
    while (endPos < arr.length) {
        if (startPos === (endPos + 1)) {
            startPos = endPos + 1;
            endPos += 4;
        }
        arrPoints[startPos % 4] = arr[startPos];
        startPos += 1;
        if (!(startPos % 4) && startPos !== 0) {
            let line = calculateLine(arrPoints);
            arrLines.push(line);
        }
        if ((arrLines.length === 3) && (endPos < arr.length)) {
            checkTriangle(arrLines);
        }
    }


    function calculateLine(points) {
        let lineX, lineY, currentLine;
        lineX = Math.abs(+points[0] - +points[2]);
        lineY = Math.abs(+points[1] - +points[3]);

        currentLine = Math.sqrt((lineX * lineX) + (lineY * lineY));
        return currentLine;
    }

    function checkTriangle(lines) {
        let a, b, c, triangle;
        a = +lines[0];
        b = +lines[1];
        c = +lines[2];
        if ((a < (b + c)) && (b < (a + c)) && (c < (a + b))) {
            triangle = 'Triangle can be formed';
        } else {
            triangle = "Triangle can't be formed";
        }
        console.log(a.toFixed(2));
        console.log(b.toFixed(2));
        console.log(c.toFixed(2));
        console.log(triangle);
        return;
    }
}

triangleLines(['5', '6', '7', '8', '1', '2', '3', '4', '9', '10', '11', '12']);
triangleLines([
    '7', '7', '2', '2',
    '5', '6', '2', '2',
    '95', '-14.5', '0', '-0.123'
]);