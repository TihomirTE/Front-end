(function() {
    let popup = document.getElementById("popup"),
        btn = document.getElementById("btn");

    function redirect() {
        window.location = "https://giphy.com/gifs/9CFB8fnPPgzok";
    }

    let promise = new Promise(function(resolve, reject) {
        resolve();
    });

    function clickButton() {
        setTimeout(function() {
            promise
                .then(redirect)
                .catch(error);
        }, 2000);
    }

    window.onload = btn.addEventListener("click", clickButton, false);
})();