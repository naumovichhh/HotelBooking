import React from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import Login from 'modules/Auth/components/Login';
import Home from 'modules/Home/components/Home';
import Admin from 'modules/Admin/components/Admin';
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
                    <AuthorizedRoute exact role="user" path="/edit" component={Admin} />
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
