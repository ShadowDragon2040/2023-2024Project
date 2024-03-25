import React, { useEffect, useState } from 'react';
import { animateScroll as scroll } from 'react-scroll';
import SearchBar from '../SeachBar';
import { CgProfile } from 'react-icons/cg';
import { Nav2, NavLogo, NavBtn2, NavBtnLink, ModalButton } from '../TextElements';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function ShopNavbar(props) {
  const [scrollNav, setScrollNav] = useState(false);
  const [show, setShow] = useState(false);
  const [totalQuantity, setTotalQuantity] = useState(0);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleLogout = () => {
    sessionStorage.setItem("bejelenkezve", "false");
    handleClose();
  };

  const changeNav = () => {
    if (window.scrollY >= 80) {
      setScrollNav(true);
    } else {
      setScrollNav(false);
    }
  };

  useEffect(() => {
    window.addEventListener('scroll', changeNav);
  }, []);

  useEffect(() => {

    let total = 0;
    props.cart.forEach(item => {
      total += item.quantity;
    });
    setTotalQuantity(total);
  }, [props.cart]);

  const toggleHome = () => {
    scroll.scrollToTop();
  };

  return (
    <>
      <Nav2 scrollNav={scrollNav}>
        <NavLogo to='/' onClick={toggleHome}>
          PrintFusion
        </NavLogo>

        <NavBtn2>
          <SearchBar />
        </NavBtn2>

        <div>
          <NavBtn2>
            <NavBtnLink to='/ProfilePage'>
              <CgProfile /> Profile
            </NavBtnLink>
          </NavBtn2>

          <NavBtn2>
            <ModalButton onClick={handleShow}>Cart <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart" viewBox="0 0 16 16">
              <path d="M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5.5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5M3.102 4l1.313 7h8.17l1.313-7zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4m7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4m-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2m7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2" />
            </svg> {totalQuantity > 0 && `${totalQuantity}`}</ModalButton>
          </NavBtn2>

          <NavBtn2>
            <ModalButton onClick={handleLogout}>Logout</ModalButton>
          </NavBtn2>
        </div>

        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Cart Items</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {props.cart.map(item => (
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
            <NavBtnLink to='/CartPage'>Go to Cart Page</NavBtnLink>
          </Modal.Footer>
        </Modal>
      </Nav2>
    </>
  );
}

export default ShopNavbar;