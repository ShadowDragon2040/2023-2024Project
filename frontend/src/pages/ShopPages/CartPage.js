//import React, { useState, useEffect } from "react";
import { Button } from 'react-bootstrap';
import CloseButton from 'react-bootstrap/CloseButton';
import {
  NavBtnLink,
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';


const CartPage = ({ handleClose, cart, setCart }) => {
  const handleRemoveFromCart = (termekId) => {
    const updatedCart = cart.filter(item => item.id !== termekId);
    setCart(updatedCart);
  };

  console.log(cart);

  return (
    <div>
      <div className="card">
        <div className="card-header">
          <h5 className="card-title">Cart Items</h5>
        </div>
        <div className="card-body" style={{ maxHeight: '300px', overflowY: 'auto', padding: '10px', maxWidth: '50%' }}>  
        
          {cart.map(item => (
            <div key={item.id} style={{ marginBottom: '10px', border: '1px solid #ccc', padding: '10px' }}>   <CloseButton onClick={() => handleRemoveFromCart(item.id)} style={{ float: 'right' }}/>
              <h5>{item.name}</h5>
              <p>Price: {item.price}</p>
              <p>Quantity: {item.quantity}</p>
              <p>Color: {item.color}</p>
            </div>
          ))}
            <h5>Total Price: {cart.reduce((acc, item) => acc + item.price * item.quantity, 0)}</h5>
        </div>
     
        <div className="card-footer">
        <NavBtnLink to='/ShopPage'><MdArrowBack/>Vissza a weboldalra</NavBtnLink>
          <br></br>
          <br></br>
          <Button variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</Button>
        </div>
      </div>
    </div>
   
  );
 
};
<Footer />
export default CartPage;
