import React from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import CategorySelectorBox from './CategoryBox/CategorySelectorBox';
import { ShopSidebarContainer } from './TextElements';
import { NavLink } from 'react-router-dom';

function ShopSideBar() {
  return (
    <div>
      <ShopSidebarContainer>
    
        <NavLink to={'/'} className='nav-link'>
        <h5 className='p-2 menupont' >

          <FaHome /> Home
          </h5>
         
        </NavLink>
        <NavLink to={'/news'} className='nav-link'>
          <h5 className='p-2 menupont'>

          <FaNewspaper /> News
          </h5>
        </NavLink>
        
        <CategorySelectorBox />

        <NavLink to={'/paints'} className='nav-link'>
        <h5 className='p-2 menupont'>

        <FaPaintBrush /> Paints

        </h5>
        </NavLink>
        <NavLink to={"/gift"} className='nav-link'>
          <h5 className='p-2 menupont'>
            <IoGiftSharp /> Gift
          </h5>
        </NavLink>
        <NavLink to={'/lab'} className='nav-link'>
        <h5 className='p-2 menupont'>

          <FaGitlab/> Lab

          </h5>
        </NavLink>
      </ShopSidebarContainer>
    </div>
  );
}

export default ShopSideBar;
