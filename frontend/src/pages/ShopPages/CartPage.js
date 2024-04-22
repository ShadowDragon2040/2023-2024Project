//import React, { useState, useEffect } from "react";
import { Button } from 'react-bootstrap';
import CloseButton from 'react-bootstrap/CloseButton';
import {
  NavBtnLink,
} from '../../components/TextElements';
import { MdArrowBack } from "react-icons/md";
import Footer from '../../components/FooterComponent';


const CartPage = ({ handleClose, cart, setCart }) => {

  console.log(setCart);
  console.log(cart);
  const totalPayment = cart.reduce((acc, item) => acc + item.price * item.quantity, 0);
  return (
    <div style={{ height: '100vh' }}>
      <div className="card">
        <div className="card-header">
          <h5 className="card-title">Cart Items</h5>
        </div>
        <div className="card-body" style={{ maxHeight: '500px', overflowY: 'auto', padding: '10px', maxWidth: '50%' }}>

          {cart.map((item, index) => (
            <div key={item.id} style={{ marginBottom: '10px', border: '1px solid #ccc', padding: '10px' }}>
              <CloseButton onClick={() => setCart(index)} style={{ float: 'right' }} />
              <h5>{item.name}</h5>
              <p>Price: {item.price}</p>
              <p>Quantity: {item.quantity}</p>
              <p>Color: {item.color}</p>
            </div>
          ))}

        </div>
        <div style={{ alignSelf: 'flex-end', marginRight: '10px', marginTop: '-50px', width: '45%' }}>
          <h5>Total Payment: {totalPayment}</h5>
          <div className="card-footer">

            <NavBtnLink to='/ShopPage'><MdArrowBack />Vissza a weboldalra</NavBtnLink>

            <Button variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</Button>
          </div>
        </div>

      </div>
      <Footer isButtom={true} />
    </div>

  );

};

export default CartPage;
