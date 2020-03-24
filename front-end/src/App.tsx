import React, { Component } from 'react';
import './App.css';
import axios from 'axios'
import { Points } from './components/Points';
import { AddPoint } from './components/AddPoint';
import { initializeIcons } from '@uifabric/icons';

initializeIcons(undefined, { disableWarnings: true });

interface IDetailsListItem {
  key: number;
  name: string;
  X: number;
  Y: number;
}

class App extends Component {
state = {
  points: [],
  responseMessage: ''
}

componentDidMount() {
  axios.get('https://localhost:44323/Points')
  .then(res => {
    const points = res.data;
    this.setState({ points });
  })
}

deletePoint= (id: number) => {
  axios.delete("https://localhost:44323/Points", {
    headers: {
      'Content-Type': 'application/json'
    },
    data: id})
  .then(res => {
    const points = res.data;
    this.setState({ points });
  })
}

addListOfPoints = (pointsFile: any) => {
  const data = new FormData();
  data.append('file', pointsFile);
  axios.post("https://localhost:44323/Points", data)
    .then(res =>{ 
      this.setState({ points: res.data.CurrentPointList,
         responseMessage: res.data.ResponseMessage })});
  }

addPoint = (point: object) => {

    axios.post('https://localhost:44323/Points', point)
    .then(res =>{ 
      this.setState({ points: res.data.CurrentPointList,
         responseMessage: res.data.AddingState })});
  }

  render() {
    return (
      <div className="App">
        <h1 className="title">List of points</h1>
        <AddPoint addPoint={this.addPoint} responseMessage={this.state.responseMessage}/>
        <div className="listOfPoints">
          <Points deletePoint={this.deletePoint} points={this.state.points}/>
        </div>      
      </div>
    );
  }
}

export default App;

