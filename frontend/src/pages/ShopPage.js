import React from 'react'
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import { HeroContainer2} from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import ProfileDisplayPage from '../components/ProfileDisplayPage'

function ShopPage(){

 
    return(
      <>
        <HeroContainer2>
            <Navbar/>
            <div className='row'>
              <div className='col-md-2'>
                <ShopSideBar/>
              </div>
              <div className='col-md-6'>
                <CarouselComponent />
              </div>
              <div className='col-md-4'>
                <ProfileDisplayPage/>
              </div>
            </div>
          
            <Footer/>
        </HeroContainer2>
      </>
      
        )
}

export default ShopPage