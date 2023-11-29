import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar'
import Footer from '../components/Footer';
import { InfoContainer, InfoRow } from '../components/TextElements';
import SlideShow from '../components/SlideShow';

function ShopPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
        <SlideShow>
          </SlideShow>      
      </>
      
        )
}

export default ShopPage