import React from 'react';

interface IPoint {
    id: number;
    coordinateX: number;
    coordinateY: number;
  };
  function getStyle() {
    return {
        background: '#f4f4f4',
        padding: '10px',
        borderBottom: '1px #ccc dotted'
    }
}

function getdivStyle() {
  return {
      display: 'Inline-block',
      margin: '0px 20px'
  }
}

class PointItem extends React.Component<IPoint> {
    render(){
      return( 
          <div style = {getStyle()}>
            <div style = {getdivStyle()}>
              id: {this.props.id} 
            </div>
               <div style = {getdivStyle()}>
                 X: {this.props.coordinateX}
               </div>
               <div style = {getdivStyle()}>
                 Y: {this.props.coordinateY}
               </div>
              
          </div>
      );
    }
  }

const btnStyle = {
    background: "rgb(147, 28, 28)",
    color: '#fff',
    border: 'none',
    padding: '5px 9px',
    borderRadius: '50%',
    cursor: 'pointer',
    float: 'right'
}

export default PointItem
