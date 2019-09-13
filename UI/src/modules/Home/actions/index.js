import requestMock from 'requestMock';

const GET_HOTELS_REQUEST = "GET_HOTELS_REQUEST";
const GET_HOTELS_SUCCESS = "GET_HOTELS_SUCCESS";
const GET_HOTELS_FAILURE = "GET_HOTELS_FAILURE";

export { GET_HOTELS_REQUEST, GET_HOTELS_SUCCESS, GET_HOTELS_FAILURE };

function _request() {
    return {
        type: GET_HOTELS_REQUEST
    };
}

function success(hotels) {
    return {
        type: GET_HOTELS_SUCCESS,
        hotels
    };
}

function failure(hotels) {
    return {
        type: GET_HOTELS_FAILURE
    };
}

function fetchHotels() {
    return dispatch => {
        dispatch(_request());
        requestMock({
            method: "GET",
            url: "api/hotels",
        })
        .then(data => dispatch(success(data)));
    }
}

export default fetchHotels;