import * as React from 'react';
import { IPointItem } from './Points'

interface IPointProps {
  point: IPointItem
  deletePoint:(any);
}

interface IPointState {
  point: IPointItem
}

export class PointItem extends React.Component<IPointProps, IPointState> {

deleteOnClick = () =>{
  this.props.deletePoint(this.props.point.Id);
}
  render(){
    return(
      <tr>
        <td style={{verticalAlign: 'middle'}}>{this.props.point.CoordinateX}</td>
        <td style={{verticalAlign: 'middle'}}>{this.props.point.CoordinateY}</td>
        <td><button id="deleteButton" onClick={this.deleteOnClick}>Delete</button></td>
      </tr>
    );
  }
}