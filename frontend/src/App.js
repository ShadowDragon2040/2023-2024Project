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
import NewsPage from './pages/ShopPages/NewsPage';
import React, { useState, useEffect } from 'react';
import CartPage from './pages/ShopPages/CartPage';
import ProfilePage from './pages/ShopPages/ProfilePage';
import { ToastContainer, collapseToast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  /*sessionStorage.setItem("bejelenkezve", "false");
  sessionStorage.setItem("role", "PUBLIC");*/
  const [cartItems, setCartItems] = useState([]);
  const [addedToCart, setAddedToCart] = useState([]);
  const [cartItemCount, setCartItemCount] = useState(0);
  const [totalQuantity, setTotalQuantity] = useState(0);

  const [collapsed, setCollapsed] = useState(true);

  const handleMouseEnter = () => {
    setCollapsed(false);
};
const handleMouseLeave = () => {
  setCollapsed(true);
};
  useEffect(() => {
    localStorage.setItem("bejelenkezve", "false");
    localStorage.setItem("role", "PUBLIC");
  }, []);
  useEffect(() => {
    //console.log(cartItems)
  }, [cartItems]);

  useEffect(() => {
    let total = 0;
    if (cartItems) {
      cartItems.forEach(item => {
        total += item.quantity;
      });
    }
    setTotalQuantity(total);
  }, [cartItems]);


  const handleRemoveFromCart = (index) => {

    setCartItems(prevList => {
      let newList = [...prevList]; 
      newList.splice(index, 1); 
      
      return newList; 
      
    });
};
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


  setCartItemCount(cartItems.length + 1); 
  console.log("Added to cart: " + product.name);

  if(cartItems.length !== 0){
    let kosarString = cartItems.reduce((acc, item) => {
      return acc + `${item.id} ${item.quantity} ${item.color};`;
    }, "");
    localStorage.setItem("kosar", kosarString);
  }



}; 
  return (
  <>
  <ToastContainer 
  position='bottom-right'
  />
    <Router>
      <Routes>
        <Route path="/" element={<Home/>} exact />
        <Route path="/CompanyInfoPage" element={<CompanyInfoPage/>} exact/>
        <Route path="/Ender" element={<EnderPage/>} exact/>
        <Route path="/Anycubic" element={<AnycubicPage/>} exact/>
        <Route path="/Bambu" element={<BambuPage/>} exact/>
        <Route path="/ElegooSaturn" element={<ElegooSaturnPage/>} exact/>
        <Route path="/ElektroplatingPage" element={<ElektroplatingPage/>} exact/>
        <Route path="/ModelltervezesPage" element={<ModelltervezesPage/>} exact/>
        <Route path="/PaintPage" element={<PaintPage/>} exact />
        <Route path="/ProfilePage" element={<ProfilePage/>} exact />
        <Route path="/ShopPage" exact element={<ShopPage collapsed={collapsed} handleMouseEnter={handleMouseEnter} handleMouseLeave={handleMouseLeave} cartItemCount={totalQuantity}/>}/>
        <Route path="/ShopPage/:ProductId" element={ <SingleProductDisplay addToCart={addToCart} cart={cartItems} cartItemCount={totalQuantity} />}/>
        <Route path="/ShopPage/Categories/:CategoryId" element={<CategoryPage/>} exact />
        <Route path="/ShopPage/News" element={<NewsPage collapsed={collapsed} handleMouseEnter={handleMouseEnter} handleMouseLeave={handleMouseLeave}/>} exact/>
        <Route path="/ShopPage/CartPage"element={<CartPage cart={cartItems} cartItemCount={cartItemCount} setCart={handleRemoveFromCart} />} exact/>
      </Routes>
    </Router>
    </>
  );
}
export default App;
