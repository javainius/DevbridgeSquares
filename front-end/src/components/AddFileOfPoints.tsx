import * as React from 'react';
import axios from 'axios';

interface IProps{
    addListOfPoints:(any);
}

interface IState{
    file: any;
}
export class AddFileOfPoints extends React.Component<IProps, IState> {
    constructor(props: IProps) {
        super(props);
        
        this.state = {
          file: null
        };
    }
    
    //   async submit(e: any) {
    //     e.preventDefault();
    
    //     // const url = `http://target-url/api/${this.state.id}`;
    //     const formData = new FormData();
    //     formData.append('body', this.state.file);
    //     const config = {
    //       headers: {
    //       },
    //     };
    //     return post(url, formData, config);
    //   }
      
    // addListOfPoints = () => {
    // const data = new FormData() 
    // data.append('file', this.state.file)
    // axios.post("https://localhost:44368//api/values/UploadFile", data, { // receive two parameter endpoint url ,form data 
    //   })
    //   .then(res => { // then print response status
    //     console.log(res.statusText)
    //   })
    // }

    onClickHandler=()=>{
        this.props.addListOfPoints(this.state.file)
    }

    setFile(e: any) {
    this.setState({ file: e.target.files[0] });
    }
    
      render() {
        return (
            <div>
                <h1>File Upload</h1>
                <input  type="file"
                        onChange={e => this.setFile(e)}
                        accept=".txt" />
                <button type="button" 
                    style={{width: "10%", margin: "auto"}}
                    className="btn btn-dark btn-block" 
                    onClick={this.onClickHandler}>Upload
                </button>
            </div>
            
        );
      }
}





{/* <form onSubmit={e => this.submit(e)}>
<h1>File Upload</h1>
<input type="file" onChange={e => this.setFile(e)} />
<button type="submit">Upload</button>
</form> */}





//  // private _menuButtonElement: HTMLElement;


//  onSubmit = (e: any) => {
//     e.preventDefault();
//     // this.props.addPoint(this.state);
//     this.setState({ coordinateX: undefined, coordinateY: undefined});
// }

// onChange = (event: any) => {
//     var file=event.target.file;

//     var reader = new FileReader();
//     var fileText;
//     reader.addEventListener("load", function () {
//         fileText = reader.result;
//     }, false);
    
//     // reader.readAsText(file);

//     console.log(fileText)
// }

//   public render(): JSX.Element {
//     return(
//         <form onSubmit={this.onSubmit} style={{display: 'flex'}}>
//             <input
//                 type="file"
//                 name="ListOfPoints"
//                 style={{ flex: '10', padding: '5px' }}
//                 accept=".txt"
//                 onChange={this.onChange}
//             />
//         </form>      
//     );
//   }
