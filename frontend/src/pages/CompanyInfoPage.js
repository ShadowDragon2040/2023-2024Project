import React,{useState} from 'react'
import Footer from '../components/Footer'
import Navbar from '../components/ShopNavbar'
import Sidebar from '../components/Sidebar'

const CompanyInfoPage = () => {
  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
  return (
    <>
     <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
    <Footer/>
    </>
  )
}

export default CompanyInfoPage