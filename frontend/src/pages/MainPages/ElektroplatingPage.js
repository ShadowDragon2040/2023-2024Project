import React from 'react'
import { useState } from 'react';
import NavbarA from '../../components/MainPageComponents/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import Elektroplating from '../../components/MainPageComponents/ElektroplatingComponent'

function ElektroplatingPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <NavbarA toggle={toggle}/>
      <Elektroplating/>
      <Footer/>
      </>
    )
}

export default ElektroplatingPage