function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        numberOfTests = parseInt(params[rows + 2]),
        move;

    let table = MakeChessTable(rows, cols);

    for (let i = 0; i < numberOfTests; i++) {
        move = params[rows + 3 + i];

        let startCol = (move[0].charCodeAt(0) - 97); // take the starting col
        let startRow = rows - +(move[1]); // take the starting row
        let endCol = (move[3].charCodeAt(0) - 97); // take the ending col
        let endRow = rows - +(move[4]); // take the ending row

        let deltaRow = startRow - endRow;
        let deltaCol = startCol - endCol;

        if (table[startRow][startCol] === "-") { // starting position is empty
            console.log("no");
            continue;
        }

        if (deltaRow === 0 && deltaCol === 0) { // starting === ending
            console.log("no");
            continue;
        }

        if (table[startRow][startCol] === "R") { // check for Rook
            if (deltaRow === 0) {
                CheckRookRow(startCol, deltaCol, table, startRow, endCol);
            } else if (deltaCol === 0) {
                CheckRookCol(startRow, deltaRow, table, startCol, endRow);
            } else { // invalid move
                console.log("no");
                continue;
            }
        }

        if (table[startRow][startCol] === "B") { // check for Bishop
            if (deltaRow === 0 || deltaCol === 0) { // invalid move 
                console.log("no");
                continue;
            } else {
                CheckBishop(deltaRow, startRow, endRow, deltaCol, startCol, table);
            }
        }

        if (table[startRow][startCol] === "Q") { // check for Queen
            if (deltaRow === 0) {
                CheckRookRow(startCol, deltaCol, table, startRow, endCol);
            } else if (deltaCol === 0) {
                CheckRookCol(startRow, deltaRow, table, startCol, endRow);
            } else {
                CheckBishop(deltaRow, startRow, endRow, deltaCol, startCol, table);
            }
        }
    }


    function CheckBishop(deltaRow, startRow, endRow, deltaCol, startCol, table) {
        let currentRow = (deltaRow > 0) ? (startRow - 1) : (startRow + 1);
        let currentCol = (deltaCol > 0) ? (startCol - 1) : (startCol + 1);
        if (table[currentRow][currentCol] === "B" || table[currentRow][currentCol] === "Q" || table[currentRow][currentCol] === "R") {
            return console.log("no");
        }
        while (currentRow !== endRow) {

            if (table[currentRow][currentCol] === "B" || table[currentRow][currentCol] === "Q" || table[currentRow][currentCol] === "R") {
                return console.log("no");
            }
            currentRow = (deltaRow > 0) ? currentRow -= 1 : currentRow += 1;
            currentCol = (deltaCol > 0) ? currentCol -= 1 : currentCol += 1;
        }
        if (table[currentRow][currentCol] === "B" || table[currentRow][currentCol] === "Q" || table[currentRow][currentCol] === "R") {
            return console.log("no");
        }
        return console.log("yes");
    }

    function CheckRookRow(start, delta, table, startConst, end) { // row is Const
        let current = (delta > 0) ? (start - 1) : (start + 1);
        if (table[startConst][current] === "B" || table[startConst][current] === "Q" || table[startConst][current] === "R") {
            return console.log("no");
        }
        while (current !== end) {

            if (table[startConst][current] === "B" || table[startConst][current] === "Q" || table[startConst][current] === "R") {
                return console.log("no");
            }
            current = (delta > 0) ? current -= 1 : current += 1;
        }
        if (table[startConst][current] === "B" || table[startConst][current] === "Q" || table[startConst][current] === "R") {
            return console.log("no");
        }
        return console.log("yes");
    }

    function CheckRookCol(start, delta, table, startConst, end) { // col is Const
        let current = (delta > 0) ? (start - 1) : (start + 1);
        if (table[current][startConst] === "B" || table[current][startConst] === "Q" || table[current][startConst] === "R") {
            return console.log("no");
        }
        while (current !== end) {

            if (table[current][startConst] === "B" || table[current][startConst] === "Q" || table[current][startConst] === "R") {
                return console.log("no");
            }
            current = (delta > 0) ? current -= 1 : current += 1;
        }
        if (table[current][startConst] === "B" || table[current][startConst] === "Q" || table[current][startConst] === "R") {
            return console.log("no");
        }
        return console.log("yes");
    }

    function MakeChessTable(rows, cols) {
        let tableChess = new Array(rows);
        for (let i = 0; i < rows; i++) {
            tableChess[i] = new Array(cols);
            let figures = params[i + 2].split("");
            for (let j = 0; j < cols; j += 1) {
                tableChess[i][j] = figures[j];
            }
        }
        return tableChess;
    }
}

solve([
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d5',
    'b3 a2',
    'b3 d1',
    'b3 a4',
    'c2 c5'
]);