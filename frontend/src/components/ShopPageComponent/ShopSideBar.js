import React,{useState,useEffect} from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import {
  ShopSidebarContainer
} from '../TextElements';
import { Link, NavLink } from 'react-router-dom';
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
              height : '90%',
              backgroundColor: 'white'
          }}>
          <Menu menuItemStyles={{
              button: {
                color: '#01bf71',
                marginTop: '20px'
              }
          }}>
            <MenuItem icon={<FaHome /> } component={<NavLink className={'nav-link'} to={'/'}></NavLink>}>Home</MenuItem>

            <MenuItem icon={<FaNewspaper />} component={<NavLink className={'nav-link'} to={'/ShopPage/News'}></NavLink>}> News</MenuItem>

          <SubMenu icon={<BiCategory />} label="Categories">
            <ul>
              {categoryList.map((category) => (
                <div key={category.kategoriaId} className='form-check form-switch menupont'>
                    <MenuItem component={<NavLink className={'nav-link'} to={'/ShopPage/Categories/'+category.kategoriaId}></NavLink>}>
                          {category.kategoriaNev}
                    </MenuItem>
                </div>
              ))}
            </ul>
          </SubMenu>
          
            <MenuItem icon={<FaPaintBrush />} component={<NavLink className={'nav-link'} to={'/ShopPage/paints'}></NavLink>}>Paints</MenuItem>

            <MenuItem icon={<IoGiftSharp />}component={<NavLink className={'nav-link'} to={'/ShopPage/gift'}></NavLink>}>Gift</MenuItem>

            <MenuItem icon={<FaGitlab /> }component={<NavLink className={'nav-link'} to={'/ShopPage/lab'}></NavLink>}>Lab</MenuItem>

          </Menu>
        </Sidebar>
      </ShopSidebarContainer>
  );
}

export default ShopSideBar;