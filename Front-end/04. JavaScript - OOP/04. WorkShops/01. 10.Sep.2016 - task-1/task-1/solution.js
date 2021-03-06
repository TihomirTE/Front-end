function solve() {


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
            // variant 1
            /*let uniqueTypes = [];

             for (const product of products) {
                 if (uniqueTypes.indexOf(product.productType) === -1) {
                     uniqueTypes.push(product.productType);
                 }
             }
             if (uniqueTypes.length === 0) {
                 return uniqueTypes;
             } else {
                 return uniqueTypes.sort();
             }*/

            // variant 2
            const uniqueTypes = {};
            products.forEach(p => uniqueTypes[p.productType] = true);

            const unique = [];
            for (const pr in uniqueTypes) {
                unique.push(pr);
            }
            return unique.sort();


        }

        function getInfo() {

            if (this.products.length === 0) {
                return {
                    totalPrice: 0,
                    products: []
                };
            } else {
                return {
                    totalPrice: sumPrices(),
                    products: productUniqueName().map(x => x === {})
                };
            }

            // const groupName = {};

            // products.forEach(p => {
            //     groupName[p.name].quantity += 1,
            //         groupName[p.name].totalPrice = p.price

            // });

            // return {
            //     products: uniqueNames,
            //     totalPrice: sumPrices()
            // };
        }

        function sumPrices() {
            let sum = 0;
            products.forEach(function(x) {
                sum += x.price;
            });
            return sum;
        }

        function productUniqueName() {
            let uniqueName = {};
            products.forEach(x => uniqueName[x.name] = true);
            return Object.keys(uniqueName);
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