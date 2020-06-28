export default class CardProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }
    get(id) {
        return this.axios.get(this.url + `cards/${id}`);
    }
    getAll(page, take) {
        return this.axios.get(this.url + `cards?page=${page}&take=${take}`);
    }
    create(params) {
        return this.axios.post(this.url + `cards`, params);
    }
    update(id, params) {
        return this.axios.put(this.url + `cards/${id}`, params);
    }
    remove(id) {
        return this.axios.delete(this.url + `cards/${id}`);
    }
}