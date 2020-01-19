import request from 'request';
import store from 'rdx/store';

const AUTHORIZATION_REQUEST = "AUTHORIZATION_REQUEST";
const AUTHORIZATION_FAILURE = "AUTHORIZATION_FAILURE";
const AUTHORIZATION_SUCCESS = "AUTHORIZATION_SUCCESS";

export { AUTHORIZATION_REQUEST, AUTHORIZATION_FAILURE, AUTHORIZATION_SUCCESS };

function _request() {
    return {
        type: AUTHORIZATION_REQUEST
    }
}

function success(data) {
    return {
        type: AUTHORIZATION_SUCCESS,
        ...data
    }
}

function failure() {
    return {
        type: AUTHORIZATION_FAILURE
    }
}

function authorize(credentials) {
    return dispatch => {
        store.dispatch(_request());
        request({
            method: "POST",
            url: "api/auth",
            body: JSON.stringify(credentials)
        })
        .then(result => {
            if (result.authorized)
                store.dispatch(success({ user: result.user }));
            else
                store.dispatch(failure);
        });
    };
}

export { authorize };