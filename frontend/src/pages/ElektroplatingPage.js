import React from 'react'
import { useState } from 'react';
import NavbarA from '../components/MainNavbar'
import Sidebar from '../components/Sidebar'
import Elektroplating from '../components/Elektroplating'
import Footer from '../components/Footer'

function ElektroplatingPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <NavbarA toggle={toggle}/>
      <Elektroplating/>
      <Footer/>
      </>
    )
}

export default ElektroplatingPage