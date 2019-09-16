import React from 'react';
import { Form, Button } from 'react-bootstrap';
import Select from 'react-select';

const Home = (props) => {
    return <div className="row" >
        <div className="col-10 col-md-6" >
            <Form>            
                <h3>Find a place to stay </h3>
                <Form.Group>
                    <Form.Label>Country</Form.Label>
                    <Select ref={props.selectRef} options={props.countries.map(c => ({ value: c, label: c }))} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Locality</Form.Label>
                    <Form.Control ref={props.localityRef} type="text" />
                </Form.Group>
                <Form.Group>
                    <Form.Label>From</Form.Label>
                    <Form.Control value={props.from} onChange={props.onFromChange} type="date" />
                </Form.Group>
                <Form.Group>
                    <Form.Label>To</Form.Label>
                    <Form.Control value={props.to} onChange={props.onToChange} type="date" />
                </Form.Group>
                <Button variant="primary" onClick={props.onSubmit}>
                    Search
                </Button>
            </Form>
        </div>
    </div>
};

export default Home;