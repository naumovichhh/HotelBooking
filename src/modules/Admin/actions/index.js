import request from 'requestMock';

const REQUEST_HOTELS = "REQUEST_HOTELS";
const RECEIVE_HOTELS = "RECEIVE_HOTELS";

export { REQUEST_HOTELS, RECEIVE_HOTELS };

function requestHotels() {
    return {
        type: REQUEST_HOTELS
    };
}

function receiveHotels(hotels) {
    return {
        type: RECEIVE_HOTELS,
        hotels
    };
}

function fetchHotels() {
    return dispatch => {
        dispatch(requestHotels());
        request({
            method: "GET",
            url: "/api/hotels",
        })
        .then(data => dispatch(receiveHotels(data)));
    }
}

export default fetchHotels;