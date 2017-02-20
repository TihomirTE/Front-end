/* globals module */

//"use strict";

function solve() {
    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = Number(price);
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }
        add(product) {
            this.products.push(product);
            return this;
        }
        remove(product) {
            let result = this.products.indexOf(product);
            if (result === -1) {
                throw Error('product does not contain in the shopping cart');
            }

            return this.products.splice(result, 1);
        }
        showCost() {
            return this.products.reduce((a, b) => a + b.price, 0);
        }
        showProductTypes() {
            let arr = [];

            function compare(a, b) {
                if (a.productType < b.productType) {
                    return -1;
                }
                if ((a.productType > b.productType)) {
                    return 1;
                }
                return 0;
            }
            // sort alphabetically
            arr = this.products.sort(compare);

            // get unique productTypes
            return [...new Set(arr.map(item => item.productType))];
        }
        getInfo() {
            const brand = {};

            for (let p of this.products) {
                if (!brand[p.name]) {
                    brand[p.name] = {
                        name: p.name,
                        totalPrice: 0,
                        quantity: 0
                    };
                }

                brand[p.name].totalPrice += p.price;
                brand[p.name].quantity += 1;
            }

            const products = Object.keys(brand).map(groupName => brand.groupName);
            const totalPrice = this.products.reduce((a, b) => a + b.price, 0);

            return {
                products,
                totalPrice
            };
        }
    }
    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;