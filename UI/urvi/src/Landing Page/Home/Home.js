import React from 'react';
import Menubar from './Menubar.js';
import ContactUs from '../Contact Us/ContactUs'
import OurProducts from '../Our Products/OurProducts'

function Home() {
  return (
    <div>
      <div class="jumbotron">
        <h1 class="display-4">Urvi Groceries!</h1>
        <p class="lead">Welcome to Urvi, where even little of your contribution makes your grocery shopping a simpler, wasteless event..</p>
        <hr class="my-4" />
        <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>
        <p class="lead">
          <a class="btn btn-primary btn-lg" href=".\OurProducts" role="button" alt="Our Products!">Learn more</a>
        </p>
      </div>

      <Menubar /> 

      {/* <ContactUs/> */}

      {/* <OurProducts /> */}

    </div>
  );
}

export default Home;
