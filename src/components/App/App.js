import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from '../Login/Login';
import Home from '../../Home';
import Admin from '../Admin/Admin.js';
import AuthorizedRoute from '../AuthorizedRoute/AuthorizedRoute';
import Authorization from '../../services/authorization/Authorization';

let authorization = new Authorization();

const App = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route exact path="/home" component={Home} />
                <Route exact path="/login" authorization={authorization} render={(props) => <Login {...props} authorization={authorization} />} />
                <AuthorizedRoute exact authorization={authorization} role="admin" path="/edit" component={Admin} />
                <Redirect exact from="/" to="home" />
                <Route component={NoMatch} />
            </Switch>
        </BrowserRouter>
    );
}

const NoMatch = () => {
    return <div>Not found</div>;
}

export default App;
