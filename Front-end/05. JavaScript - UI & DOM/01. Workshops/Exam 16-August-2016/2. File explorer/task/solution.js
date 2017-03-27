function solve() {
    return function(fileContentsByName) {

        var $items = $(".file-explorer > .items"),
            $contentsPreview = $(".file-content"),
            $addBtn = $(".file-explorer .add-btn"),
            $addInput = $(".file-explorer input"),
            $fileContentByName = JSON.parse(JSON.stringify(fileContentsByName)),
            $dirsByName = {};

        $('.dir-item .item-name').each(function(index, element) {
            $dirsByName[element.innerHTML] = $(element.parentNode);
        });

        $items.on("click", function(event) {
            var $target = $(event.target),
                $parent = $target.parent(),
                itemName,
                previewContents;

            if ($target.hasClass("del-btn")) {

                itemName = $parent.find(".item-name").html();

                if ($parent.hasClass("dir-item")) {
                    delete $dirsByName[itemName];
                } else {
                    delete $fileContentByName[itemName];
                }

                $parent.remove();
                return;
            }

            if ($parent.hasClass("file-item")) {
                previewContents = $fileContentByName[$target.text()] || "";
                $contentsPreview.text(previewContents);
            }

            if ($parent.hasClass("dir-item")) {
                $parent.toggleClass("collapsed");
            }
        });

        function renderFile(name) {
            var $fileLi = $("<li />")
                .addClass("file-item item"),
                $itemName = $("<a />")
                .text(name)
                .addClass("item-name")
                .appendTo($fileLi),
                $delBtn = $("<a />")
                .addClass("del-btn")
                .appendTo($fileLi);

            return $fileLi;
        }

        $addBtn.on("click", function() {
            $addInput.addClass("visible");
            $addBtn.removeClass("visible");
        });

        $addInput.on("keydown", function(event) {
            if (event.keyCode !== 13) {
                return;
            }

            var file,
                path = $addInput
                .val()
                .split("/");

            if (!path[0] && !path[1]) {
                return;
            }

            if (path.length === 1) {
                renderFile(path[0].appendTo($items));
            } else {
                file = renderFile(path[1]);

                if (!$dirsByName[path[0]]) {
                    return;
                }

                $dirsByName[path[0]]
                    .children("ul.items")
                    .appendTo(file);
            }

            $addInput.val("");

            $addInput.removeClass("visible");
            $addBtn.addClass("visible");

        });

    };
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}