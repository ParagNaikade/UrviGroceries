import React from 'react';
import './Menubar.css';

function Menubar() {
  return (
    <div className='navbar-position'>
      
      <nav class="navbar navbar-light bg-light navbar-expand-lg fixed-top">
        <a href=".\Home" class="navbar-brand">Urvi Groceries</a>
        <button class="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
          <ul class="navbar-nav ml-auto">
            <li class="navbar-item">
              <a href=".\Home" class="nav-link">Home</a>
            </li>
            <li class="navbar-item">
              <a href=".\AboutUs" class="nav-link">About Us</a>
            </li>
            <li class="navbar-item">
              <a href=".\OurProducts" class="nav-link">Our Products</a>
            </li>
            <li class="navbar-item">
              <a href=".\ContactUs" class="nav-link">Contact Us</a>
            </li>
          </ul>
        </div>
        <svg width="2em" height="2em" viewBox="0 0 16 16" class="bi bi-cart3" fill="green" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .49.598l-1 5a.5.5 0 0 1-.465.401l-9.397.472L4.415 11H13a.5.5 0 0 1 0 1H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l.84 4.479 9.144-.459L13.89 4H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm7 0a1 1 0 1 0 0 2 1 1 0 0 0 0-2z" />
        </svg>
      </nav>
      
    </div>
  );
}

export default Menubar;