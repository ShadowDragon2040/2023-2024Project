import React, { useState, useEffect } from 'react';
import { FaSearch, FaShoppingBasket } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import { Navbar, Container, Nav, Modal, Button, FormControl, InputGroup } from 'react-bootstrap';
import axios from 'axios';

const NavigationBar = ({ onCategoryClick, setSearchTerm, cartItemCount, cartItems }) => {
  const [categories, setCategories] = useState([]);
  const [searchOpen, setSearchOpen] = useState(false);
  const [modalOpen, setModalOpen] = useState(false);

  const handleOpen = () => {
    setModalOpen(true);
  };

  const handleClose = () => {
    setModalOpen(false);
  };

  const handleQuantityChange = (productId, quantity) => {
    // implementáld a mennyiség változtatás logikáját
  };

  const handleUpdateCart = (productId) => {
    // implementáld a kosár frissítésének logikáját
  };

  return (
    <>
      <Navbar bg="light" expand="lg">
        <Container>
          <Link to="/" className="navbar-brand">
            Logo
          </Link>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
           
            <Nav>
            
              <Button onClick={handleOpen}>
                <FaShoppingBasket />
                <h6 variant="body2">{cartItemCount}</h6>
              </Button>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <Modal show={modalOpen} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Shopping Cart</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {cartItems.map((item) => (
            <div key={item.id}>
              <h6 variant="h6">{item.name}</h6>
              <h6 variant="body1">Price: {item.price} dollars</h6>
              <FormControl
                type="number"
                min="1"
                value={item.quantity}
                onChange={(e) => handleQuantityChange(item.id, e.target.value)}
              />
              <Button variant="primary" onClick={() => handleUpdateCart(item.id)}>
                Update
              </Button>
            </div>
          ))}
          <Link to="/cart">
            <Button variant="primary">
              Checkout
            </Button>
          </Link>
        </Modal.Body>
      </Modal>
    </>
  );
          }

export default NavigationBar;