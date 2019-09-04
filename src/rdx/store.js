import { createStore } from 'redux';
import combinedReducer from './reducers/combinedReducer';
import thunk from 'react-thunk';

export default createStore(combinedReducer, { auth: { loggedIn: false } }, applyMiddleware(thunk));