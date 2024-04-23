import React, { useState, useEffect } from 'react';
import { FaHome, FaNewspaper, FaPaintBrush, FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import { ShopSidebarContainer } from '../TextElements';
import { NavLink } from 'react-router-dom';
import axios from 'axios';
import { BiCategory } from "react-icons/bi";
import { Sidebar, Menu, MenuItem, SubMenu } from 'react-pro-sidebar';

function ShopSideBar(props) {
  const [categoryList, setCategoryList] = useState([]);

  useEffect(() => {
    axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/Kategoriak`)
      .then(response => setCategoryList(response.data))
      .catch(error => console.error('Error during the request:', error));
  }, []);

  return (
    <ShopSidebarContainer>
      <Sidebar
        collapsed={props.collapsed}
        onMouseEnter={props.handleMouseEnter}
        onMouseLeave={props.handleMouseLeave}
        rootStyles={{
          width: '300px',
          height: '100%',
          backgroundColor: 'white'
        }}
      >
        <Menu menuItemStyles={{
          button: {
            color: '#01bf71',
            marginTop: '20px'
          }
        }}>
          <NavLink to={'/'} className='nav-link'>
            <MenuItem icon={<FaHome />} prefix={"Home"}/>
          </NavLink>

          <NavLink to={'/ShopPage/News'} className='nav-link'>
            <MenuItem icon={<FaNewspaper />} prefix={"News"}/>
          </NavLink>

          <SubMenu  icon={<BiCategory />} label="Categories">
            <ul>
              {categoryList.map((category) => (
                <li key={category.kategoriaId}>
                  <NavLink to={'/ShopPage/Categories/' + category.kategoriaId} className='nav-link' style={{ margin: "0px" }}>
                    <MenuItem>
                      {category.kategoriaNev}
                    </MenuItem>
                  </NavLink>
                </li>
              ))}
            </ul>
          </SubMenu>

          <NavLink to={'/ShopPage/paints'} className='nav-link'>
            <MenuItem icon={<FaPaintBrush />} prefix={"Paints"}/>
          </NavLink>

          <NavLink to={"/ShopPage/gift"} className='nav-link'>
            <MenuItem icon={<IoGiftSharp />} prefix={"Gift"}/>
          </NavLink>

          <NavLink to={'/ShopPage/lab'} className={'disabled nav-link'}>
            <MenuItem icon={<FaGitlab />} prefix={"Lab"} suffix={"coming soon"}/>
          </NavLink>

        </Menu>
      </Sidebar>
    </ShopSidebarContainer>
  );
}

export default ShopSideBar;
