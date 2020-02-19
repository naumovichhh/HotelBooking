import request from 'common/request';

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
    return async dispatch => {
        dispatch(_request());
        try {
            let response = await request("api/auth", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(credentials)
            });
            if (response.ok) {
                throw new Error("Not implemented");
                dispatch(success());
            } else {
                throw new Error();
            }
        }
        catch {
            dispatch(failure());
        }
    };
}

export { authorize };