import React from 'react';
import Search from '../../Search';
import { Spinner, Alert } from 'react-bootstrap';

function Catalog(props) {
    let hotelsResult;
    if (props.inProcess) {
        hotelsResult = <div>
            <Spinner animation="border" />
        </div>;
    } else if (props.failed) {
        hotelsResult = <div>
            <Alert variant="danger">
                <Alert.Heading>Loading failed</Alert.Heading>
            </Alert>
        </div>;
    } else if (!props.fulfilled) {
        hotelsResult = null;
    } else if (props.hotelsList.length > 0) {
        const markupList = props.hotelsList.map(hotel => <li key={hotel.name} className="list-group-item d-flex align-items-center">
            <div className="image-parent" style={{ maxWidth: "100px", maxHeight: "100px" }} >
                <img src={hotel.picture} className="img-fluid" alt="lay" />
            </div>
            <div className="ml-4" >
                <h2><a href="/inactive" onClick={(e) => { e.preventDefault(); props.onClick(hotel.id) }}>{hotel.name}</a></h2>
                <h6>{hotel.locality}, {hotel.country}</h6>
            </div>
            <div style={{ position: "absolute", right: "20px" }} >
                <button type="button" onClick={(e) => props.onClick(hotel.id)} className="btn btn-primary" >Details</button>
            </div>
        </li>);
        hotelsResult = <ul className="list-group">{markupList}</ul>;
    } else {
        hotelsResult = <Alert variant="info"><Alert.Heading>There are no matching offers</Alert.Heading></Alert>;
    }
    return <div className="row">
        <div className="col-9 col-sm-8" >
            <Search />
            <br />
            {hotelsResult}
        </div>
    </div>;
}

export default Catalog;