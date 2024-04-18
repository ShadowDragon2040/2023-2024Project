import React, { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent';
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
const[counter,setCounter]=useState(0)
const incrementCounter=()=>{
  setCounter(counter+1)
  console.log(counter)
}

const handleMouseLeave = () => {
    setCollapsed(true);
};


  return (
    <>
      <ShopPageContainer>
        <Navbar incrementCounter={incrementCounter} totalQuantity={props.cartItemCount}/>
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
