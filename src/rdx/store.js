import { createStore, applyMiddleware } from 'redux';
import combinedReducer from './reducers/combinedReducer';
import thunk from 'redux-thunk';

const store = createStore(combinedReducer, { auth: { loggedIn: false } }, applyMiddleware(thunk));
export default store;