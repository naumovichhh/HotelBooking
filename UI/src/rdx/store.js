import { createStore, applyMiddleware } from 'redux';
import combinedReducer from './reducers/combinedReducer';
import thunk from 'redux-thunk';
import { composeWithDevTools } from 'redux-devtools-extension'

const store = createStore(combinedReducer, composeWithDevTools(applyMiddleware(thunk)));
export default store;