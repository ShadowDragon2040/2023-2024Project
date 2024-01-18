import React from 'react'
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import { HeroContainer2, ItemContainer} from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import ProfileDisplayPage from '../components/ProfileDisplayPage'
import NewItemsComponent from '../components/NewItemsComponent';

function ShopPage(){

 
    return(
      <>
        <HeroContainer2>
            <Navbar/>
            <div class="container">
              <div class="row align-items-start">
                <div class="col-2">
                  <ShopSideBar/>
                </div>
              <div class="col-6">
                  <CarouselComponent/>
                  <NewItemsComponent/>
              </div>
            <div class="col-4">
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