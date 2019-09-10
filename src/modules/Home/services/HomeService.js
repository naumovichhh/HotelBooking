import store from "rdx/store";
import fetchHotels from "../actions";

class HomeService {
    static fetchHotels() {
        store.dispatch(fetchHotels());
    }
}

export default HomeService;