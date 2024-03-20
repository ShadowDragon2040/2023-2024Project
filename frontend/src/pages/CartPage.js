import React, { useState, useEffect } from "react";
import NavigationBar from "../pages/teszt";

const Cart = ({ cart, setCart, handleChange, cartItemCount, cartItems }) => {
  

  return (
    
    <NavigationBar cartItemCount={cartItemCount} cartItems={cartItems}/>
  );
};

export default Cart;