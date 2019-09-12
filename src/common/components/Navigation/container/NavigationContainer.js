import React from 'react';
import { withRouter } from 'react-router-dom';
import Navigation from '../component/Navigation';

class NavigationContainer extends React.Component {
    onSelect = (key, e) => {
        e.preventDefault();
        this.props.history.push(`/${key}`);
    };

    render() {
        return <Navigation onSelect={this.onSelect} />;
    }
}

export default withRouter(NavigationContainer);