import React from 'react'
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import { HeroContainer2} from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';
import '../App.css'

function ShopPage(){

 
    return(
      <>
        <HeroContainer2>
            <Navbar/>
            <div className='row'>
              <div className='col-sm-4'>
                <ShopSideBar/>
              </div>
              <div className='col-md-4'>
                <CarouselComponent />
              </div>
              <div className='col-sm-4'>

              </div>
            </div>
          
            <Footer/>
        </HeroContainer2>
      </>
      
        )
}

export default ShopPage