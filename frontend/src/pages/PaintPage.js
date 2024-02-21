import React from 'react'
import { useState } from 'react';
import Navbar from '../components/ShopNavbar'
import Sidebar from '../components/Sidebar'
import Paint from '../components/Paint'
import Footer from '../components/Footer'
import Gallery from '../components/Gallery'

function PaintPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
      <Paint/>
      <Gallery/>
      <Footer/>
      </>
    )
}

export default PaintPage