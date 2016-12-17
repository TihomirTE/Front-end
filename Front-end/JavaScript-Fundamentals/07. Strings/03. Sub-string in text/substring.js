    function solve(args) {
        let countArr, reg,
            word = args[0],
            text = args[1];

        reg = new RegExp(word, "gi");
        countArr = text.match(reg);
        console.log(countArr.length);
    }

    /*solve([
        'in',
        'We are living in an submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
    ]);*/

    /*var temp = "This is a string.";
    var count = (temp.match(/is/g) || []).length; // /'string'/ - global regex
    console.log(count);*/