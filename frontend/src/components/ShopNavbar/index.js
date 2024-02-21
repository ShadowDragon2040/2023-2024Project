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
                <NavBtnLink to='CartPage'>Cart</NavBtnLink>
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
