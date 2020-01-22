import request from 'common/request';

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

function failure() {
    return {
        type: GET_HOTELS_FAILURE
    };
}

function fetchHotels(params) {
    return async dispatch => {
        dispatch(_request());
        try {
            let response = await request({
                method: "GET",
                url: "api/hotels"+"?"+paramsToQuery(params)
            });
            if (response.ok) dispatch(success(await response.json()));
            else throw new Error(response.statusText);
        }
        catch {
            dispatch(failure());
        }
    };
}

function paramsToQuery(params) {
    return `country=${params.country}&locality=${params.locality}&from=${params.from}
&to=${params.to}&adult=${params.adult}&child=${params.child}`;
}

export { fetchHotels };