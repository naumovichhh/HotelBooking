import { AUTHORIZATION_REQUEST, AUTHORIZATION_SUCCESS, AUTHORIZATION_FAILURE } from "../actions";

function auth(state = { authorized: false }, action) {
    switch (action.type) {
        case AUTHORIZATION_REQUEST:
            return { ...state, inProcess: true, failed: false };
        case AUTHORIZATION_SUCCESS:
            return { ...state, user: action.user, authorized: true, failed: false, inProcess: false };
        case AUTHORIZATION_FAILURE:
            return { ...state, inProcess: false, failed: true, authorized: false }
        default:
            return state;
    }
}

export default auth;