function solve(args) {

    var firstArray = args[0];
    secondArray = args[1];
    firstLen = firstArray.length;
    secondLen = secondArray.length;

    if (firstLen == secondLen) {
        for (var i = 0; i < firstLen; i++) {
            if (firstArray[i] > secondArray[i]) {
                return '>';
            }
            if (firstArray[i] < secondArray[i]) {
                return '<';
            }
        }
        return '=';
    } else {

        var min = 0;
        if (firstLen > secondLen) {
            min = secondLen;
        } else {
            min = firstLen;
        }

        for (var j = 0; j < min; j++) {
            if (firstArray[j] > secondArray[j]) {
                return '>';
            }
            if (firstArray[j] < secondArray[j]) {
                return '<';
            }
        }
        if (firstLen > secondLen) {
            return '>';
        }
        if (firstLen < secondLen) {
            return '<';
        }
    }
}