import React from 'react';
import { Form, Button } from 'react-bootstrap';
import Select from 'react-select';
import FastSelect from 'common/components/FastSelect';

const Home = (props) => {
    let countries = Object.keys(props.localities).map(c => ({ value: c, label: c }));
    let localities = props.localities[props.country] && Array.from(new Set(props.localities[props.country])).map(l => ({ value: l, label: l }));
    return <div className="row" >
        <div className="col-10 col-md-6" >
            <Form>            
                <h3>Find a place to stay </h3>
                <Form.Group>
                    <Form.Label>Country</Form.Label>
                    <Select value={{ label: props.country, value: props.country }} onChange={props.onCountryChange} options={countries} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Locality</Form.Label>
                    <FastSelect value={{ label: props.locality, value: props.locality }} onChange={props.onLocalityChange} options={localities} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>From</Form.Label>
                    <Form.Control value={props.from} onChange={props.onFromChange} type="date" />
                </Form.Group>
                <Form.Group>
                    <Form.Label>To</Form.Label>
                    <Form.Control value={props.to} onChange={props.onToChange} type="date" />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Adult places</Form.Label>
                    <Form.Control value={props.adult} onChange={props.onAdultChange} type="number" />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Child places</Form.Label>
                    <Form.Control value={props.child} onChange={props.onChildChange} type="number" />
                </Form.Group>
                <Button variant="primary" onClick={props.onSubmit}>
                    Search
                </Button>
            </Form>
        </div>
    </div>
};

export default Home;