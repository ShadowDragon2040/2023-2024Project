import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar';
import CarouselComponent from '../components/CarouselComponent';
import Footer from '../components/Footer';


function ShopPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
        
        <Navbar/>
        <CarouselComponent />
        <Footer/>
               
      </>
      
        )
}

export default ShopPage