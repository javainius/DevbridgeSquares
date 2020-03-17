import * as React from 'react';
import { Announced } from 'office-ui-fabric-react/lib/Announced';
import { TextField } from 'office-ui-fabric-react/lib/TextField';
import { DetailsList, DetailsListLayoutMode, Selection, IColumn } from 'office-ui-fabric-react/lib/DetailsList';
import { MarqueeSelection } from 'office-ui-fabric-react/lib/MarqueeSelection';
import { Fabric } from 'office-ui-fabric-react/lib/Fabric';
import { mergeStyles } from 'office-ui-fabric-react/lib/Styling';

const exampleChildClass = mergeStyles({
  display: 'block',
  marginBottom: '10px'
});

export interface IDetailsListItem {
  key: number;
  name: string;
  X: number;
  Y: number;
}

export interface IDetailsList{
  items: IDetailsListItem[];
  selectionDetails: string;
}

interface IPoint {
  Id: number;
  CoordinateX: number;
  CoordinateY: number;
}
  
interface IPointsProps {
  deletePoints:(any);
  points: IPoint[];
}

export class Points extends React.Component<IPointsProps, IDetailsList> {
  private _selection: Selection;
  private _allItems: IDetailsListItem[];
  private _columns: IColumn[];

  constructor(props: IPointsProps) {
    super(props);

    this._selection = new Selection({
      onSelectionChanged: () => this.setState({ selectionDetails: this._getSelectionDetails() })
    });

    this._allItems = [];

    this._columns = [
      { key: 'column1', name: 'Name', fieldName: 'name', minWidth: 100, maxWidth: 200, isResizable: true },
      { key: 'column2', name: 'X', fieldName: 'X', minWidth: 100, maxWidth: 200, isResizable: true },
      { key: 'column3', name: 'Y', fieldName: 'Y', minWidth: 100, maxWidth: 200, isResizable: true }
    ];

    this.state = {
      items: this._allItems,
      selectionDetails: this._getSelectionDetails()
    };
  }
	updateState = () => {
    for (let i = 0; i < this.props.points.length; i++){
        this._allItems.pop();
    }
    for (let i = 0; i < this.props.points.length; i++){
        this._allItems.push({
        key: this.props.points[i].Id,
        name: 'Point ' + i,
        X: this.props.points[i].CoordinateX,
        Y: this.props.points[i].CoordinateY
        });
    }
  }
  
  public render(): JSX.Element {
    this.updateState();
    const { items, selectionDetails } = this.state;
    return (
      <Fabric>
        <div className={exampleChildClass}>{selectionDetails}</div>
        <button id="deleteButton" onClick={this.deletePointsOnClick}>Delete selected</button>
        <Announced message={selectionDetails} />
        <TextField
          className={exampleChildClass}
          label="Filter by name:"
          onChange={this._onFilter}
          styles={{ root: { maxWidth: '300px' } }}
        />
        <Announced message={`Number of items after filter applied: ${items.length}.`} />
        <MarqueeSelection selection={this._selection}>
          <DetailsList
            items={items}
            columns={this._columns}
            setKey="set"
            layoutMode={DetailsListLayoutMode.justified}
            selection={this._selection}
            selectionPreservedOnEmptyClick={true}
            ariaLabelForSelectionColumn="Toggle selection"
            ariaLabelForSelectAllCheckbox="Toggle selection for all items"
            checkButtonAriaLabel="Row checkbox"
          />
        </MarqueeSelection>
      </Fabric>
    );
  }

  private _getSelectionDetails(): string {
    const selectionCount = this._selection.getSelectedCount();

    switch (selectionCount) {
      case 0:
        return 'No items selected';
      case 1:
        return '1 item selected: ' + (this._selection.getSelection()[0] as IDetailsListItem).name;
      default:
        return `${selectionCount} items selected`;
    }
  }

  private _onFilter = (event: React.FormEvent<HTMLInputElement | HTMLTextAreaElement>, text?: string): void => {
    this.setState({
      items: text ? this._allItems.filter(i => i.name.toLowerCase().indexOf(text) > -1) : this._allItems
    });
  };

  private deletePointsOnClick=()=>{
    let selectedItems = this._selection.getSelection();
    this.props.deletePoints(selectedItems.map(item => item.key));
    this._selection.setAllSelected(false);
  }
}
