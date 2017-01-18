function solve(args) {
    let size = args[0].split(" ").map(Number),
        rows = size[0],
        cols = size[1];
    let debris = args[1].split(";");
    let numberOfDebris = debris.length;
    let numberOfCommands = +args[2];

    let battleField = FillTheField(rows, cols);

    for (let i = 0; i < numberOfCommands; i += 1) {
        let command = args[i + 3].split(" ");
        console.log(command);
        let typeOfCommand = command[0];
        let tank = command[1];
        if (typeOfCommand === "mv") {

        }
        else if (typeOfCommand === "x"){
            
        }
    }


    function FillTheField(rows, cols) {
        // make field with rows and cols
        let field = [rows];
        for (let i = 0; i < rows; i++) {
            field[i] = [];
        }

        let str = '';
        let position = 0;
        let currentDebris = 0,
            positionRow,
            positionCol,
            flagVisited = false,
            flagFree = true;
        let tanksOnKocete = [0, 1, 2, 3],
            tanksOnCuki = [7, 6, 5, 4];

        // fill the fields with debris and tanks
        for (var i = 0; i < rows; i += 1) {
            for (let j = 0; j < cols; j += 1) {
                if (i === 0 && j < tanksOnKocete.length) {
                    // tanks on Koceto
                    field[i][j] = tanksOnKocete[j];
                }
                if (i === rows - 1 && j >= cols - tanksOnCuki.length) {
                    // tanks on Cuki
                    field[i][j] = tanksOnCuki[j - 1];
                }
                // take the coordinates of the current debri
                if (position < numberOfDebris && !flagVisited) {
                    currentDebris = debris[position].split(" ").map(Number);
                    positionRow = currentDebris[0];
                    positionCol = currentDebris[1];
                    flagVisited = true;
                }
                // fill the field with current debri
                if (positionRow === i && positionCol === j) {
                    // current debri
                    flagFree = false;
                    field[i][j] = flagFree;
                    position += 1;
                    flagVisited = false;
                }
                if (field[i][j] === undefined) {
                    // free - no tanks or debris
                    flagFree = true;
                    field[i][j] = flagFree;
                }
            }
        }
        return field;
    }



}

solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);