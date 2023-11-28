import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar'
import Footer from '../components/Footer';
import Sidebar from '../components/Sidebar';
import SlideShow from '../components/SlideShow';
import { InfoContainer, InfoRow } from '../components/TextElements';

function ShopPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Navbar/>
      <InfoContainer>
        <InfoRow>
          <p>asdsadsd</p>
        </InfoRow>
      </InfoContainer>
      <Footer/>
      </>
      
        )
}

export default ShopPage