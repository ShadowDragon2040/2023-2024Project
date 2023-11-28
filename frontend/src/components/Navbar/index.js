import React, {useEffect, useState} from 'react'
import {FaBars} from 'react-icons/fa'
import { IconContext } from 'react-icons';
import { animateScroll as scroll } from 'react-scroll';

import { 
  Nav,
  NavbarContainer,
  NavLogo,
  MobileIcon,
  NavItem,
  NavMenu,
  NavLinks,
  NavBtn,
  NavBtnLink
 } from '../TextElements';



const Navbar = ({toggle}) => {
  const [scrollNav, setScrollNav]= useState(false);

  const changeNav=()=>{
    if(window.scrollY >= 80){
      setScrollNav(true);
    }else{
      setScrollNav(false);
    }
  }
  useEffect(()=>{
    window.addEventListener('scroll',changeNav);
  },[])

  const toggleHome=()=>{
    scroll.scrollToTop();
  }

  return (
    <>
    <IconContext.Provider value={{color:'#fff'}}>
        <Nav scrollNav={scrollNav}>
          <NavbarContainer>
            <NavLogo to='/' onClick={toggleHome}>PrintFusion</NavLogo>
            <MobileIcon onClick={toggle}>
              <FaBars/>
            </MobileIcon>
            <NavMenu>
              <NavItem>
                <NavLinks to='about'
                smooth={true} 
                duration={500} 
                spy={true}
                exact='true' 
                offset={-80}
                >Bemutatkozás</NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks to='tools'
                smooth={true} 
                duration={500} 
                spy={true}
                exact='true'
                offset={-80}
                >Nyomtatóink</NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks to='products'
                smooth={true} 
                duration={500} 
                spy={true}
                exact='true' 
                offset={-80}
                >Termékeink</NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks to='models'
                smooth={true} 
                duration={500} 
                spy={true}
                exact='true' 
                offset={-80}
                >Modellek</NavLinks>
              </NavItem>
              <NavItem>
                <NavLinks to='services'
                smooth={true} 
                duration={500} 
                spy={true}
                exact='true' 
                offset={-80}
                >Utómunkák</NavLinks>
              </NavItem>
            </NavMenu>
            <NavBtn>
              <NavBtnLink to='ShopPage'>Shop</NavBtnLink>
            </NavBtn>
          </NavbarContainer>
        </Nav>
        </IconContext.Provider>
    </>
  );
};

export default Navbar;