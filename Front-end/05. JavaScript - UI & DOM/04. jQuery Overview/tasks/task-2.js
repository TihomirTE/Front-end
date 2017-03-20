function solve() {
    return function(selector) {
        // Validations
        if (typeof(selector) !== 'string' || $(selector).size() === 0) {
            throw 'invalid selector';
        }

        var buttons = $('.button'),
            content = $('.content');

        for (var i = 0, len = buttons.length; i < len; i += 1) {
            $(buttons[i]).text('hide');
        }
    };
}

module.exports = solve;