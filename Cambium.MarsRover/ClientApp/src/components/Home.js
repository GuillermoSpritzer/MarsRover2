import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Mars rover deployment portal</h1>
        <p>Please deploy your Mars Rovers on the following tabs:</p>
        <ul>
          <li>Deploy rovers file</li>
          <li>Deply rover</li>
          </ul>

      </div>
    );
  }
}
