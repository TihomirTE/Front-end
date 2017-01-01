function solve(args) {
    let number = +args[0],
        digit,
        result = '',
        hundreds = '';
    if (number <= 9) {
        smallDigits(number);
    }


    if (number > 9 && number < 20) {
        tenToTwenty(number);
    }

    if (number >= 20 && number < 100) {
        digit = number % 10;
        if (digit !== 0) {
            smallDigits(digit);
        }
        hundreds = result;
        number = (number / 10) | 0;
        tens(number);
        result += hundreds;
        hundreds = '';
    }

    if (number >= 100 && number < 1000) {
        digit = (number / 100) | 0;
        smallDigits(digit);
        digit = number % 100;
        if (digit !== 0) {
            hundreds = result + ' hundred and ';
        } else {
            hundreds = result + ' hundred';
            result = '';
        }
        if (digit > 19) {
            digit = ((number % 100) / 10) | 0;
            tens(digit);
            hundreds += result;
            digit = number % 10;
            if (digit !== 0) {
                smallDigits(digit);
            }
        } else if (digit > 9 && digit < 20) {
            tenToTwenty(digit);
        } else if (digit !== 0 && number > 0) {
            smallDigits(digit);
        }
    }
    result = hundreds + result;
    result = result.charAt(0).toUpperCase() + result.slice(1);
    console.log(result);
    // string.charAt(0).toUpperCase() + string.slice(1);

    function smallDigits(smallDigit) {
        let digit = smallDigit;
        switch (smallDigit) {
            case 0:
                result = 'zero';
                break;
            case 1:
                result = 'one';
                break;
            case 2:
                result = 'two';
                break;
            case 3:
                result = 'three';
                break;
            case 4:
                result = 'four';
                break;
            case 5:
                result = 'five';
                break;
            case 6:
                result = 'six';
                break;
            case 7:
                result = 'seven';
                break;
            case 8:
                result = 'eight';
                break;
            case 9:
                result = 'nine';
                break;
        }
    }

    function tenToTwenty(number) {
        switch (number) {
            case 10:
                result = 'ten';
                break;
            case 11:
                result = 'eleven';
                break;
            case 12:
                result = 'twelve';
                break;
            case 13:
                result = 'thirteen';
                break;
            case 14:
                result = 'fourteen';
                break;
            case 15:
                result = 'fifteen';
                break;
            case 16:
                result = 'sixteen';
                break;
            case 17:
                result = 'seventeen';
                break;
            case 18:
                result = 'eighteen';
                break;
            case 19:
                result = 'nineteen';
                break;
        }
    }

    function tens(number) {
        switch (number) {
            case 2:
                result = 'twenty ';
                break;
            case 3:
                result = 'thirty ';
                break;
            case 4:
                result = 'fourty ';
                break;
            case 5:
                result = 'fifty ';
                break;
            case 6:
                result = 'sixty ';
                break;
            case 7:
                result = 'seventy ';
                break;
            case 8:
                result = 'eighty ';
                break;
            case 9:
                result = 'ninety ';
                break;
        }
    }
}


//solve(['50']);