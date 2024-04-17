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

const Navbar = (props) => {
  const [show, setShow] = useState(false);
  const [totalQuantity, setTotalQuantity] = useState(0);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);


  const [scrollNav, setScrollNav]= useState(false);
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
          ) : pathname === '/ShopPage'  ? (
            <NavBtn2>
              <SearchBar />
            </NavBtn2>
          ) : <></>}
          {pathname.startsWith('/ShopPage') ? (
            sessionStorage.getItem("bejelenkezve") === 'true' ? (
              <div style={{marginTop:"15px"}}>
                <NavBtn2>
                  <NavBtnLink to='/ProfilePage'>
                    <CgProfile /> Profile
                  </NavBtnLink>
                </NavBtn2>

                <NavBtn2>
                  <NavBtnLink to='/CartPage'>
                    Cart <FaShoppingBasket/> {totalQuantity > 0 && `${totalQuantity}`}
                  </NavBtnLink>
                </NavBtn2>

                <NavBtn2>
                  <NavBtnLink onClick={handleShow}>
                    Logout
                  </NavBtnLink>
                </NavBtn2>

                <Modal show={show} onHide={handleClose}>
                  <Modal.Header closeButton>
                    <Modal.Title>Are you sure you want to log out?</Modal.Title>
                  </Modal.Header>
                  <Modal.Footer>
                    <Button style={{backgroundColor: 'green', border: 'none'}} variant="primary" onClick={handleClose}>
                      No
                    </Button>
                    <Button variant="secondary" onClick={handleLogout}>
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
