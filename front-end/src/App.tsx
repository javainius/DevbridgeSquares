import React, { Component } from 'react';
import './App.css';
import axios from 'axios'
import { Points } from './components/Points';
import { AddPoint } from './components/AddPoint';
import { AddFileOfPoints } from './components/AddFileOfPoints'

class App extends Component {
state = {
  points: [],
  responseMessage: ''
}

componentDidMount() {
  axios.get('https://localhost:44368//api/values/GetPoints')
  .then(res => {
    const points = res.data;
    this.setState({ points });
  })
}

addListOfPoints = (pointsFile: any) => {
  const data = new FormData();
  data.append('file', pointsFile);
  axios.post("https://localhost:44368//api/values/UploadFile", data)
    .then(res =>{ 
      this.setState({ points: res.data.CurrentPointList,
         responseMessage: res.data.ResponseMessage })});
  }

addPoint = (point: object) => {

    axios.post('https://localhost:44368//api/values/PostPoint', point)
    .then(res =>{ 
      this.setState({ points: res.data.CurrentPointList,
         responseMessage: res.data.AddingState })});
  }

  render() {
    return (
      <div className="App">
        <h1>List of points</h1>
        <AddPoint addPoint={this.addPoint} responseMessage={this.state.responseMessage}/>
        <AddFileOfPoints addListOfPoints={this.addListOfPoints}/>
        <div className="listOfPoints">
          <Points points={this.state.points}/>
        </div>      
      </div>
    );
  }
}

export default App;

