import React, { useState } from 'react';
import Navbar from '../components/Navbar';
import DisplayItem from '../components/DisplayItems';
import Footer from '../components/Footer';
import { HeroContainer2 } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import ProfileDisplayPage from '../components/ProfileDisplayPage';
import DisplaySingleItem from './DisplaySingleItem';

function ShopPage() {
  const [singleItem, setSingleItem] = useState(false);
  const [isProfileVisible, setProfileVisible] = useState(false);
  const [ItemData,setItemData]=useState(null)
  const [userData, setUserData] = useState(null);
  console.log(singleItem);
  return (
    <>
      <HeroContainer2>
        <Navbar
        isProfileVisible={isProfileVisible}
        setProfileVisible={setProfileVisible}
        setUserData={setUserData}
        setItemData={setItemData} 
        setSingleItem={setSingleItem}
        />
        <div className="container">
          <div className="row align-items-start">
            <div className="col-2">
              <ShopSideBar   />
            </div>
            <div className="col-8">
              {singleItem ? <DisplaySingleItem ItemData={ItemData} setSingleItem={setSingleItem}/>: <DisplayItem setSingleItem={setSingleItem} setItemData={setItemData} />}
            </div>
            <div className="col-2">
              {isProfileVisible?<ProfileDisplayPage userData={userData}/>:<></> } 
            </div>
          </div>
        </div>

        <Footer />
      </HeroContainer2>
    </>
  );
}

export default ShopPage;
