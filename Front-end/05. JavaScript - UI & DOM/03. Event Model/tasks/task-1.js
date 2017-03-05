function solve() {
    return function(selector) {

        // Validations
        if (selector === null || selector === undefined) {
            throw new Error('null/undefined selector');
        } else if (typeof selector !== 'string' && selector instanceof HTMLElement) {
            throw new Error('invalid selector');
        } else if (document.getElementById(selector) === null) {
            throw new Error('selector selects nothing');
        }


        let buttons = document.getElementsByClassName('button'),
            contents = document.getElementsByClassName('content');

        for (let i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
            buttons[i].addEventListener('click', function(ev) {
                // TODO:
            }, false);

        }



    };
}

module.exports = solve;