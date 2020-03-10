import React from 'react';

interface IProp {
    message: string
}

class PointAddingMessage extends React.Component<IProp> {  
    render(){
        return(
            <div className="alert alert-dismissible" id="alert" role="alert">
            {this.props.message}
            </div>
        )
    }
}

export default PointAddingMessage;
