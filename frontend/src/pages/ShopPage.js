import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';
import CategorySelectorBox from '../components/CategoryBox/CategorySelectorBox';
import { InfoContainer } from '../components/TextElements';

function ShopPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
        <InfoContainer>
        <Navbar/>
        <div className='container'>
              

          <div className='row'>
            <div className='col col-md-12'>
              <CategorySelectorBox/>
              <CarouselComponent />
            </div>
          </div>
            
        </div>
          
        <Footer/>
        </InfoContainer>   
      </>
      
        )
}

export default ShopPage