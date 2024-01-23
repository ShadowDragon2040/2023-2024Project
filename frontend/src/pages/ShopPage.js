import React from 'react'
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import { HeroContainer2} from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import ProfileDisplayPage from '../components/ProfileDisplayPage'
import NewItemsComponent from '../components/NewItemsComponent';

function ShopPage(){

 
    return(
      <>
        <HeroContainer2>
            <Navbar/>
            <div className="container">
              <div className="row align-items-start">
                <div className="col-2">
                  <ShopSideBar/>
                </div>
              <div className="col-6">
                  <CarouselComponent/>
                  <NewItemsComponent/>
              </div>
            <div className="col-4">
                <ProfileDisplayPage/>
            </div>
          </div>
          </div>
           
          
            <Footer/>
        </HeroContainer2>
      </>
      
        )
}

export default ShopPage