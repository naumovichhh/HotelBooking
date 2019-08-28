import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import Authorization from '../../services/authorization/Authorization';

class AuthorizedRoute extends React.Component {
    render() {
        let {authorization, component: Component, role, ...rest} = this.props;
        return <Route {...rest} render={(props) =>
            authorization.currentAccount && authorization.currentAccount.role === role ?
            <Component {...props} /> :
            <Redirect to="/login" />
        }/>;
    }
}

export default AuthorizedRoute;