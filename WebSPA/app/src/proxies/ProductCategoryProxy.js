export default class ProductCategoryProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    get(id) {
        return this.axios.get(this.url + `product_categories/${id}`);
    }

    getAll(page, take) {
        return this.axios.get(this.url + `product_categories?page=${page}&take=${take}`);
    }

    create(params) {
        return this.axios.post(this.url + `product_categories`, params);
    }

    update(id, params) {
        return this.axios.put(this.url + `product_categories/${id}`, params);
    }

    remove(id) {
        return this.axios.delete(this.url + `product_categories/${id}`);
    }
}