function solve() {
    return function(selector) {
        var dropDown = $('<div />').addClass('dropdown-list'),
            optionsContainer = $('<div class="options-container" style="position: absolute; display: none;"></div>'),
            numberOfOptions = $(selector).find('option').size(),
            options = $(selector).find('option');

        $(selector).css('display', 'none').appendTo(dropDown);
        $('<div class="current" data-value="">Option1</div>').appendTo(dropDown);

        for (var i = 0; i < numberOfOptions; i += 1) {
            $('<div class="dropdown-item" data-value="' + $(options[i]).val() + '" data-index="' + i + '">Option' + (i + 1) + '</div>').appendTo(optionsContainer);
        }
        optionsContainer.appendTo(dropDown);

        $(document.body).append(dropDown);

        $('.current').on('click', function() {
            optionsContainer.css('display', 'block');
            $(this).html('Select a value');
        });

        optionsContainer.on('click', '.dropdown-item', function() {
            optionsContainer.css('display', 'none');
            $(selector).val($(this).attr('data-value'));
            $('.current').html($(this).html());
        });

        return this;
    };
}

module.exports = solve;