import React from 'react'
import { useState } from 'react';
import Navbar from '../components/Navbar'
import Sidebar from '../components/Sidebar'
import Alkatresz from '../components/Alkatresz';
import Footer from '../components/Footer'

function AlkatreszPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
      <Alkatresz/>
      <Footer/>
      </>
    )
}

export default AlkatreszPage