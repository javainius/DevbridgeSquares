import React, { Component } from 'react';
import './App.css';
import axios from 'axios'
import { Points } from './components/Points';
import { AddPoint } from './components/AddPoint';
import { initializeIcons } from '@uifabric/icons';

initializeIcons(undefined, { disableWarnings: true });

class App extends Component {
state = {
  points: [],
  responseMessage: ''
}

componentDidMount() {
  axios.get('https://localhost:44368//api/Points/GetPoints')
  .then(res => {
    const points = res.data;
    this.setState({ points });
  })
}

deletePoints= (idList: object) => {
  axios.delete("https://localhost:44368//api/Points/DeletePoints", {data: idList})
  .then(res => {
    const points = res.data;
    this.setState({ points });
  })
}

addListOfPoints = (pointsFile: any) => {
  const data = new FormData();
  data.append('file', pointsFile);
  axios.post("https://localhost:44368//api/Points/UploadFile", data)
    .then(res =>{ 
      this.setState({ points: res.data.CurrentPointList,
         responseMessage: res.data.ResponseMessage })});
  }

addPoint = (point: object) => {

    axios.post('https://localhost:44368//api/Points/PostPoint', point)
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
          <Points deletePoints={this.deletePoints} points={this.state.points}/>
        </div>      
      </div>
    );
  }
}

export default App;

