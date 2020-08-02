import React from 'react';
import './App.css';
import './Landing Page/Home/Cart.css'
import Home from './Landing Page/Home/Home.js';
import Bag from './Landing Page/Home/ShoppingBag.jpg';

function App() {
  return (
    <html>
    <div>
      <header>
        <h1>Urvi Groceries</h1>
        <img class='GetCart' src={Bag} alt='ShopNow!'></img>
        <Home></Home>
       
        <p>
          <h3>This is the landing page.</h3>
        </p>
      </header>
    </div>
    <span class='PhotoCredits'>Background Image by <a href="https://unsplash.com/@danaragonmx?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Dan Aragón</a> on <a href="https://unsplash.com/?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Unsplash</a></span>
    <span class='PhotoCredits'>Cart Photo by <a href="https://unsplash.com/@ciabattespugnose?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Lucrezia Carnelos</a> on <a href="https://unsplash.com/s/photos/shopping-bag?utm_source=unsplash&amp;utm_medium=referral&amp;utm_content=creditCopyText">Unsplash</a></span>
    </html>
  );
}

export default App;
