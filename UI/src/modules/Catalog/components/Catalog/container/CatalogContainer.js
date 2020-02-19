import { connect } from 'react-redux';
import React from 'react';
import Catalog from '../component/Catalog';
import { fetchHotels as fetchHotelsAction } from '../../../actions';
import { Redirect } from 'react-router-dom';

class CatalogContainer extends React.Component {
    componentDidMount() {
        if (this.props.search.country)
            this.props.fetchHotels(this.props.search);
    }

    onClick = (id) => {
        this.props.history.push(`/hotel/${id}`);
    }

    render() {
        if (!this.props.search.country)
            return <Redirect to="/home" />

        return <Catalog
            hotelsList={this.props.list}
            fulfilled={this.props.fulfilled}
            failed={this.props.failed}
            inProcess={this.props.inProcess}
            onClick={this.onClick} />
    }
}

const mapState = (state) => ({ ...state.hotels, search: state.search });
const mapDispatch = dispatch => ({
    fetchHotels: (params) => { dispatch(fetchHotelsAction(params)); }
});

export default connect(mapState, mapDispatch)(CatalogContainer);