import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import { connect } from 'react-redux';

class AuthorizedRoute extends React.Component {
    render() {
        let {auth, component: Component, role, ...rest} = this.props;
        return <Route {...rest} render={(props) =>
            auth.loggedIn && auth.role === role ?
            <Component {...props} /> :
            <Redirect to="/login" />
        }/>;
    }
}

const mapStateToProps = (state) => {
    return { auth: state.auth };
}

export default connect(mapStateToProps)(AuthorizedRoute);