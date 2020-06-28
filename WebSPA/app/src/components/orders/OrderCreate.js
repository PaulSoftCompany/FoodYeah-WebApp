import Loader from '../../shared/Loader'

export default {
    name: 'OrderCreate',
    components: {
        Loader
    },
    mounted() {
        this.initialize();
    },
    // computed: {
    //     iva() {
    //         if (this.model.items.length === 1)
    //             return this.model.items[0].iva;

    //         if (this.model.items.length > 1)
    //             return this.model.items.reduce((a, b) => a.iva + b.iva);

    //         return 0;
    //     },
    //     subTotal() {
    //         if (this.model.items.length === 1)
    //             return this.model.items[0].subTotal;

    //         if (this.model.items.length > 1)
    //             return this.model.items.reduce((a, b) => a.subTotal + b.subTotal);

    //         return 0;
    //     },
    //     total() {
    //         if (this.model.items.length === 1)
    //             return this.model.items[0].total;

    //         if (this.model.items.length > 1)
    //             return this.model.items.reduce((a, b) => a.total + b.total);

    //         return 0;
    //     }
    // },
    data() {
        return {
            // isLoading: false,
            // clients: [],
            // products: [],
            // model: {
            //     clientId: null,
            //     items: []
            // },
            // product: {
            //     productId: null,
            //     quantity: 1,
            //     unitPrice: 0
            // }
            isLoading: false,
            customers: [],
            products: [],
            model: {
                orderDetails: [{
                    productId: null,
                    quantity: null
                }],
                //orderDetails = [{
                //    productId = null,
                //    quantity = null
                //}],
                customerId: null
            },
            product: {
                productId: null,
                product_Category: null,
                productName: null,
                productPrice: null,
                sellDay: null,
                stock: null,
                imageUrl: null,
                ingredients: null
                // productName: null,
                // product_CategoryId: null,
                // productPrice: null,
                // sellDay:null,
                // ingredients: new Array,
                // imageUrl:"test",
                // ingrediente:null

                //stock: null,
                //productId: null,
            },
            customer: {
                customerId: null,
                customerName: null,
                customerAge: null,
                customer_Category: null,
                cards: null,
                orders: null,
                email: null

                //customerId: null,
                //customerName: null,
            }            
        }
    },
    methods: {
        initialize() {
            this.isLoading = true;

            // let clients = this.$proxies.clientProxy.getAll(1, 100),
            //     products = this.$proxies.productProxy.getAll(1, 100);
            let customers = this.$proxies.userProxy.getAll(1,10),
                products = this.$proxies.productProxy.getAll(1,10);
                

            // Promise.all([clients, products])
            //     .then(values => {
            //         this.clients = values[0].data.items;
            //         this.products = values[1].data.items;

            //         this.model.clientId = this.clients[0].clientId;
            //         this.product.productId = this.products[0].productId;

            //         this.onChangeProductSelection();
            //         this.isLoading = false;
            //     })
            //EL ERROR ESTA A CONTINUACION:
            Promise.all([customers, products])
            .then(values => {
                this.customers = values[0].data.items;
                this.products = values[1].data.items;

                 this.model.customerId = this.customers[0].customerId;
                 this.product.productId = this.products[0].productId;

                //this.onChangeProductSelection();
                this.isLoading=false;
            })
        },
        onChangeProductSelection() {
            let product = this.products.find(
                x => x.productId == this.product.productId
            );

            this.product.stock = 1;
             this.product.unitPrice = product.unitPrice;
        },
        addProduct() {
            if (!this.model.orderDetails.some(x => x.productId === this.product.productId)) {
                // // Debería venir del servidor
                // const ivaRate = 0.18;

                let item = {
                    // Server
                    productId: this.product.productId,
                    stock: this.product.stock
                    // unitPrice: this.product.unitPrice,
                    // quantity: this.product.quantity,
                    // name: this.products.find(x => x.productId === this.product.productId).name,
                    // total: this.product.unitPrice * this.product.quantity
                };

                // item.subTotal = Math.round(item.total / (1 + ivaRate) * 100) / 100;
                // item.iva = Math.round((item.total - item.subTotal) * 100) / 100;

                this.model.orderDetails.push(item);
                this.onChangeProductSelection();
            }
        },
        removeProduct(id) {
            this.model.orderDetails = this.model.orderDetails.filter(x => x.productId != id);
        },
        create() {
            this.isLoading = true;

            this.$proxies.orderProxy
                .create(this.model)
                .then(() => {
                    this.isLoading = false;
                    this.$notify({
                        group: "global",
                        type: "is-success",
                        text: 'La orden ha sido creada'
                    });

                    this.$router.push('/orders');
                })
                .catch(() => {
                    this.isLoading = false;
                    this.$notify({
                        group: "global",
                        type: "is-danger",
                        text: 'Ocurrió un error inesperado'
                    });
                })
        }
    }
}