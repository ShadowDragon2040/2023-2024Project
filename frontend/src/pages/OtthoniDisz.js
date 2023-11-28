import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar'
import Sidebar from '../components/Sidebar'
import OtthoniDisz from '../components/OtthiniDisz';
import Footer from '../components/Footer'

function OtthoniDiszPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
      <OtthoniDisz/>
      <Footer/>
      </>
    )
}

export default OtthoniDiszPage