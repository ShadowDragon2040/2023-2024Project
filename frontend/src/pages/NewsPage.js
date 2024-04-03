import React, { useState } from 'react';
import Navbar from '../components/ShopNavbar';
import Footer from '../components/Footer';
import { ShopPageContainer } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';

function NewsPage() {
  const [singleItem, setSingleItem] = useState(false);
  const [isProfileVisible, setProfileVisible] = useState(false);
  const [ItemData,setItemData]=useState(null)
  const [userData, setUserData] = useState(null);
  console.log(singleItem);
  return (
    <>
      <ShopPageContainer>
        <Navbar
        isProfileVisible={isProfileVisible}
        setProfileVisible={setProfileVisible}
        setUserData={setUserData}
        setItemData={setItemData} 
        setSingleItem={setSingleItem}
        />
        <div className="container">
          <div className="row align-items-start">
            <div className="col-sm-2 col-md-3 col-xl-2">
              <ShopSideBar/>
            </div>
            <p>Placeholder</p>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default NewsPage;
