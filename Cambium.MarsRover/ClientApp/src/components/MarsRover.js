import React, { Component } from 'react';
import axios from 'axios';
//import {  TextInput} from 'react-native';

export class MarsRover extends React.Component {

  constructor(props) {
    super(props);
    //const [text, setText] = useState('');

    this.state = {
      message: null,
      PlateauHeight: null,
      PlateauWidth: null,
      Instructions: null
    }
  
  }

  PostMarsRoverInstructions = () => {
    const { Instructions } = this.state;

    const instructions = JSON.stringify({  PlateauWidth: Number(this.state.PlateauWidth),PlateauHeight: Number(this.state.PlateauHeight), Instructions: this.state.Instructions});
    axios.post("Navigation",instructions , 
    { headers: { 'Content-Type': 'application/json' },})
    .then(response => this.setState({message: response.data}));

  };  

  handleChange = (e) => {
    console.log(e.target.value);
    this.setState({ Instructions: e.target.value });
  };

  handleChangeInt = (e) => {
    const name= e.target.name;
    this.setState({ [name]: e.target.value });
  };


  render() 
  {
    const { message } = this.state;

    return (

      <div>
        <h1>MarsRover</h1>

        <div >
        Enter plateu Dimensions 
        Height  <input type="number" id="width" name="PlateauHeight" min="1" max="100" class = "foo" 
        value={this.state.PlateauHeight} onChange= {this.handleChangeInt} />
        Width  <input type="number" id="width" name="PlateauWidth" min="1" max="100" class = "foo"
         value={this.state.PlateauWidth} onChange= {this.handleChangeInt}/>
        </div>
        <br/>
        <div>
        Enter instructions for new mars Rover <input type="text" value={this.state.Instructions} onChange= {this.handleChange} />
        </div>
        <br/>
        <br/>
        <button className="btn btn-primary" onClick={this.PostMarsRoverInstructions}>Deploy Rover</button>
        <br/>
        <br/>
        Message from rover: { message}
      </div>
    );
  }
}
