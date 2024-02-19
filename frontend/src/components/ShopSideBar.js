import React,{useState,useEffect} from 'react';
import { FaHome, FaNewspaper,FaPaintBrush,FaGitlab } from 'react-icons/fa';
import { IoGiftSharp } from "react-icons/io5";
import { ShopSidebarContainer } from './TextElements';
import { NavLink } from 'react-router-dom';
import axios from 'axios';
import { BiCategory } from "react-icons/bi";

function ShopSideBar() {
  const [categoryList, setCategoryList] = useState([]);
  
    const url="https://localhost:7240/Termekek/Kategoriak";
    useEffect(() => {
      axios.get(url)
        .then(response => setCategoryList(response.data))
        .catch(error => console.error('Hiba a lekérdezés során:', error));
    }, []);
    
  return (
    <div>
      <ShopSidebarContainer>
    
        <NavLink to={'/'} className='nav-link'>
          <h5 className='menupont' >
            <FaHome /> Home
          </h5>
        </NavLink>

        <NavLink to={'/ShopPage/news'} className='nav-link'>
          <h5 className='menupont'>
            <FaNewspaper /> News
          </h5>
        </NavLink>
        
        <h5 className='menupont'>
          <BiCategory/> Categories
        </h5>
        <ul>
          {categoryList.map((category) => (
            <div key={category.kategoriaId} className='form-check form-switch menupont'>
              <NavLink to={'/ShopPage/Categories/'+category.kategoriaNev} className='nav-link' style={{margin:"0px"}}>
                <li>
                  <ul>
                    {category.kategoriaNev}
                  </ul>
                </li>
              </NavLink>
            </div>
          ))}
        </ul>

        <NavLink to={'/ShopPage/paints'} className='nav-link'>
          <h5 className='menupont'>
            <FaPaintBrush /> Paints
          </h5>
        </NavLink>

        <NavLink to={"/ShopPage/gift"} className='nav-link'>
          <h5 className='menupont'>
            <IoGiftSharp /> Gift
          </h5>
        </NavLink>

        <NavLink to={'/ShopPage/lab'} className='nav-link'>
          <h5 className='menupont'>
            <FaGitlab/> Lab
          </h5>
        </NavLink>

      </ShopSidebarContainer>
    </div>
  );
}

export default ShopSideBar;
