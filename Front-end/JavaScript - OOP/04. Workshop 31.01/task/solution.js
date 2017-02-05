function solve() {

    function sortTypes(a, b) {

    }

    function getProduct(productType, name, price) {

        return {
            productType: productType,
            name: name,
            price: price
        };
    }

    function getShoppingCart() {
        let products = [];

        function add(product) {
            products.push(product);

            return this;
        }

        function remove(product) {
            let missing = true;

            if (products.length === 0) {
                throw 'ShoppingCart is empty';
            }

            for (let i = 0; i < products.length; i += 1) {
                if (products[i] === product) {
                    products.splice(i, 1);
                    missing = false;
                }
            }
            if (missing) {
                throw 'Product does not exist';
            }

            return this;
        }

        function showCost() {
            let sum = 0;

            if (products.length === 0) {
                return sum;
            } else {
                for (let i = 0; i < products.length; i += 1) {
                    sum += products[i].price;
                }
                return sum;
            }
        }

        function showProductTypes() {
            let type = [];

            if (products.length === 0) {
                return type;
            } else {
                return products.sort();
            }
        }

        function getInfo() {
            let price = 0,
                productsArr = [];

            let productQuantity = 1;

            let obj = {
                totalPrice: price,
                products: productsArr
            };

            if (products.length === 0) {
                return obj;
            } else {
                products = products.sort();
                for (let i = 0; i < products.length; i += 1) {
                    price += products[i].price;


                    productsArr = {
                        name: products.name,
                        totalPrice: price,
                        quantity: productQuantity
                    };
                }


            }
        }

        return {
            products: products,
            add: add,
            remove: remove,
            showCost: showCost,
            showProductTypes: showProductTypes,
            getInfo: getInfo
        };
    }

    return {
        getProduct: getProduct,
        getShoppingCart: getShoppingCart
    };
}

module.exports = solve();