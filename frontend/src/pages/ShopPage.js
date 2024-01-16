import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import CategorySelectorBox from '../components/CategoryBox/CategorySelectorBox';
import { HeroContainer2} from '../components/TextElements';
import ShopSideBar from '../components/ShopSideBar';

function ShopPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
        <HeroContainer2>
            <Navbar/>
          <div className='container'>
            <div className='row'>
              <div className='col-sm-3'>
                <ShopSideBar/>
              </div>
              <div className='col-md-6'>
                <CarouselComponent />
              </div>
              <div className='col-sm-3'>

              </div>
            </div>
          </div>
          
              

          
         
            
          
        <Footer/>
        </HeroContainer2>   
      </>
      
        )
}

export default ShopPage