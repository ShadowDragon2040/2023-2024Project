import React, { useState } from 'react';
import Navbar from '../components/ShopNavbar';
import DisplayItem from '../components/DisplayItems';
import Footer from '../components/Footer';
import { ShopPageContainer } from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';

function ShopPage(props) {
  const [userData, setUserData] = useState(null);



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
          <div className="row align-items-start">
            <div className="col-sm-4 col-md-4 col-xl-3">
              <ShopSideBar/>
            </div>
            <div className="col-sm-8 col-md-8 col-xl-9">
              <DisplayItem/>
            </div>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default ShopPage;
