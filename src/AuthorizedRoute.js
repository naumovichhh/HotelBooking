import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import authorization from './services/authorization/Authorization';

function AuthorizedRoute({component: Component, role, ...rest}) {
    return <Route {...rest} render={(props) =>
        authorization.currentAccount && authorization.currentAccount.role === role ?
        <Component {...props} /> :
        <Redirect to="/login" />
    }/>;
}

export default AuthorizedRoute;