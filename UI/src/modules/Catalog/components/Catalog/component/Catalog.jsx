import React from 'react';
import Filter from '../../Filter';
import { Spinner } from 'react-bootstrap';

function Catalog(props) {
    if (!props.fulfilled) {
        return <div>
            <Spinner animation="border" />
        </div>;
    }

    const markupList = props.hotelsList.map(hotel => <li key={hotel.name} className="list-group-item d-flex align-items-center">
        <div className="image-parent" style={{ maxWidth: "100px", maxHeight: "100px" }} >
            <img src={hotel.image} className="img-fluid" alt="lay" />
        </div>
        <div className="ml-4" >
            <h2><a href="/controller/action" onClick={(e) => { e.preventDefault(); props.onClick(hotel.id) }}>{hotel.name}</a></h2>
            <h6>{hotel.locality}, {hotel.country}</h6>
        </div>
        <div style={{ position: "absolute", right: "20px" }} >
            <button type="button" onClick={(e) => props.onClick(hotel.id)} className="btn btn-primary" >Details</button>
        </div>
    </li>);
    const ul = <ul className="list-group">{markupList}</ul>;
    return <div className="row">
        <div className="col-9 col-sm-8" style={{ minWidth: "600px" }} >
            <Filter />
            {ul}
        </div>
    </div>;
}

export default Catalog;