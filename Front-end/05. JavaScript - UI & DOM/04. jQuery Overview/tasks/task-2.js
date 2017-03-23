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
            $(buttons[i]).on('click', function() {
                var clickedButton = $(this),
                    nextSibling = clickedButton.next(),
                    firstContent,
                    validFirstContent = false;

                while (nextSibling) {
                    if (nextSibling.hasClass('content')) {
                        firstContent = nextSibling;
                        nextSibling = nextSibling.next();
                        while (nextSibling) {
                            if (nextSibling.hasClass('button')) {
                                validFirstContent = true;
                                break;
                            }
                            nextSibling = nextSibling.next();
                        }
                        break;
                    } else {
                        nextSibling = nextSibling.next();
                    }
                }

                if (validFirstContent) {
                    if (firstContent.css('display') === 'none') {
                        clickedButton.text('hide');
                        firstContent.css('display', '');
                    } else {
                        clickedButton.text('show');
                        firstContent.hide();
                    }
                }
            });
        }
    };
}

module.exports = solve;