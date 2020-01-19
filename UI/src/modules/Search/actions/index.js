const SET_SEARCH_PARAMETERS = "SET_SEARCH_PARAMETERS";

export { SET_SEARCH_PARAMETERS };

function setSearchParameters(params) {
    return { type: SET_SEARCH_PARAMETERS, params };
}

export default setSearchParameters;