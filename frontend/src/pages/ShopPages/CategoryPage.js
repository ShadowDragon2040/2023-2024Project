import React, { useState,useEffect } from 'react';
import axios from 'axios';
import Navbar from '../../components/MainNavbarComponent';
import ShopSideBar from '../../components/ShopPageComponent/ShopSideBar';
import TermekListCard from '../../components/ShopPageComponent/TermekListCard';
import Footer from '../../components/FooterComponent';
import {
  ShopPageContainer,
  ItemContainer
} from '../../components/TextElements';
import { useParams } from 'react-router-dom';
import { toast } from 'react-toastify';

function CategoryPage() {
  const { CategoryId } = useParams(); 
  const [singleItem, setSingleItem] = useState(false);
  const [ItemData,setItemData]=useState(null)
  const [userData, setUserData] = useState(null);
  const [categoryDataList, setCategoryDataList] = useState([]);
  const [collapsed, setCollapsed] = useState(true);

  const handleMouseEnter = () => {
    setCollapsed(false);};

  const handleMouseLeave = () => {
    setCollapsed(true);};

  useEffect(() => {
    const token=localStorage.getItem('LoginToken');
    axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/Termek/`+CategoryId,{
      headers:{
        'Authorization':'Bearer'+token
      }
    })
      .then(response => {setCategoryDataList(response.data);})
      .catch(error =>{
        if(error.response&&error.response.status===404){
          toast.error('Product not found!');
        }
        console.error('Hiba a lekérdezés során:', error)
      } );
  }, [CategoryId]);

  return (
    <>
      <ShopPageContainer>
        <Navbar setUserData={setUserData} setItemData={setItemData}  setSingleItem={setSingleItem}/>
        <div className="container">
          <div className="row">
            <div style={{transition: 'width 0.3s'}} className={`${collapsed ? 'col-1' : 'col-3'}`}>
              <ShopSideBar handleMouseEnter={handleMouseEnter} handleMouseLeave={handleMouseLeave} collapsed={collapsed}/>
            </div>
            <ItemContainer className="col-sm-8 col-md-8 col-xl-8">
                <ItemContainer>
                <div className="row">
                    {categoryDataList.length === 0 ? (
                      <div className="col-md-12 col-xl-12 col-sm-12">
                        <h5 style={{color:"white",height:"420px",textAlign:"left"}}>No products found with this category ID</h5>
                      </div>
                    ) : (
                      categoryDataList.map(item => (
                        <div className="col-md-12 col-xl-12 col-sm-12" key={item.id}>
                          <h5 style={{ color: "white" }}>{item.kategoriaNev}</h5>
                          <TermekListCard item={item}/>
                        </div>
                      ))
                    )}
                </div>
                </ItemContainer>
            </ItemContainer>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default CategoryPage;
