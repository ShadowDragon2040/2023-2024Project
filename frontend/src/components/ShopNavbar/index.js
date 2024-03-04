import React, { useEffect, useState } from 'react';
import { animateScroll as scroll } from 'react-scroll';
import SearchBar from '../SeachBar';
import { CgProfile } from 'react-icons/cg';
import {
  Nav,
  NavLogo,
  NavBtn2,
  NavBtnLink,
  LogoutButton
} from '../TextElements';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function ShopNavbar(props) {
  const [scrollNav, setScrollNav] = useState(false);
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleLogout = () => {
    props.setBejelenkezve(false);
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
<<<<<<< HEAD
  
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


=======
//          { props.bejelenkezve==true ?
>>>>>>> 2f71c9256eea78cc3aabd1e634b4451ee2adf8a9
  return (
    <>
      <Nav scrollNav={scrollNav}>

          <NavLogo to='/' onClick={toggleHome}>
            PrintFusion
          </NavLogo>

          <NavBtn2>
            <SearchBar/>
          </NavBtn2>

            <div>
              <NavBtn2>
                <NavBtnLink to='/ProfilePage'>
                  <CgProfile /> Profile
                </NavBtnLink>
<<<<<<< HEAD
              </NavBtn>
              <NavBtn>
                <NavBtnLink to='CartPage' onClick={handleAddToCart} ><span class="glyphicon">&#xe116;</span>Cart</NavBtnLink>
              </NavBtn>
              <NavBtn>
              <NavBtnLink to='LogoutPage'>Logout</NavBtnLink>
            </NavBtn>
=======
              </NavBtn2>
              <NavBtn2>
                <NavBtnLink to='/CartPage'>Cart</NavBtnLink>
              </NavBtn2>
              <NavBtn2>
                <LogoutButton onClick={handleShow}>Logout</LogoutButton>
              </NavBtn2>
>>>>>>> 2f71c9256eea78cc3aabd1e634b4451ee2adf8a9
            </div>

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

            <div>
            <NavBtn2>
              <NavBtnLink to='/RegisterPage'>Register</NavBtnLink>
            </NavBtn2>
            <NavBtn2>
              <NavBtnLink to='/LoginPage'>Login</NavBtnLink>
            </NavBtn2>
            </div>
      </Nav>
    </>
  );
}

export default ShopNavbar;
