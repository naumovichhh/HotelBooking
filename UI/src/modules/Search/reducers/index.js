import { SET_SEARCH_PARAMETERS } from "../actions";

function search(state = {}, action) {
    switch (action.type) {
        case SET_SEARCH_PARAMETERS:
            return { ...action.params };
        default:
            return state;
    }
}

export default search;