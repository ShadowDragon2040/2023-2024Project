import React, { useEffect, useState } from 'react';
import { animateScroll as scroll } from 'react-scroll';
import SearchBar from './ShopPageComponent/SeachBar';
import { CgProfile } from 'react-icons/cg';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import CartPage from '../pages/ShopPages/CartPage';
import { FaShoppingBasket } from 'react-icons/fa';
import RegisterModal from './ShopPageComponent/RegisterModal';
import LoginModal from './ShopPageComponent/LoginModal';
import { IconContext } from 'react-icons';
import { useLocation } from 'react-router-dom';

import { 
  Nav,
  NavbarContainer,
  NavLogo,
  NavItem,
  NavMenu,
  NavLinks,
  NavBtn,
  NavBtnLink,
  NavBtn2
} from './TextElements';
import { ModalButton } from 'react-st-modal';

const Navbar = (props) => {
  const [show, setShow] = useState(false);
  const [show2, setShow2] = useState(false);
  const [totalQuantity, setTotalQuantity] = useState(0);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const handleClose2 = () => setShow2(false);
  const handleShow2 = () => setShow2(true);


  const [scrollNav, setScrollNav]= useState(false);
  //const location = useLocation();
  const {pathname} = useLocation()


  useEffect(() => {
    console.log(pathname)
  }, [pathname])

  const changeNav=()=>{
    if(window.scrollY >= 80){
      setScrollNav(true);
    } else {
      setScrollNav(false);
    }
  }

  useEffect(()=>{
    window.addEventListener('scroll', changeNav);
    return () => {
      window.removeEventListener('scroll', changeNav);
    };
  }, []);

  const toggleHome=()=>{
    scroll.scrollToTop();
  }

  const handleLogout = () => {
    sessionStorage.setItem("bejelenkezve", "false");
    handleClose();
  };

  useEffect(() => {
    let total = 0;
    if (props.cart) {
      props.cart.forEach(item => {
        total += item.quantity;
      });
    }
    setTotalQuantity(total);
  }, [props.cart]);

  return (
    <IconContext.Provider value={{color:'#fff'}}>
      <Nav scrollNav={scrollNav}>
        <NavbarContainer>
          <NavLogo to='/' onClick={toggleHome}>PrintFusion</NavLogo>
          {pathname === '/' ? (
            <NavMenu>
              <NavItem>
                <NavLinks
                  to='about'
                  smooth={true}
                  duration={500}
                  spy={true}
                  exact='true'
                  offset={-80}
                >
                  Introduction
                </NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks
                  to='tools'
                  smooth={true}
                  duration={500}
                  spy={true}
                  exact='true'
                  offset={-80}
                >
                  Our Printers
                </NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks
                  to='models'
                  smooth={true}
                  duration={500}
                  spy={true}
                  exact='true'
                  offset={-80}
                >
                  Modells
                </NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks
                  to='services'
                  smooth={true}
                  duration={500}
                  spy={true}
                  exact='true'
                  offset={-80}
                >
                  Other services
                </NavLinks>
              </NavItem>
            </NavMenu>
          ) : pathname.startsWith('/ShopPage') ? (
            <NavBtn2>
              <SearchBar />
            </NavBtn2>
          ) : <></>}
          {pathname.startsWith('/ShopPage') ? (
            sessionStorage.getItem("bejelenkezve") === 'true' ? (
              <div>
                <NavBtn2>
                  <NavBtnLink to='/ProfilePage'>
                    <CgProfile /> Profile
                  </NavBtnLink>
                </NavBtn2>
                <NavBtn2>
                  <NavBtnLink onClick={handleShow}>
                    Cart <FaShoppingBasket/> {totalQuantity > 0 && `${totalQuantity}`}
                  </NavBtnLink>
                </NavBtn2>
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
          
          <Button variant="primary" onClick={() => console.log('Fizetés')}>Fizetés</Button>
        </Modal.Footer>
      </Modal>
                <NavBtnLink onClick={handleShow2}>Logout</NavBtnLink>
                <Modal show2={show2} onHide={handleClose2}>
                  <Modal.Header closeButton>
                    <Modal.Title>Are you sure you want to log out?</Modal.Title>
                  </Modal.Header>
                  <Modal.Footer>
                    <Button style={{backgroundColor: 'green', border: 'none'}} variant="primary" onClick={handleClose2}>
                      No
                    </Button>
                    <Button variant="secondary" onClick={ handleLogout}>
                      Yes
                    </Button>
                  </Modal.Footer>
                </Modal>
              </div>
            ) : (
              <NavBtn>
                <RegisterModal />
                <div style={{width: '20px'}}></div>
                <LoginModal incrementCounter={props.incrementCounter} setShow={setShow}/>
                <div style={{width: '200px'}}></div>
              </NavBtn>
            )
          ) : <></>}
          {pathname === '/ShopPage'  ? (
            <></>
          ):
            <NavBtn>
              <NavBtnLink onClick={toggleHome} to='/ShopPage'>Shop</NavBtnLink>
            </NavBtn>
          }
        </NavbarContainer>
      </Nav>
    </IconContext.Provider>
  );
};

export default Navbar;
