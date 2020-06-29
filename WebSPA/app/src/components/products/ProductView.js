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
            }
        }
    },
    methods: {
        getAll(page) {
            this.isLoading = true;

            this.$proxies.productProxy.getAll(page, 10)
                .then(x => {
                    this.collection = x.data;
                    this.isLoading = false;
                    console.log(this.collection.items[0].imageUrl);
                }).catch(() => {
                    this.isLoading = false;
                });
        }
    }
}