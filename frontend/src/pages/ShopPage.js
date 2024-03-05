import React, { useState } from 'react';
import Navbar from '../components/ShopNavbar';
import DisplayItem from '../components/DisplayItems';
import Footer from '../components/Footer';
import { ShopPageContainer } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';

function ShopPage(props) {
  const [userData, setUserData] = useState(null);
  const [collapsed, setCollapsed] = useState(true);

  const handleMouseEnter = () => {
    setCollapsed(false);
};

const handleMouseLeave = () => {
    setCollapsed(true);
};

  return (
    <>
      <ShopPageContainer>
        <Navbar
        setUserData={setUserData}
        bejelenkezve={props.bejelenkezve}
        role={props.role}
        setBejelenkezve={props.setBejelenkezve}
        setRole={props.setRole}
        />
        <div className="container">
          <div className="row">
            <div style={{transition: 'width 0.3s'}} className={`${collapsed ? 'col-1' : 'col-3'}`}>
              <ShopSideBar collapsed={collapsed} handleMouseEnter={handleMouseEnter} handleMouseLeave={handleMouseLeave}/>
            </div>
            <div className={`col`}>
              <DisplayItem collapsed={collapsed}/>
            </div>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default ShopPage;
