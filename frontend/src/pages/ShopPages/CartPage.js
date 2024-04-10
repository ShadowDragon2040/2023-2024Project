import React, { useState, useEffect } from "react";
import NavigationBar from "../teszt";
import { Modal, Button } from 'react-bootstrap'; 

const CartPage = ({ show, handleClose, cart }) => {
  /*
  <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Cart Items</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              {
                !props.cart ? (
                  <div>Nincs semmi</div>
                ) : (
                  <div>
                    {props.cart.map(item => (
                      <div key={item.id}>
                        <h5>{item.name}</h5>
                        <p>Price: {item.price}</p>
                        <p>Quantity: {item.quantity}</p>
                        <p>Color: {item.color}</p>
                      </div>
                    ))}
                  </div>
                )
              }
            </Modal.Body>
            <Modal.Footer>
              <Button variant="secondary" onClick={handleClose}>Close</Button>
              <NavBtnLink to='/CartPage'>Go to Cart Page</NavBtnLink>
            </Modal.Footer>
          </Modal>
          */
  return (
    <div>
      
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Cart Items</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {cart.map(item => (
            <div key={item.id}>
              <h5>{item.name}</h5>
              <p>Price: {item.price}</p>
              <p>Quantity: {item.quantity}</p>
              <p>Color: {item.color}</p>
            </div>
          ))}
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>Close</Button>
          {/* A NavBtnLink helyett itt egy egyszerű gomb található */}
          <Button variant="primary" onClick={() => console.log('Go to Cart Page')}>Go to Cart Page</Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default CartPage;