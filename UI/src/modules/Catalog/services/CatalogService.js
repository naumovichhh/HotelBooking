import store from "rdx/store";
import fetchHotels from "../actions";

class CatalogService {
    static fetchHotels() {
        store.dispatch(fetchHotels());
    }
}

export default CatalogService;