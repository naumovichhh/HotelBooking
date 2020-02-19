import React from 'react';
import Autosuggest from 'react-autosuggest';

class AutosuggestContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = { value: '', suggestions: [] };
    }

    onSuggestionsFetchRequested = ({ value }) => {
        let inputValue = value.trim().toLowerCase();
        let inputLength = inputValue.length;
        let options = this.props.options;
        if (inputLength) {
            if (options) {
                let suggestions = options.filter(o => o.toLowerCase().slice(0, inputLength) === inputValue);
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
        const inputProps = { value, onChange, class: "form-control" };

        return <Autosuggest
            suggestions={this.state.suggestions}
            onSuggestionsFetchRequested={this.onSuggestionsFetchRequested}
            onSuggestionsClearRequested={this.onSuggestionsClearRequested}
            getSuggestionValue={suggestion => suggestion}
            renderSuggestion={suggestion => <div>{suggestion}</div>}
            inputProps={inputProps}
        />;
    }
}

export default AutosuggestContainer;