import { REQUEST_HOTELS, RECEIVE_HOTELS } from '../actions';

function hotels(state = { fulfilled: false }, action) {
    switch (action.type) {
        case REQUEST_HOTELS:
            return state;
        case RECEIVE_HOTELS:
            return { ...state, fulfilled: true, list: action.hotels };
        default:
            return state;
    }
}

export default hotels;