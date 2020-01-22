import React from 'react';
import AsyncSelect from 'react-select/async-creatable';

class FastCreatableSelect extends React.Component {
    constructor(props) {
        super(props);
    }

    loadOptions = (input, callback) => {
        let options;
        let searchString = input.trim().toLowerCase();
        let searchLength = searchString.length;
        if (searchLength > 0 && this.props.options) {
            options = this.props.options.filter(o => {
                let sliced = o.value.toLowerCase().slice(0, searchLength);
                return sliced === searchString;
            });
        } else {
            options = [];
        }

        return callback(options.slice(0, 10));
    }

    render() {
        return <AsyncSelect loadOptions={this.loadOptions} {...this.props} />
    }
}

export default FastCreatableSelect;