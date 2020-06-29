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
            user: this.$store.state.user,
            isLoading: false,
            customers: [],
            products: [],
            itemsview:[],
            model: {
                orderDetails: [
                    // {
                    // productId: null,
                    // quantity: null
                    // }
                ],
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
                ingredients: null,
                quantity: null
            },
            customer: {
                customerId: null,
                customerName: null,
                customerAge: null,
                customer_Category: null,
                cards: null,
                orders: null,
                email: null
            },
            subtotal: 0,            
        }
    },
    methods: {
        initialize() {
            this.isLoading = true;
            let customers = this.$proxies.userProxy.getAll(1,100),
                products = this.$proxies.productProxy.getAll(1,100);
            Promise.all([customers, products])
            .then(values => {
                //Cargamos los datos:
                this.customers = values[0].data.items;
                this.products = values[1].data.items;
                //Elegimos los datos iniciales:
                this.product.productId = this.products[0].productId;
                this.customer = this.customers.find(x => x.email === this.user.id);
                this.onChangeProductSelection();
                this.model.customerId = this.customer.customerId;
                this.isLoading=false;
            })
        },
        onChangeProductSelection() {
            let product = this.products.find(
                x => x.stock <= -1000
            );
            if (product != null) {
                var params = {
                    ammount: -1000
                }
                this.$proxies.productProxy.addStock(product.productId, params)
                this.$router.push('/orders/create');
            }
            else {
                product = this.products.find(
                    x => x.productId === this.product.productId
                );
            }    
            //TODO: ver bien lo del stock
            this.product.stock = product.stock;
            this.product.quantity = 1;
            this.product.productPrice = product.productPrice;
            this.product.productName = product.productName;
        },
        addProduct() {
            if (!this.model.orderDetails.some(x => x.productId === this.product.productId)) {
                let item = {
                    productId: this.product.productId,
                    quantity: this.product.quantity                    
                };
                let itemview = {
                    productId: this.product.productId,
                    productName: this.product.productName,
                    quantity: this.product.quantity,
                    price: this.product.productPrice * this.product.quantity
                };
                let subtotal = subtotal + (this.product.quantity * this.product.productPrice);
                this.itemsview.push(itemview);
                this.model.orderDetails.push(item);
                this.onChangeProductSelection();
            }
        },
        removeProduct(id) {
            this.itemsview = this.itemsview.filter(x => x.productId != id);
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
                    if (this.user.customer_Category.id == 2)
                    this.$router.push(`/orders/${item.orderId}/payorder`);
                    else
                    this.$router.push("/orders");
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