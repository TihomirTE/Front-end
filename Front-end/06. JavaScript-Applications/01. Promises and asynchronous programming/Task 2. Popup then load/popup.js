(function() {
    let popup = document.getElementById("popup"),
        btn = document.getElementById("btn");

    function redirect() {
        window.location = "https://giphy.com/gifs/9CFB8fnPPgzok";
    }

    let promise = new Promise(function(resolve, reject) {
        setTimeout(function() {
            resolve();
        }, 2000);
    });

    function clickButton() {
        promise
            .then(redirect)
            .catch(error);
    }

    window.onload = btn.addEventListener("click", clickButton, false);
})();