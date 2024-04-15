import React from 'react'
import { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import Sidebar from '../../components/MainPageComponents/SidebarComponent'
import Paint from '../../components/MainPageComponents/PaintComponent'

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
      <Footer/>
      </>
    )
}

export default PaintPage