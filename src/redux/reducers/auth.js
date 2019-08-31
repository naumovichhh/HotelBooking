const auth = (state, action) => {
    switch (action.type) {
        case "LOGIN":
            return { loggedIn: true, user: action.user, role: action.role };
        case "LOGOUT":
            return { loggedIn: false };
        default:
            return state;
    }
}

export default auth;