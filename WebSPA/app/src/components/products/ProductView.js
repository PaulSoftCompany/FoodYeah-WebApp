import Loader from '../../shared/Loader'
import Pager from '../../shared/Pager'

export default {
    name: 'ProductView',
    components: {
        Loader, Pager
    },
    mounted() {
        this.getAll(1);
    },
    data() {
        return {
            isLoading: false,
            collection: {
                hasItems: false,
                items: [],
                total: 0,
                page: 1,
                pages: 0
            },
            menu: [],
            carta: []
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true;

            this.$proxies.productProxy.getAll(page, 100)
                .then(x => {
                    this.collection = x.data;
                    this.isLoading = false;
                    this.carta = this.collection.items.filter(x => x.product_Category.product_CategoryName === 'carta01');
                    this.menu = this.collection.items.filter(x => x.product_Category.product_CategoryName === 'menu01');
                }).catch(() => {
                    this.isLoading = false;
                });
        },
        button: async function (productId) {
            var params = {
                AddStock: -100000
            }
            
            function sleep(ms) {
                return new Promise(resolve => setTimeout(resolve, ms));
              }
            
            this.$proxies.productProxy.addStock(productId, params)
            this.isLoading = true;
            await sleep(4000);
            this.isLoading = false;
            this.$router.push('/orders/create');
        }
    }
}
