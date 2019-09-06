import request from 'requestMock';
import store from 'rdx/store';

const AUTHORIZE_REQUEST = "AUTHORIZE_REQUEST";
const AUTHORIZED = "AUTHORIZED";
const AUTHORIZE_DENIED = "AUTHORIZE_REJECTED";

export { AUTHORIZE_REQUEST, AUTHORIZED, AUTHORIZE_DENIED };

function authorizeRequest() {
    return {
        type: AUTHORIZE_REQUEST
    }
}

function authorized(data) {
    return {
        type: AUTHORIZED,
        ...data
    }
}

function authorizeDenied() {
    return {
        type: AUTHORIZE_DENIED
    }
}

function authorize(params) {
    return dispatch => {
        store.dispatch(authorizeRequest);
        request(params)
        .then(data => store.dispatch(authorized(data)))
        .catch(() => authorizeDenied());
    };
}

export { authorize };