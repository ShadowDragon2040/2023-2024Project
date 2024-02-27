import React, { useEffect, useState } from 'react';
import { animateScroll as scroll } from 'react-scroll';
import SearchBar from '../SeachBar';
import { CgProfile } from 'react-icons/cg';
import {
  Nav,
  NavbarContainer,
  NavLogo,
  NavBtn,
  NavBtnLink
} from '../TextElements';

function ShopNavbar(props) {
  const [scrollNav, setScrollNav] = useState(false);
  
  const handleProfileClick = () => {
    if (!props.isProfileVisible) props.setProfileVisible(true);
    else props.setProfileVisible(false);
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
      <Nav scrollNav={scrollNav}>
        <NavbarContainer>
          <NavLogo to='/' onClick={toggleHome}>
            PrintFusion
          </NavLogo>

          <NavBtn>
            <SearchBar/>
          </NavBtn>

          { props.bejelenkezve==true ?
            <div>
              <NavBtn>
                <NavBtnLink to='ProfilePage' onClick={handleProfileClick}>
                  <CgProfile /> Profile
                </NavBtnLink>
              </NavBtn>
              <NavBtn>
                <NavBtnLink to='CartPage' onClick={handleAddToCart} ><span class="glyphicon">&#xe116;</span>Cart</NavBtnLink>
              </NavBtn>
              <NavBtn>
              <NavBtnLink to='LogoutPage'>Logout</NavBtnLink>
            </NavBtn>
            </div>
          : <div>
            <NavBtn>
              <NavBtnLink to='RegisterPage'>Register</NavBtnLink>
            </NavBtn>
            <NavBtn>
              <NavBtnLink to='LoginPage'>Login</NavBtnLink>
            </NavBtn>
            </div>
          }

        </NavbarContainer>
      </Nav>
    </>
  );
}

export default ShopNavbar;
