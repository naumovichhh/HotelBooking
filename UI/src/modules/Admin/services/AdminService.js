import request from 'request';
import store from 'common/redux/store';
import fetchHotels from '../actions';

class AdminService {
    static fetchHotels() {
        store.dispatch(fetchHotels());
    }
}

export default AdminService;