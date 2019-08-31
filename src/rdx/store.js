import { createStore } from 'redux';
import combinedReducer from './reducers/combinedReducer';

export default createStore(combinedReducer, { auth: { loggedIn: false } });