import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from '../Login';
import Home from '../Home';
import Admin from '../Admin';
import AuthorizedRoute from '../AuthorizedRoute';
import { Provider } from 'react-redux';
import store from 'rdx/store';

const App = () => {
    return (
        <Provider store={store} >
            <BrowserRouter>
                <Switch>
                    <Route exact path="/home" component={Home} />
                    <Route exact path="/login" component={Login} />
                    <AuthorizedRoute exact role="admin" path="/edit" component={Admin} />
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
