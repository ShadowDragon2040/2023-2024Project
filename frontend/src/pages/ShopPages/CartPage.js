import React, { useState, useEffect } from "react";
import NavigationBar from "../teszt";
import { Button } from 'react-bootstrap'; // Modal eltávolítva
      
      const CartPage = ({ handleClose, cart }) => {
        // Modal state és handler eltávolítva
      
        // handleClose funkció változatlanul használható
      
        console.log(cart);
      
        return (
          <div>
            <div className="card">
              <div className="card-header">
                <h5 className="card-title">Cart Items</h5>
              </div>
              <div className="card-body">
                {cart.map(item => (
                  <div key={item.id}>
                    <h5>{item.name}</h5>
                    <p>Price: {item.price}</p>
                    <p>Quantity: {item.quantity}</p>
                    <p>Color: {item.color}</p>
                  </div>
                ))}
              </div>
              <div className="card-footer">
                <Button variant="secondary" onClick={handleClose}>Close</Button>
                <Button variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</Button>
              </div>
            </div>
          </div>
        );
      };
      
      export default CartPage;
      