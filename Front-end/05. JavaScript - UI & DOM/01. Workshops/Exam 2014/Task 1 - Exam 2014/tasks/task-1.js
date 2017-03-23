/* globals module */
function solve() {

    return function(selector, items) {
        // TODO: check selector, check items, check items length

        const root = document.querySelector(selector);
        const fragment = document.createDocumentFragment();

        const imagePreviewer = document.createElement('div');
        imagePreviewer.style.display = 'inline-block';
        imagePreviewer.style.width = '75%';
        imagePreviewer.style.float = 'left';
        imagePreviewer.style.textAlign = 'center';

        const aside = document.createElement('div');
        aside.style.display = 'inline-block';
        aside.style.width = '25%';
        aside.style.textAlign = 'center';

        const selectedParent = document.createElement('div');
        selectedParent.classList.add('image-preview');
        const selectedImageHeader = document.createElement('h2');
        selectedImageHeader.innerText = items[0].title;
        const selectedImage = document.createElement('img');
        selectedImage.src = items[0].url;
        selectedImage.style.width = '70%';

        selectedParent.appendChild(selectedImageHeader);
        selectedParent.appendChild(selectedImage);

        const inputHeader = document.createElement('label');
        inputHeader.innerText = 'Filter';
        inputHeader.style.display = 'block';
        let id = 'input-id-' + Math.random();
        inputHeader.setAttribute('for', id);
        const input = document.createElement('input');
        input.id = id;

        input.addEventListener('input', function(ev) {
            let text = ev.target.value;
            let liChildren = listOfItems.getElementsByTagName('li');
            for (let i = 0, len = liChildren.length; i < len; i += 1) {
                let currentLi = liChildren[i];
                let header = currentLi.firstElementChild.innerText;

                if (header.toLowerCase().indexOf(text.toLowerCase()) >= 0) {
                    currentLi.style.display = 'block';
                } else {
                    currentLi.style.display = 'none';
                }
            }
        }, false);

        const listOfItems = document.createElement('ul');
        listOfItems.style.listStyleType = 'none';
        listOfItems.style.height = '500px';
        listOfItems.style.overflowY = 'scroll';

        listOfItems.addEventListener('click', function(ev) {
            const target = ev.target;
            if (target.tagName === 'IMG') {
                let header = target.previousElementSibling.innerText;
                let src = target.src;
                selectedImageHeader.innerText = header;
                selectedImage.src = src;
            }
        }, false);

        listOfItems.addEventListener('mouseover', function(ev) {
            let target = ev.target;
            if (target.tagName === 'IMG') {
                target.parentElement.style.backgroundColor = 'green';
                target.parentElement.style.cursor = 'pointer';
            }
        }, false);

        listOfItems.addEventListener('mouseout', function(ev) {
            let target = ev.target;
            if (target.tagName === 'IMG') {
                target.parentElement.style.backgroundColor = '';
            }
        }, false);

        const li = document.createElement('li');
        li.classList.add('image-container');

        const imageHeader = document.createElement('h3');
        const image = document.createElement('img');
        image.style.width = '90%';

        for (let i = 0, len = items.length; i < len; i += 1) {
            let currentItem = items[i];
            let currentLi = li.cloneNode(true);
            let currentImageHeader = imageHeader.cloneNode(true);
            currentImageHeader.innerText = currentItem.title;
            let currentImage = image.cloneNode(true);
            currentImage.src = currentItem.url;

            currentLi.appendChild(currentImageHeader);
            currentLi.appendChild(currentImage);
            imagePreviewer.appendChild(selectedParent);

            listOfItems.appendChild(currentLi);
        }

        aside.appendChild(inputHeader);
        aside.appendChild(input);
        aside.appendChild(listOfItems);


        fragment.appendChild(imagePreviewer);
        fragment.appendChild(aside);

        root.appendChild(fragment);

    };

}

module.exports = solve;