import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from '../Login/Login';
import Home from '../Home/Home';
import Admin from '../Admin/Admin';
import AuthorizedRoute from '../AuthorizedRoute/AuthorizedRoute';
import Authorization from '../../services/authorization/Authorization';
import store from 'redux/store';
import { Provider } from 'redux';

let authorization = new Authorization();

const App = () => {
    return (
        <Provider store={store} >
            <BrowserRouter>
                <Switch>
                    <Route exact path="/home" component={Home} />
                    <Route exact path="/login" authorization={authorization} render={(props) => <Login {...props} authorization={authorization} />} />
                    <AuthorizedRoute exact authorization={authorization} role="admin" path="/edit" component={Admin} />
                    <Redirect exact from="/" to="home" />
                    <Route component={NoMatch} />
                </Switch>
            </BrowserRouter>
        </Provider>
    );
}

const NoMatch = () => {
    return <div>Not found</div>;
}

export default App;
