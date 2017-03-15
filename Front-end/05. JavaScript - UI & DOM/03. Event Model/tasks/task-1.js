function solve() {
    return function(selector) {

        // Validations
        if (selector === null || selector === undefined) {
            throw new Error('null/undefined selector');
        } else if (typeof selector !== 'string' && selector instanceof HTMLElement) {
            throw new Error('invalid selector');
        } else if (document.getElementById(selector) === null) {
            throw new Error('selector selects nothing');
        }


        let buttons = document.getElementsByClassName('button'),
            contents = document.getElementsByClassName('content');

        for (let i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
            buttons[i].addEventListener('click', function(ev) {
                let clickedButton = ev.target,
                    nextContentSibling = clickedButton.nextElementSibling;
                
                let firstContent,
                    validFirstContent = false;

                while (nextContentSibling) {
                    if (nextContentSibling.className === 'content') {
                        firstContent = nextContentSibling;
                        nextContentSibling = nextContentSibling.nextSibling;
                        while (nextContentSibling) {
                            if (nextContentSibling.className === 'button') {
                                validFirstContent = true;
                                break;
                            }
                            nextContentSibling = nextContentSibling.nextElementSibling;
                        }
                        break;
                    } else {
                        nextContentSibling = nextContentSibling.nextElementSibling;
                    }
                }

                if (validFirstContent) {
                    if (firstContent.style.display === 'none') {
                        firstContent.style.display = '';
                        clickedButton.innerHTML = 'hide';
                    } else {
                        firstContent.style.display = 'none';
                        clickedButton.innerHTML = 'show';
                    }
                }
            });
        }



        // let topMostContent = document.querySelector('.button .content'),
        //     buttonBefore = topMostContent.previousElementSibling;
        // if (topMostContent.innerHTML === 'visible') {
        //     topMostContent = 'hide';
        //     buttonBefore = 'show';
        // } else {
        //     topMostContent = 'show';
        //     buttonBefore = 'hide';
        // }


    };
}

module.exports = solve;