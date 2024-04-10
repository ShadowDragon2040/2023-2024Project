import React, { useState } from 'react';
import Navbar from '../../components/ShopPageComponent/ShopNavbarComponent';
import AllItems from '../../components/ShopPageComponent/AllItemsComponent';
import Footer from '../../components/FooterComponent';
import { ShopPageContainer } from '../../components/TextElements';
import ShopSideBar from '../../components/ShopPageComponent/ShopSideBar';

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
        incrementCounter={props.incrementCounter}
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
              <AllItems collapsed={collapsed}/>
            </div>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default ShopPage;
