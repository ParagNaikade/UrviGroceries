import React from 'react';
import './App.css';
import './Landing Page/Home/Cart.css'
import Home from './Landing Page/Home/Home.js';
import logo from './Landing Page/Home/Urvilogo.jpg'
import { LoremIpsum } from 'react-lorem-ipsum';


function App() {
  return (
    <div>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"></link>
      <div>
        <img src={logo} class="AppLogo" alt='Urvi Groceries' />
      </div>
      {/* <Home></Home> */}

      <div>
        <div>
          <LoremIpsum p={2} />
        </div>
      </div>




    </div>
  );
}

export default App;
