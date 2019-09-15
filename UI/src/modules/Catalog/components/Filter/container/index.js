import React from 'react';
import Filter from '../component';
import { connect } from 'react-redux';

class FilterContainer extends React.Component {
    render() {
        return <Filter {...this.props} />
    }
}

const mapStateToProps = (state) => {
    return {};
    return { ...state.catalog.filter };
}

export default connect(mapStateToProps)(FilterContainer);