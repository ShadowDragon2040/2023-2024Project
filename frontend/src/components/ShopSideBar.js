import React from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import CategorySelectorBox from './CategoryBox/CategorySelectorBox';
import { ShopSidebarContainer } from './TextElements';
import { NavLink } from 'react-router-dom';

function ShopSideBar() {
  return (
    <div>
      <ShopSidebarContainer className='bg-ligth text-success '>
    
        <NavLink to={'/'} className='nav-link'>
        <h5 className='p-2'>

          <FaHome /> Home
          </h5>
         
        </NavLink>
        <NavLink to={'/news'} className='nav-link'>
          <h5 className='p-2'>

          <FaNewspaper /> News
          </h5>
        </NavLink>
        
        <CategorySelectorBox />

        <NavLink to={'/paints'} className='nav-link'>
        <h5 className='p-2'>

        <FaPaintBrush /> Paints

        </h5>
        </NavLink>
        <NavLink to={"/gift"} className='nav-link'>
          <h5 className='p-2'>
            <IoGiftSharp /> Gift
          </h5>
        </NavLink>
        <NavLink to={'/lab'} className='nav-link'>
        <h5 className='p-2'>

          <FaGitlab/> Lab

          </h5>
        </NavLink>
      </ShopSidebarContainer>
    </div>
  );
}

export default ShopSideBar;
