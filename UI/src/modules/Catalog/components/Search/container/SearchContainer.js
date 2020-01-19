import React from 'react';
import Search from '../component/Search';
import { connect } from 'react-redux';
import fetchHotelsAction from '../../../actions';
import setSearchParametersAction from 'modules/Search/actions';

const msInDay = 24*3600*1000;

class SearchContainer extends React.Component {
    countries = ["Afghanistan","Albania","Algeria","Andorra","Angola","Anguilla","Antigua & Barbuda","Argentina","Armenia","Aruba","Australia","Austria","Azerbaijan","Bahamas"
	,"Bahrain","Bangladesh","Barbados","Belarus","Belgium","Belize","Benin","Bermuda","Bhutan","Bolivia","Bosnia & Herzegovina","Botswana","Brazil","British Virgin Islands"
	,"Brunei","Bulgaria","Burkina Faso","Burundi","Cambodia","Cameroon","Canada","Cape Verde","Cayman Islands","Chad","Chile","China","Colombia","Congo","Cook Islands","Costa Rica"
	,"Cote D Ivoire","Croatia","Cruise Ship","Cuba","Cyprus","Czech Republic","Denmark","Djibouti","Dominica","Dominican Republic","Ecuador","Egypt","El Salvador","Equatorial Guinea"
	,"Estonia","Ethiopia","Falkland Islands","Faroe Islands","Fiji","Finland","France","French Polynesia","French West Indies","Gabon","Gambia","Georgia","Germany","Ghana"
	,"Gibraltar","Greece","Greenland","Grenada","Guam","Guatemala","Guernsey","Guinea","Guinea Bissau","Guyana","Haiti","Honduras","Hong Kong","Hungary","Iceland","India"
	,"Indonesia","Iran","Iraq","Ireland","Isle of Man","Israel","Italy","Jamaica","Japan","Jersey","Jordan","Kazakhstan","Kenya","Kuwait","Kyrgyz Republic","Laos","Latvia"
	,"Lebanon","Lesotho","Liberia","Libya","Liechtenstein","Lithuania","Luxembourg","Macau","Macedonia","Madagascar","Malawi","Malaysia","Maldives","Mali","Malta","Mauritania"
	,"Mauritius","Mexico","Moldova","Monaco","Mongolia","Montenegro","Montserrat","Morocco","Mozambique","Namibia","Nepal","Netherlands","Netherlands Antilles","New Caledonia"
	,"New Zealand","Nicaragua","Niger","Nigeria","Norway","Oman","Pakistan","Palestine","Panama","Papua New Guinea","Paraguay","Peru","Philippines","Poland","Portugal"
	,"Puerto Rico","Qatar","Reunion","Romania","Russia","Rwanda","Saint Pierre & Miquelon","Samoa","San Marino","Satellite","Saudi Arabia","Senegal","Serbia","Seychelles"
	,"Sierra Leone","Singapore","Slovakia","Slovenia","South Africa","South Korea","Spain","Sri Lanka","St Kitts & Nevis","St Lucia","St Vincent","St. Lucia","Sudan"
	,"Suriname","Swaziland","Sweden","Switzerland","Syria","Taiwan","Tajikistan","Tanzania","Thailand","Timor L'Este","Togo","Tonga","Trinidad & Tobago","Tunisia"
	,"Turkey","Turkmenistan","Turks & Caicos","Uganda","Ukraine","United Arab Emirates","United Kingdom","United States","United States Minor Outlying Islands","Uruguay"
	,"Uzbekistan","Venezuela","Vietnam","Virgin Islands (US)","Yemen","Zambia","Zimbabwe"];

	constructor(props) {
        super(props);
		this.state = { 
			...props.search
		};
	}

	daysNotExcess(from, to) {
		let fromTime = new Date(from).getTime(); let toTime = new Date(to).getTime();
		if (toTime-fromTime-1 > msInDay*30)
			return false;
		else
			return true;
	}

	checkoutIsLater(from, to) {
		return new Date(from).getTime()+1 < new Date(to).getTime();
	}

	withinTwoYears(date) {
		if (new Date(date).getTime()-Date.now() < 365*2*msInDay)
			return true;
		else
			return false;
	}

	isPast(date) {
		if (new Date(date).getTime() < Date.now())
			return true;
		else
			return false;
	}

	onFromChange = (e) => {
		const value = e.target.value;
		if (!this.withinTwoYears(value)) {
			alert("It is too early for that");
			return;
		}
		if (this.isPast(value)) {
			return;
		}
		if (this.daysNotExcess(value, this.state.to))
			if (this.checkoutIsLater(value, this.state.to))
				this.setState({ from: value });
			else
				this.setState({ from: value, to: new Date(new Date(value).getTime()+1*msInDay).toISOString().slice(0, 10) });
		else {
			this.setState({ from: value, to: new Date(new Date(value).getTime()+1*msInDay).toISOString().slice(0, 10) });
		}
		this.onChange();
	};

	onToChange = (e) => {
		if (this.daysNotExcess(this.state.from, e.target.value))
			if (this.checkoutIsLater(this.state.from, e.target.value)) {
				this.setState({ to: e.target.value });
				this.onChange();
			}
			else
				;
		else {
			alert("Duration of dwelling can not be longer than 30 days");
		}
	};

	onAdultChange = (e) => {
		let value = e.target.value;
		if (value <= 10 && value >= 1) {
			this.setState({ adult: value });
			this.onChange();
		}
	};

	onChildChange = (e) => {
		let value = e.target.value;
		if (value <= 10 && value >= 0 && value){
			this.setState({ child: value });
			this.onChange();
		}
	};

	onCountryChange = (e) => {
		this.setState({ country: e.value });
		this.onChange();
	};

	onLocalityChange = (e) => {
		let value = e.target.value;
		this.setState({ locality: value });
		this.onChange();
	};
	
	onChange = () => {
		if (!this.state.country)
		{
			return;
		}
		if (this.state.locality.search(/^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$/) === -1)
		{
			return;
		}

		this.props.setSearchParameters({
			country: this.state.country,
			locality: this.state.locality,
			from: this.state.from,
			to: this.state.to,
			adult: this.state.adult,
			child: this.state.child
		});

		if (this.timeoutId) clearTimeout(this.timeoutId);
        this.timeoutId = setTimeout(() => this.props.fetchHotels(this.props.search), 2000);
	};

    render() {
        return <Search countries={this.countries}
					 onCountryChange={this.onCountryChange}
					 onLocalityChange={this.onLocalityChange}
					 onFromChange={this.onFromChange}
					 onToChange={this.onToChange}
					 onAdultChange={this.onAdultChange}
					 onChildChange={this.onChildChange}
					 onSubmit={this.onSubmit}
                     {...this.state} />;
    }
}

const mapState = (state) => {
    return { search: state.search };
}

const mapDispatch = dispatch => ({
        fetchHotels: (params) => { dispatch(fetchHotelsAction(params)); },
        setSearchParameters: (params) => { dispatch(setSearchParametersAction(params)); }
    });

export default connect(mapState, mapDispatch)(SearchContainer);