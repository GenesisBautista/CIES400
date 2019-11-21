import React, { Component } from 'react';


class textBox extends Component {
  constructor(props){
    super(props);
    this.id = props.id;
  }

  render() {
    return (
      <div>
        <label id={this.id}></label>
        <input type="text" id={this.id}>

        </input>
      </div>
    );
  }
}

export default textBox;