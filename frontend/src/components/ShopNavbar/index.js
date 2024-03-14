import React, { useEffect, useState } from 'react';
import { animateScroll as scroll } from 'react-scroll';
import SearchBar from '../SeachBar';
import { CgProfile } from 'react-icons/cg';
import {
  Nav2,
  NavLogo,
  NavBtn2,
  NavBtnLink,
  ModalButton
} from '../TextElements';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import RegisterModal from '../RegisterModal';
import LoginModal from '../LoginModal';

function ShopNavbar(props) {
  const [scrollNav, setScrollNav] = useState(false);
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleLogout = () => {
    sessionStorage.setItem("bejelenkezve", "false");
    handleClose();
  }
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

  const toggleHome = () => {
    scroll.scrollToTop();
  };
  
  const [cart, setCart] = useState([]);
  const handleAddToCart = (props) => {
    const newItem = { 
        id: props.TermekId, 
        name: props.TermekNev, 
        price: props.Ar, 
        quantity: props.Menyiseg, 
        color: props.selectedColor 
    };
    setCart([...cart, newItem]);
};

const handleRemoveFromCart = (itemId) => {
    const updatedCart = cart.filter(item => item.id !== itemId);
    setCart(updatedCart);
};


  return (
    <>
      <Nav2 scrollNav={scrollNav}>
     
          <NavLogo to='/' onClick={toggleHome}>
            PrintFusion
          </NavLogo>

          <NavBtn2>
            <SearchBar/>
          </NavBtn2>
          
          { sessionStorage.getItem("bejelenkezve")=='true' ?
            <div>
              <NavBtn2>
                <NavBtnLink to='/ProfilePage'>
                  <CgProfile /> Profile
                </NavBtnLink>
              </NavBtn2>
              {/*
              <NavBtn2>
                <NavBtnLink to='CartPage' onClick={handleAddToCart} ><span class="glyphicon">&#xe116;</span>Cart</NavBtnLink>
              </NavBtn2>
              */}

              <NavBtn2>
                <NavBtnLink to='/CartPage'>Cart</NavBtnLink>
              </NavBtn2>
              
              <NavBtn2>
                <ModalButton onClick={handleShow}>Logout</ModalButton>
              </NavBtn2>
            
            <Modal show={show} onHide={handleClose}>
              <Modal.Header closeButton>
                <Modal.Title>Are you sure you want to log out?</Modal.Title>
              </Modal.Header>
              <Modal.Footer>
                <Button style={{backgroundColor: 'green',border: 'none'}} variant="primary" onClick={handleClose}>
                  No
                </Button>
                <Button variant="secondary" onClick={ handleLogout}>
                  Yes
                </Button>
              </Modal.Footer>
            </Modal>
            </div>
              :
            <div>
                <RegisterModal iincrementCounter={props.incrementCounter} />

                <LoginModal incrementCounter={props.incrementCounter}/>
            </div>
              }

      </Nav2>
    </>
  );
}

export default ShopNavbar;
