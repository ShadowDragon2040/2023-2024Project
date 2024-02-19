import React, { useState } from 'react';
import Navbar from '../components/Navbar';
import DisplayItem from '../components/DisplayItems';
import Footer from '../components/Footer';
import { ShopPageContainer } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';

function ShopPage() {
  const [singleItem, setSingleItem] = useState(false);
  const [ItemData,setItemData]=useState(null)
  const [userData, setUserData] = useState(null);
  console.log(singleItem);
  return (
    <>
      <ShopPageContainer>
        <Navbar
        setUserData={setUserData}
        setItemData={setItemData} 
        setSingleItem={setSingleItem}
        />
        <div className="container">
          <div className="row align-items-start">
            <div className="col-sm-4 col-md-4 col-xl-3">
              <ShopSideBar/>
            </div>
            <div className="col-sm-8 col-md-8 col-xl-9">
              <DisplayItem setSingleItem={setSingleItem} setItemData={setItemData} />
            </div>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default ShopPage;
