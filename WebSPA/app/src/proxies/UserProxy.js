export default class UserProxy {
    constructor(axios, url) {
        this.axios = axios;
        this.url = url;
    }

    getAll(page, take) {
        return this.axios.get(this.url + `customers?page=${page}&take=${take}`);
    }
    get(id){
        return this.axios.get(this.url + `customers/${id}`)
    }
}