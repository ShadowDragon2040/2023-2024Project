import React, { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent';
import AllItems from '../../components/ShopPageComponent/AllItemsComponent';
import Footer from '../../components/FooterComponent';
import { ShopPageContainer } from '../../components/TextElements';
import ShopSideBar from '../../components/ShopPageComponent/ShopSideBar';

function ShopPage(props) {

  const [userData, setUserData] = useState(null);


const[counter,setCounter]=useState(0)
const incrementCounter=()=>{
  setCounter(counter+1)
  console.log(counter)
}




  return (
    <>
      <ShopPageContainer>
        <Navbar incrementCounter={incrementCounter} totalQuantity={props.cartItemCount}/>
        <div className="container">
          <div className="row">
            <div style={{transition: 'width 0.3s'}} className={`${props.collapsed ? 'col-1' : 'col-3'}`}>
              <ShopSideBar collapsed={props.collapsed} handleMouseEnter={props.handleMouseEnter} handleMouseLeave={props.handleMouseLeave}/>
            </div>
            <div className={`col`}>
              <AllItems collapsed={props.collapsed}/>
            </div>
          </div>
        </div>

        <Footer />
      </ShopPageContainer>
    </>
  );
}

export default ShopPage;
