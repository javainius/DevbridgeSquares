import * as React from 'react';

import { IButtonProps } from 'office-ui-fabric-react/lib/Button';
import { TeachingBubble } from 'office-ui-fabric-react/lib/TeachingBubble';
interface IProps {
  addPoint:(any);
  responseMessage: string;
};
export interface ITeachingBubbleBasicExampleState {
  isTeachingBubbleVisible?: boolean;
  coordinateX?: number;
  coordinateY?: number;
}

export class AddPoint extends React.Component<IProps, ITeachingBubbleBasicExampleState> {
  // private _menuButtonElement: HTMLElement;
  constructor(props: IProps) {
    super(props);
    this._onDismiss = this._onDismiss.bind(this);
    this._onShow = this._onShow.bind(this);

    this.state = {
      isTeachingBubbleVisible: false
    };
  }

  onChangeX = (event: any) => this.setState({ coordinateX: event.target.value});

  onChangeY = (event: any) => this.setState({ coordinateY: event.target.value});

  onSubmit = (e: any) => {
    e.preventDefault();
    this.props.addPoint(this.state);
    this.setState({ coordinateX: undefined, coordinateY: undefined});
}

  public render(): JSX.Element {
    const { isTeachingBubbleVisible } = this.state;
    // const examplePrimaryButton: IButtonProps = {
    //   children: 'Try it out'
    // };
    const exampleSecondaryButtonProps: IButtonProps = {
      children: 'got it',
      onClick: this._onDismiss
    };

    return (
      <form onSubmit={this.onSubmit} className="pointInput">
        <div className="input-group">
          <div className="input-group-prepend">
            <span className="input-group-text" id="inputSpan">X and Y Coordinates</span>
          </div>
            <input
                type="text"
                name="coordinateX"
                style={{ flex: '10', padding: '5px' }}
                placeholder="X Coordinate"
                value={this.state.coordinateX}
                onChange={this.onChangeX}
                className="form-control"
                id="pointInputField"
            />
            <input
                type="text"
                name="coordinateY"
                style={{ flex: '10', padding: '5px' }}
                placeholder="Y Coordinate"
                value={this.state.coordinateY}
                onChange={this.onChangeY}
                className="form-control"
                id="pointInputField"
            />
        </div>
            <input 
                type="submit"
                value="Submit"
                className="btn-dark"
                id="btn-dark"
                onClick={isTeachingBubbleVisible ? this._onDismiss : this._onShow}
            />
            <div className="ms-TeachingBubbleExample" id="responseMessage">
              <span className="ms-TeachingBubbleBasicExample-buttonArea">
              </span>
                {isTeachingBubbleVisible ? (
                  <div>
                    <TeachingBubble 
                      secondaryButtonProps={exampleSecondaryButtonProps}
                      onDismiss={this._onDismiss}
                      headline={this.props.responseMessage}
                    >
                    </TeachingBubble>
                  </div>
                ) : null}
            </div>
      </form>

      
    );
  }

  private _onDismiss(ev: any): void {
    this.setState({
      isTeachingBubbleVisible: false
    });
  }

  private _onShow(ev: any): void {
    this.setState({
      isTeachingBubbleVisible: true
    });
  }
}
