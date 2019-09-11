import React from 'react';
import Filter from '../../Filter';

function Home(props) {
    if (!props.fulfilled) {
        return <div>Loading hotels</div>;
    }

    const markupList = props.hotelsList.map(hotel => <li key={hotel.name} className="list-group-item d-flex align-items-center">
        <div className="image-parent" style={{maxWidth: "100px"}} >
            <img src={hotel.image} className="img-fluid" alt="lay" />
        </div>
        <div style={{marginLeft: "20px"}} >
            <h2><a href="/controller/action" onClick={(e) => { e.preventDefault(); props.onClick(hotel.id) }}>{hotel.name}</a></h2>
            <h6>{hotel.locality}, {hotel.country}</h6>
        </div>
        <div style={{marginLeft: "10px", position: "absolute", right: "20px"}} >
            <button type="button" onClick={(e) => props.onClick(hotel.id)} className="btn btn-primary" >Выбрать</button>
        </div>
    </li>);
    const ul = <ul className="list-group">{markupList}</ul>;
    return  <div className="row">
            <Filter />
            <div className="col-9 col-sm-8" style={{ minWidth: "600px" }} >
                {ul}
            </div>
        </div>
}

export default Home;