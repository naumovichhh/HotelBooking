import React from 'react';
import { withRouter } from 'react-router-dom';
import Navigation from '../component/Navigation';
import { connect } from 'react-redux';

class NavigationContainer extends React.Component {
    onSelect = (key, e) => {
        e.preventDefault();
        this.props.history.push(`/${key}`);
    };

    render() {
        return <Navigation onSelect={this.onSelect} auth={this.props.auth} />;
    }
}

const mapStateToProps = (state) => ({ auth: state.auth });

export default connect(mapStateToProps)(withRouter(NavigationContainer));