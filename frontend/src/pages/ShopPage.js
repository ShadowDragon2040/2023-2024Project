import React, { useState } from 'react';
import Navbar from '../components/Navbar';
import DisplayItem from '../components/DisplayItems';
import Footer from '../components/Footer';
import { HeroContainer2 } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import ProfileDisplayPage from '../components/ProfileDisplayPage';
import DisplaySingleItem from './DisplaySingleItem';

function ShopPage() {
  const [singleItem, setSingleItem] = useState(true);
  const [ItemData,setItemData]=useState(null)

  return (
    <>
      <HeroContainer2>
        <Navbar />
        <div className="container">
          <div className="row align-items-start">
            <div className="col-2">
              <ShopSideBar />
            </div>
            <div className="col-6">
              {singleItem ? <DisplayItem setSingleItem={setSingleItem} setItemData={setItemData} /> : <DisplaySingleItem ItemData={ItemData} setSingleItem={setSingleItem}/>}
            </div>
            <div className="col-4">
              <ProfileDisplayPage />
            </div>
          </div>
        </div>

        <Footer />
      </HeroContainer2>
    </>
  );
}

export default ShopPage;
