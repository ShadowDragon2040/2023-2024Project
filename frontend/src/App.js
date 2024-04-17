import './App.css';
import "bootstrap/dist/css/bootstrap.css"
import {BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import Home from './pages';
import CompanyInfoPage from './pages/MainPages/CompanyInfoPage';
import EnderPage from './pages/MainPages/EnderPage';
import BambuPage from './pages/MainPages/BambuPage';
import AnycubicPage from './pages/MainPages/AnycubicPage';
import ElegooSaturnPage from './pages/MainPages/ElegooSaturnPage';
import ElektroplatingPage from './pages/MainPages/ElektroplatingPage';
import PaintPage from './pages/MainPages/PaintPage';
import ModelltervezesPage from './pages/MainPages/ModelltervezesPage';
import SingleProductDisplay from './pages/ShopPages/SingleProductDisplay';
import ShopPage from './pages/ShopPages/ShopPage';
import CategoryPage from './pages/ShopPages/CategoryPage';
import NewsPage from './pages/MainPages/NewsPage';
import React, { useState, useEffect } from 'react';
import CartPage from './pages/ShopPages/CartPage';
import ProfilePage from './pages/ShopPages/ProfilePage';

function App() {
  sessionStorage.setItem("bejelenkezve", "false");
  sessionStorage.setItem("role", "PUBLIC");
  const[counter,setCounter]=useState(0)

  const [cartItems, setCartItems] = useState([]);
  const [addedToCart, setAddedToCart] = useState([]);
  const [cartItemCount, setCartItemCount] = useState(0);
 
  useEffect(() => {
    //console.log(cartItems)
  }, [cartItems]);

  const incrementCounter=()=>{
    setCounter(counter+1)
    console.log(counter)
  }
  /*const handleRemoveFromCart = (itemId) => {
    const updatedCart = cart.filter(item => item.id !== itemId);
    setCart(updatedCart);
};*/
const addToCart = (product, quantity) => {
  let existingItemIndex = -1;

  for(let i = 0; i<cartItems.length;i++){
    if(cartItems[i].id === product.id && cartItems[i].color === product.color){
      existingItemIndex = i;
      break;
    }
  }

  if (existingItemIndex !== -1) {
    const updatedCartItems = [...cartItems];
    updatedCartItems[existingItemIndex].quantity += quantity;
    setCartItems(updatedCartItems);
  } else {
    setCartItems(prevCart => [...prevCart, product]);
  }

  setAddedToCart([...addedToCart, product.id]);

  setCartItemCount(prevCount => cartItems.length);
  console.log("Added to cart: " + product.name);

  if(cartItems.length != 0){
    let kosarString = "";
    cartItems.map(item =>{
      kosarString+= item.id +" "+ item.quantity+" "+item.color+";";

    })
    localStorage.setItem("kosar", kosarString);
  }
}; 
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home/>} exact />
        <Route path="/CompanyInfoPage" element={<CompanyInfoPage/>} exact />
        <Route path="/Ender" element={<EnderPage/>} exact />
        <Route path="/Anycubic" element={<AnycubicPage/>} exact />
        <Route path="/Bambu" element={<BambuPage/>} exact />
        <Route path="/ElegooSaturn" element={<ElegooSaturnPage/>} exact />
        <Route path="/ElektroplatingPage" element={<ElektroplatingPage/>} exact />
        <Route path="/ModelltervezesPage" element={<ModelltervezesPage/>} exact />
        <Route path="/PaintPage" element={<PaintPage/>} exact />
        <Route path="/ProfilePage" element={<ProfilePage/>} exact />
        
        <Route path="/ShopPage" exact element={ <ShopPage incrementCounter={incrementCounter} />}/>
        <Route path="/ShopPage/:ProductId" element={ <SingleProductDisplay addToCart={addToCart} cart={cartItems} />}/>
        <Route path="/ShopPage/Categories/:CategoryId" element={<CategoryPage/>} exact />
        <Route path="/News" element={<NewsPage/>} exact />
        <Route path="/CartPage"element={<CartPage cart={cartItems} cartItemCount={cartItemCount}/>} exact  />
       
        
      </Routes>
    </Router>
  );
}
export default App;
