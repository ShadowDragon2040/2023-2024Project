import React from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import CategorySelectorBox from './CategoryBox/CategorySelectorBox';
import { ShopSidebarContainer } from './TextElements';
import { NavLink } from 'react-router-dom';

function ShopSideBar() {
  return (
    <div>
      <ShopSidebarContainer className='border border-dark" rounded bg-ligth text-success'>
        <NavLink to={'/'} className='nav-link'>
          <FaHome /> Home
        </NavLink>
        <NavLink to={'/news'} className='nav-link'>
          <FaNewspaper /> News
        </NavLink>

        <CategorySelectorBox />

        <NavLink to={'/paints'} className='nav-link'>

        <FaPaintBrush />Paints
        </NavLink>
        <NavLink to={'/lab'} className='nav-link'>
          <FaGitlab/> Lab
        </NavLink>
      </ShopSidebarContainer>
    </div>
  );
}

export default ShopSideBar;
