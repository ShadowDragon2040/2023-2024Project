import React,{useState,useEffect} from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import {
  ShopSidebarContainer
} from '../TextElements';
import { NavLink } from 'react-router-dom';
import axios from 'axios';
import { BiCategory } from "react-icons/bi";
import { Sidebar, Menu, MenuItem, SubMenu } from 'react-pro-sidebar';
//https://www.npmjs.com/package/react-pro-sidebar?activeTab=readme

function ShopSideBar(props) {
  const [categoryList, setCategoryList] = useState([]);

    useEffect(() => {
      axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/Kategoriak`)
        .then(response => setCategoryList(response.data))
        .catch(error => console.error('Hiba a lekérdezés során:', error));
    }, []);

  return (
      <ShopSidebarContainer>
        <Sidebar collapsed={props.collapsed} onMouseEnter={props.handleMouseEnter} onMouseLeave={props.handleMouseLeave}
          rootStyles={{
              width : '300px',
              height : '100%',
              backgroundColor: 'white'
          }}>
          <Menu menuItemStyles={{
              button: {
                color: '#01bf71',
                marginTop: '20px'
              }
          }}>
          <NavLink to={'/'} className='nav-link'>
            <MenuItem icon={<FaHome /> }> Home</MenuItem>
          </NavLink>

          <NavLink to={'/ShopPage/news'} className='nav-link'>
            <MenuItem icon={<FaNewspaper />}> News</MenuItem>
          </NavLink>

          <SubMenu icon={<BiCategory />} label="Categories">
            <ul>
              {categoryList.map((category) => (
                <div key={category.kategoriaId} className='form-check form-switch menupont'>
                  <NavLink to={'/ShopPage/Categories/'+category.kategoriaNev} className='nav-link' style={{margin:"0px"}}>
                    <MenuItem>
                          {category.kategoriaNev}
                    </MenuItem>
                  </NavLink>
                </div>
              ))}
            </ul>
          </SubMenu>
          
          <NavLink to={'/ShopPage/paints'} className='nav-link'>
            <MenuItem icon={<FaPaintBrush />}> Paints</MenuItem>
          </NavLink>

          <NavLink to={"/ShopPage/gift"} className='nav-link'>
            <MenuItem icon={<IoGiftSharp />}> Gift</MenuItem>
          </NavLink>

          <NavLink to={'/ShopPage/lab'} className='nav-link'>
            <MenuItem icon={<FaGitlab /> }> Lab</MenuItem>
          </NavLink>

          </Menu>
        </Sidebar>
      </ShopSidebarContainer>
  );
}

export default ShopSideBar;
