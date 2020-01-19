import React from 'react';
import Autosuggest from 'react-autosuggest';
import countries from './countries.min.json';

class AutosuggestContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = { value: '', suggestions: [] };
    }

    onSuggestionsFetchRequested = ({ value }) => {
        console.log(value);
        let inputLength = value.length;
        let inputValue = value.trim().toLowerCase();
        if (inputLength && this.props) {
            let localities = countries[this.props.country];
            if (localities) {
                let suggestions = localities.filter(l => l.toLowerCase().slice(0, inputLength) === inputValue);
                this.setState({ suggestions });
            } else {
                this.setState({ suggestions: [] });
            }
        } else {
            this.setState({ suggestions: [] });
        }
    };

    onSuggestionsClearRequested = () => {
        this.setState({ suggestions: [] });
    };

    render() {

        const { value, onChange } = this.props;
        const inputProps = { value, onChange };

        return <Autosuggest
            suggestions={this.state.suggestions}
            onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
            onSuggestionsClearRequested={this.onSuggestionsClearRequested}
            getSuggestionValue={suggestion => suggestion}
            renderSuggestion={suggestion => suggestion}
            inputProps={inputProps}
        />;
    }
}

export default AutosuggestContainer;