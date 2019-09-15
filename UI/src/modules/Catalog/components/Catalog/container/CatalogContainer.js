import { connect } from 'react-redux';
import React from 'react';
import Catalog from '../component/Catalog';
import CatalogService from '../../../services/CatalogService';

class CatalogContainer extends React.Component {
    componentDidMount() {
        CatalogService.fetchHotels();
    }

    onClick = (id) => {
        this.props.history.push(`/hotel/${id}`);
    }

    render() {
        return <Catalog
            hotelsList={this.props.list}
            fulfilled={this.props.fulfilled}
            onClick={this.onClick} />
    }
}

const mapStateToProps = (state) => ({ ...state.hotels });

export default connect(mapStateToProps)(CatalogContainer);