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
          <h5>
          <FaHome /> Home
          </h5>
         
        </NavLink>
        <NavLink to={'/news'} className='nav-link'>
          <h5>

          <FaNewspaper /> News
          </h5>
        </NavLink>

        <CategorySelectorBox />

        <NavLink to={'/paints'} className='nav-link'>
        <h5>
        <FaPaintBrush /> Paints

        </h5>
        </NavLink>
        <NavLink to={'/lab'} className='nav-link'>
          <h5>
          <FaGitlab/> Lab

          </h5>
        </NavLink>
      </ShopSidebarContainer>
    </div>
  );
}

export default ShopSideBar;
