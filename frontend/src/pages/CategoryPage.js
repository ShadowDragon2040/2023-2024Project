import React, { useState,useEffect } from 'react';
import Navbar from '../components/ShopNavbar';
import Footer from '../components/Footer';
import {
  ShopPageContainer,
  ItemContainer,
  baseUrl } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import axios from 'axios';
import TermekCard from '../components/TermekCard';

function CategoryPage() {
  const [singleItem, setSingleItem] = useState(false);
  const [ItemData,setItemData]=useState(null)
  const [userData, setUserData] = useState(null);
  const [categoryDataList, setCategoryDataList] = useState([]);

  useEffect(() => {
    axios.get(`${baseUrl}Termekek/Termek/`+1)
      .then(response => setCategoryDataList(response.data))
      .catch(error => console.error('Hiba a lekérdezés során:', error));
  }, []);

  return (
    <>
      <ShopPageContainer>
        <Navbar setUserData={setUserData} setItemData={setItemData}  setSingleItem={setSingleItem}/>
        <div className="container">
          <div className="row align-items-start">
            <div className="col-sm-4 col-md-4 col-xl-3">
              <ShopSideBar/>
            </div>
            <ItemContainer className="col-sm-8 col-md-8 col-xl-9">
                <ItemContainer>
                    <div>
                    <div className="row">
                        <div className="col-md-6">
                        <h5>kategórianév</h5>
                        </div>
                    </div>
                    <div className="row w-100">
                        {
                            categoryDataList.map(item => (
                            <TermekCard item={item} key={item.id}/>
                            ))
                        }
                    </div>
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
