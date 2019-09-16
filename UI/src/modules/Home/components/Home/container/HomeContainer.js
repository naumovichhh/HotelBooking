import React from 'react';
import Home from '../component/Home';

const msInDay = 24*3600*1000;

class HomeContainer extends React.Component {
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
		this.selectRef = React.createRef();
		this.localityRef = React.createRef();
		this.state = { from: new Date(Date.now() + 1*msInDay).toISOString().slice(0, 10), to: new Date(Date.now() + 2*msInDay).toISOString().slice(0, 10) };
	}

	daysNotExcess(from, to) {
		let fromTime = new Date(from).getTime(); let toTime = new Date(to).getTime();
		if (toTime-fromTime-1 > msInDay*30)
			return false;
		else
			return true;
	}

	checkoutLater(from, to) {
		return new Date(from).getTime()+1 < new Date(to).getTime();
	}

	onFromChange = (e) => {
		if (this.daysNotExcess(e.target.value, this.state.to))
			if (this.checkoutLater(e.target.value, this.state.to))
				this.setState({ from: e.target.value });
			else
				this.setState({ from: e.target.value, to: new Date(new Date(e.target.value).getTime()+1*msInDay).toISOString().slice(0, 10) });
		else {
			this.setState({ from: e.target.value, to: new Date(new Date(e.target.value).getTime()+1*msInDay).toISOString().slice(0, 10) });
		}
	};

	onToChange = (e) => {
		if (this.daysNotExcess(this.state.from, e.target.value))
			if (this.checkoutLater(this.state.from, e.target.value))
				this.setState({ to: e.target.value });
			else
				this.setState({ from: new Date(new Date(e.target.value).getTime()-1*msInDay).toISOString().slice(0, 10), to: e.target.value });
		else {
			alert("Duration of dwelling can not be longer than 30 days");
		}
	}
	
	onSubmit = (e) => {
		if (!this.countries.includes(this.selectRef.current.state.value.value))
			return;
		if (this.localityRef.current.value.search(/^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$/) === -1)
			return;
		this.props.history.push(`/catalog?country=${this.selectRef.current.state.value.value}`);
	}

    render() {
        return <Home countries={this.countries}
					 onCountryChange={this.onCountryChange}
					 selectRef={this.selectRef}
					 localityRef={this.localityRef}
					 from={this.state.from}
					 to={this.state.to}
					 onFromChange={this.onFromChange}
					 onToChange={this.onToChange}
					 onSubmit={this.onSubmit}
                     {...this.state} />;
    }
}

export default HomeContainer;