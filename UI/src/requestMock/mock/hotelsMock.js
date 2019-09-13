import hotels from './hotels.json';

const hotelsMock = {
    GET: () => {
        return hotels.hotels;
    },
    POST: (data) => {
        hotels.hotels.push(data);
        return hotels.hotels;
    },
    DELETE: (id) => {
        hotels.hotels = hotels.hotels.filter(e => e.id !== id);
        return hotels.hotels;
    },
    PUT: (id, data) => {
        
    }
}

export default hotelsMock;