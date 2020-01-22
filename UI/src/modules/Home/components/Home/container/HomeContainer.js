import React from 'react';
import Home from '../component/Home';
import { connect } from 'react-redux';
import setSearchParameters from 'modules/Search/actions';
import localities from 'common/data/localities.min.json';

const msInDay = 24*3600*1000;

class HomeContainer extends React.Component {
	constructor(props) {
		super(props);
		if (props.search.country) {
			this.state = {
				...props.search
			}
		} else {
			this.state = { 
				country: '',
				locality: '',
				from: new Date(Date.now() + 1*msInDay).toISOString().slice(0, 10),
				to: new Date(Date.now() + 2*msInDay).toISOString().slice(0, 10),
				adult: 1,
				child: 0
			};
		}
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
	};

	onToChange = (e) => {
		if (this.daysNotExcess(this.state.from, e.target.value))
			if (this.checkoutIsLater(this.state.from, e.target.value))
				this.setState({ to: e.target.value });
			else
				;
		else {
			alert("Duration of dwelling can not be longer than 30 days");
		}
	};

	onAdultChange = (e) => {
		let value = e.target.value;
		if (value <= 10 && value >= 1)
			this.setState({ adult: value });
	};

	onChildChange = (e) => {
		let value = e.target.value;
		if (value <= 10 && value >= 0 && value)
			this.setState({ child: value });
	};

	onCountryChange = (e) => {
		this.setState({ country: e.value });
	};

	onLocalityChange = (e) => {
		this.setState({ locality: e.value });
	};
	
	onSubmit = (e) => {
		if (!this.state.country)
		{
			alert("Choose country");
			return;
		}
		if (!this.state.locality)
		{
			alert("Enter locality");
			return;
		}
		if (this.state.locality.search(/^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$/) === -1)
		{
			alert("Enter valid locality");
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
		this.props.history.push('/catalog');
	};

    render() {
		return <Home
					 localities={localities}
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

const mapState = state => {
	return { search: state.search };
};

const mapDispatch = {
	setSearchParameters
};

export default connect(mapState, mapDispatch)(HomeContainer);