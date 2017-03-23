function solve() {
    return function() {
        $.fn.listview = function(data) {
            var templateHolder = this.attr('data-template'),
                template = $('#' + templateHolder).html(),
                compiledHTML = handlebars.compile(template);

            for (var i = 0, len = data.length; i < len; i += 1) {
                this.append(compiledHTML(data[i]));
            }

            return this;
        };
    };
}

module.exports = solve;