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

function Navbar(props) {
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
            <SearchBar
              setItemData={props.setItemData}
              setSingleItem={props.setSingleItem}
            />
          </NavBtn>

          <NavBtn>
            <NavBtnLink to='ShopPage' onClick={handleProfileClick}>
              <CgProfile />
            </NavBtnLink>
          </NavBtn>

          <NavBtn>
            <NavBtnLink to='ShopPage'>Login</NavBtnLink>
          </NavBtn>
        </NavbarContainer>
      </Nav>
    </>
  );
}

export default Navbar;
