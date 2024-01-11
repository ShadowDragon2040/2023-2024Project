import React, {useEffect, useState} from 'react'
import { IconContext } from 'react-icons';
import { animateScroll as scroll } from 'react-scroll';
import { useLocation } from 'react-router-dom/cjs/react-router-dom.min';
import SearchBar from '../SeachBar';

import { 
  Nav,
  NavbarContainer,
  NavLogo,
  NavBtn,
  NavBtnLink,
  InfoContainer,
 } from '../TextElements';



const NavbarA = ({toggle}) => {
  const [scrollNav, setScrollNav]= useState(false);

  const location = useLocation();
  const path = location.pathname;

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

//Mobilos megjelenítés!!!!!
/*<MobileIcon onClick={toggle}>
<FaBars/>
</MobileIcon>
*/

  return (
    <>
    
    <IconContext.Provider value={{color:'#fff'}}>
        <Nav scrollNav={scrollNav}>
          <NavbarContainer>
            <NavLogo to='/' onClick={toggleHome}>PrintFusion</NavLogo>
           
   
            <NavBtn>

             <SearchBar/>
              
            </NavBtn>
            <NavBtn>
              <NavBtnLink  to='ShopPage'>Shop</NavBtnLink>
            </NavBtn>
          </NavbarContainer>
        </Nav>
        </IconContext.Provider>
    </>
  );
};

export default NavbarA;