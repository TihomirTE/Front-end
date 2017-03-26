/* globals document, window, console */

function solve() {
    return function(selector, initialSuggestions) {
        "use strict";

        var element = document.querySelector(selector);

        var tbPattern = element.getElementsByClassName("tb-pattern")[0],
            suggestionsList = element.getElementsByClassName("suggestions-list")[0],
            buttonAdd = element.getElementsByClassName("btn-add")[0],
            pattern = '';

        var suggestionItemLi = document.createElement("li"),
            suggestionLink = document.createElement("a");

        suggestionItemLi.className = "suggestion";
        suggestionLink.className = "suggestion-link";
        suggestionLink.href = "#";
        suggestionItemLi.appendChild(suggestionLink);
        suggestionItemLi.style.display = "none";

        var usedSuggestions = {};

        initialSuggestions = initialSuggestions || [];

        for (var i = 0, len = initialSuggestions.length; i < len; i += 1) {
            var suggestionString = initialSuggestions[i];
            if (!usedSuggestions[suggestionString.toLowerCase()]) {
                suggestionLink.innerHTML = suggestionString;
                var newSuggestion = suggestionItemLi.cloneNode(true);
                suggestionsList.appendChild(newSuggestion);
                usedSuggestions[suggestionString.toLowerCase()] = true;
            }
        }

        suggestionsList.addEventListener("click", function(ev) {
            var button = ev.target,
                text;

            if (button.className.indexOf("suggestion-link") < 0) {
                return;
            }

            text = button.innerHTML;
            // set the value property
            tbPattern.value = text;

            ev.preventDefault();
        });

        suggestionsList.style.display = "none";

        buttonAdd.addEventListener("click", function() {
            var value = tbPattern.value;
            tbPattern.value = "";

            suggestionsList.style.display = "none";

            if (!usedSuggestions[value.toLowerCase()]) {
                suggestionLink.innerHTML = value;
                suggestionsList.appendChild(suggestionItemLi.cloneNode(true));
                usedSuggestions[value.toLowerCase()] = true;
            }
        });

        tbPattern.addEventListener("input", function() {
            var suggestionItems = element.getElementsByClassName("suggestion");

            var len = suggestionItems.length,
                suggestionItem,
                suggestionText,
                i;

            pattern = this.value.toLowerCase();

            if (pattern === "") {
                suggestionsList.style.display = "none";
                return;
            }

            suggestionsList.style.display = "";

            for (i = 0; i < len; i += 1) {
                suggestionItem = suggestionItems[i];
                suggestionText = suggestionItem.getElementsByClassName("suggestion-link")[0];
                if (suggestionText.innerHTML.toLowerCase().indexOf(pattern) >= 0) {
                    suggestionItem.style.display = "";
                } else {
                    suggestionItem.style.display = "none";
                }
            }
        });
    };
}

module.exports = solve;