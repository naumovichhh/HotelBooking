import React from 'react';
import { Route } from 'react-router-dom';
import { connect } from 'react-redux';
import NotFound from 'common/components/NotFound';

class AuthorizedRoute extends React.Component {
    render() {
        let {auth, component: Component, role, ...rest} = this.props;
        return <Route {...rest} render={(props) =>
            auth.authorized && auth.user.role === role ?
            <Component {...props} /> :
            <NotFound />
        }/>;
    }
}

const mapStateToProps = (state) => {
    return { auth: state.auth };
}

export default connect(mapStateToProps)(AuthorizedRoute);