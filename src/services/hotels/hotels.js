import request from 'request/request';

class Hotels {
    async get() {
        let result = await request({
            url: "api/hotels",
            method: "GET"
        });
        return result;
    }

    getHotel(id) {

    }

    create() {

    }

    delete() {

    }

    edit(hotel) {

    }
}