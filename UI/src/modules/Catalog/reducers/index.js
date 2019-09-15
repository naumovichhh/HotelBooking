import { GET_HOTELS_REQUEST, GET_HOTELS_SUCCESS, GET_HOTELS_FAILURE } from '../actions';

function hotels(state = { fulfilled: false }, action) {
    switch (action.type) {
        case GET_HOTELS_REQUEST:
            return state;
        case GET_HOTELS_SUCCESS:
            return { ...state, fulfilled: true, list: action.hotels };
        case GET_HOTELS_FAILURE:
            return { ...state, error: true }
        default:
            return state;
    }
}

export default hotels;