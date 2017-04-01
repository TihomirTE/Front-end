function solve() {
    return function(selector, isCaseSensitive) {

        var element = document.querySelector(selector),
            isCaseSensitiveSearch = isCaseSensitive || false;

        element.className += " items-control";

        // Adding elements
        var addElement = document.createElement("div"),
            label = document.createElement("label"),
            input = document.createElement("input"),
            button = document.createElement("button");

        addElement.className += " add-controls";
        label.innerHTML = "Enter text";
        label.setAttribute("for", "the-input");
        input.id = "the-input";
        button.className += " button";
        button.innerHTML = "Add";

        addElement.appendChild(label);
        addElement.appendChild(input);
        addElement.appendChild(button);

        element.appendChild(addElement);

        // Search elements
        var searchElement = document.createElement("div"),
            labelSearch = document.createElement("label"),
            inputSearch = document.createElement("input");

        searchElement.className += " search-controls";
        labelSearch.innerHTML = "Search";
        labelSearch.setAttribute("for", "the-search");
        inputSearch.id = "the-search";

        searchElement.appendChild(labelSearch);
        searchElement.appendChild(inputSearch);

        element.appendChild(searchElement);

        // Result elements
        var resultElement = document.createElement("div"),
            itemsList = document.createElement("ul");

        resultElement.className += " result-controls";
        itemsList.className += " items-list";

        resultElement.appendChild(itemsList);
        element.appendChild(resultElement);

        // add element
        button.addEventListener("click", function() {
            var listItem = document.createElement("li");
            listItem.className += " list-item";

            var text = document.createElement("span");
            text.innerHTML = input.value;
            listItem.appendChild(text);

            var deleteButton = document.createElement("button");
            deleteButton.className += " button";
            deleteButton.innerHTML = "X";
            listItem.appendChild(deleteButton);

            itemsList.appendChild(listItem);
        });

        // search element
        inputSearch.addEventListener("input", function() {
            var items = document.getElementsByClassName("list-item");

            for (var i = 0, len = items.length; i < len; i += 1) {
                if (isCaseSensitive) {
                    if (items[i].firstElementChild.innerHTML.indexOf(inputSearch.value) >= 0) {
                        items[i].style.display = "";
                    } else {
                        items[i].style.display = "none";
                    }
                } else {
                    if (items[i].firstElementChild.innerHTML.toLowerCase().indexOf(inputSearch.value.toLowerCase()) >= 0) {
                        items[i].style.display = "";
                    } else {
                        items[i].style.display = "none";
                    }
                }
            }
        });

        // remove element
        itemsList.addEventListener("click", function(ev) {
            if (ev.target.className.indexOf("button") >= 0) {
                this.removeChild(ev.target.parentNode);
            }
        });
    };
}

module.exports = solve;