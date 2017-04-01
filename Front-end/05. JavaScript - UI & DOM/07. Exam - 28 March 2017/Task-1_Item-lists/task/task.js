function solve() {
    return function(selector, defaultLeft, defaultRight) {

        var element = document.querySelector(selector),
            leftInputArray = defaultLeft || [],
            rightInputArray = defaultRight || [],
            imgElement;

        // Column container
        var columnContainer = document.createElement("div");
        columnContainer.className += "column-container";

        var leftColumn = document.createElement("div");
        leftColumn.className += "column";
        leftColumn.appendChild(createDivSelect("left", true));

        var orderedListLeft = document.createElement("ol");
        orderedListLeft.appendChild(createOrderedList(leftInputArray));
        leftColumn.appendChild(orderedListLeft);

        var rightColumn = document.createElement("div");
        rightColumn.className += "column";
        rightColumn.appendChild(createDivSelect("right"));

        var orderedListRight = document.createElement("ol");
        orderedListRight.appendChild(createOrderedList(rightInputArray));
        rightColumn.appendChild(orderedListRight);

        columnContainer.appendChild(leftColumn);
        columnContainer.appendChild(rightColumn);
        element.appendChild(columnContainer);

        // Input field
        var inputField = document.createElement("input"),
            addButton = document.createElement("button");

        addButton.innerHTML = "Add";

        element.appendChild(inputField);
        element.appendChild(addButton);

        // Each column should contain:
        function createDivSelect(idName, isCheck) {
            var selectElement = document.createElement("div");
            selectElement.className += "select";

            var radioInput = document.createElement("input");
            radioInput.setAttribute("type", "radio");
            radioInput.id = "select-" + idName + "-column";
            radioInput.setAttribute("name", "select-column");

            if (isCheck) {
                radioInput.checked = true;
            }

            var labelRadioInput = document.createElement("label");
            labelRadioInput.innerHTML = "Add here";
            labelRadioInput.setAttribute("for", "select-" + idName + "-column");

            selectElement.appendChild(radioInput);
            selectElement.appendChild(labelRadioInput);

            return selectElement;
        }

        function createOrderedList(inputArray) {
            var orderedList = document.createDocumentFragment();

            if (inputArray) {
                for (var i = 0, len = inputArray.length; i < len; i += 1) {
                    var liElement = document.createElement("li");
                    liElement.className += "entry";

                    imgElement = document.createElement("img");
                    imgElement.className += "delete";
                    imgElement.src = "imgs/Remove-icon.png";

                    liElement.innerHTML = inputArray[i];
                    liElement.appendChild(imgElement);
                    orderedList.appendChild(liElement);
                }
            }

            return orderedList;
        }

        // Adding items
        addButton.addEventListener("click", function() {
            var liElement = document.createElement("li"),
                text = inputField.value.trim();

            liElement.className += "entry";

            imgElement = document.createElement("img");
            imgElement.className += "delete";
            imgElement.src = "imgs/Remove-icon.png";

            if (text !== "") {
                liElement.innerHTML = text;
                inputField.value = "";
                liElement.appendChild(imgElement);

                if (document.getElementById("select-left-column").checked) {
                    orderedListLeft.appendChild(liElement);
                } else if (document.getElementById("select-right-column").checked) {
                    orderedListRight.appendChild(liElement);
                }
            }
        });

        // Removing items
        orderedListRight.addEventListener("click", function(ev) {
            if (ev.target.className.indexOf("delete") >= 0) {
                this.removeChild(ev.target.parentNode);
            }

            inputField.value = ev.target.parentElement.textContent;
        });

        orderedListLeft.addEventListener("click", function(ev) {
            if (ev.target.className.indexOf("delete") >= 0) {
                this.removeChild(ev.target.parentNode);
            }

            inputField.value = ev.target.parentElement.textContent;
        });
    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}