import * as React from 'react';
import { mergeStyles } from 'office-ui-fabric-react/lib/Styling';
import { Table } from 'react-bootstrap';
import { PointItem } from './PointItem'


const exampleChildClass = mergeStyles({
  display: 'block',
  marginBottom: '10px'
});

export interface IPoint {
  key: number;
  name: string;
  X: number;
  Y: number;
}

export interface IPointItem {
  Id: number;
  CoordinateX: number;
  CoordinateY: number;
}
  
interface IPointsProps {
  deletePoint:(any);
  points: IPointItem[];
}

interface IPointsState {
  points: IPointItem[]
}

export class Points extends React.Component<IPointsProps, IPointsState> {

  constructor(props: IPointsProps) {
    super(props);
  }

  public componentDidUpdate(){
  }

  getHeadStyle = () => {
    return {
      width: '30%'
    }
}
  
  public render() {
    return (
      <Table style={{marginTop: '20px'}} striped bordered hover variant="dark">
        <thead>
          <tr>
            <th style={this.getHeadStyle()}>X</th>
            <th style={this.getHeadStyle()}>Y</th>
            <th style={this.getHeadStyle()}></th>
          </tr>
        </thead>
        <tbody>
          {this.props.points.map(point => <PointItem point={point} 
          deletePoint={this.props.deletePoint}
          key={point.Id}></PointItem>)}
        </tbody>
      </Table>
    );
  }

  

  // private deletePointsOnClick=()=>{
  //   let selectedItems = this._selection.getSelection();
  //   this.props.deletePoints(selectedItems.map(item => item.key));
  //   this._selection.setAllSelected(false);
  // }
}
