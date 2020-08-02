import React from 'react';
import Menubar from './Menubar.js';
import SocialMedia from './Social Media.js';
import Cart from './Cart.js';

function Home() {
  return (
    <div>
      <header>
        <p>
          <h3>This is the Home page.</h3>      
          
          <Menubar></Menubar>
          <SocialMedia></SocialMedia>
          <Cart></Cart>
        
        </p>
      </header>
    </div>
  );
}

export default Home;
