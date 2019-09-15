import React from 'react';
import { Form, Button } from 'react-bootstrap';
import Select from 'react-select';

const Home = (props) => {
    return <div className="row" >
        <div className="col-10 col-md-6" >
            <Form>
                <Form.Group>
                    <Form.Label>Country</Form.Label>
                    <Select onChange={props.onCountryChange} options={props.countries.map(c => ({ value: c, label: c }))} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Locality</Form.Label>
                    <Form.Control type="text" onChange={props.onLocalityChange} value={props.locality} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>From</Form.Label>
                    <Form.Control type="date" value={props.from} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>To</Form.Label>
                    <Form.Control type="date" value={props.to} />
                </Form.Group>
                <Button variant="primary" onClick={props.onSubmit}>
                    Search
                </Button>
            </Form>
        </div>
    </div>
};

export default Home;