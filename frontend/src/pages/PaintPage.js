import React from 'react'
import { useState } from 'react';
import NavbarA from '../components/MainNavbar';
import Sidebar from '../components/Sidebar'
import Paint from '../components/Paint'
import Footer from '../components/Footer'

function PaintPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <NavbarA toggle={toggle}/>
      <Paint/>
      <Footer/>
      </>
    )
}

export default PaintPage