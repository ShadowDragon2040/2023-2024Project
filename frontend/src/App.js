import './App.css';
import {BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import Home from './pages';
import CompanyInfoPage from './pages/CompanyInfoPage';
import EnderPage from './pages/Ender';
import AnycubicPage from './pages/Anycubic';
import ElektroplatingPage from './pages/ElektroplatingPage';
import PaintPage from './pages/PaintPage';
import ModelltervezesPage from './pages/ModelltervezesPage';
import SingleProductDisplay from './pages/SingleProductDisplay';
import ShopPage from './pages/ShopPage';
import "bootstrap/dist/css/bootstrap.css"
import CategoryPage from './pages/CategoryPage';
import NewsPage from './pages/NewsPage';
import React, { useState } from 'react';
import Cart from './pages/CartPage';

function App() {
  sessionStorage.setItem("bejelenkezve", "false");
  sessionStorage.setItem("role", "PUBLIC");
  const[counter,setCounter]=useState(0)

  const [cartItems, setCartItems] = useState([]);
  const [addedToCart, setAddedToCart] = useState([]);
  const [cartItemCount, setCartItemCount] = useState(0);
 
  const incrementCounter=()=>{
    setCounter(counter+1)
    console.log(counter)
  }
  const addToCart = (product, quantity) => {
    const existingItemIndex = cartItems.findIndex(item => item.id === product.id);
  
    if (existingItemIndex !== -1) {
      const updatedCartItems = [...cartItems];
      updatedCartItems[existingItemIndex].quantity += quantity;
      setCartItems(updatedCartItems);
    } else {
      setCartItems([...cartItems, { ...product, quantity }]);
    }
  
    setAddedToCart([...addedToCart, product.id]);
    // Frissítjük a kosárba helyezett termékek számát
    setCartItemCount(prevCount => prevCount + quantity);
    console.log(`Added to cart: ${product.name}`);
  };

  return (
    <Router>
      <Switch>
        <Route path="/" component={Home} exact />
        <Route path="/CompanyInfoPage" component={CompanyInfoPage} exact />
        <Route path="/Ender" component={EnderPage} exact />
        <Route path="/Anycubic" component={AnycubicPage} exact />
        <Route path="/ElektroplatingPage" component={ElektroplatingPage} exact />
        <Route path="/ModelltervezesPage" component={ModelltervezesPage} exact />
        <Route path="/PaintPage" component={PaintPage} exact />

        <Route path="/ShopPage" exact component={() => <ShopPage incrementCounter={incrementCounter} />}/>
        <Route path="/ShopPage/:ProductId" component={SingleProductDisplay} exact addToCart={addToCart} />
        <Route path="/ShopPage/Categories/:CategoryId" component={CategoryPage} exact />
        <Route path="/News" component={NewsPage} exact />
        <Route path="/CartPage"component={Cart} exact cartItemCount={cartItemCount} cartItems={cartItems} />
      </Switch>
    </Router>
  );
}
export default App;
