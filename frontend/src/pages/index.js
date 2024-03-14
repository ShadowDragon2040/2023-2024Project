import React,{useState} from 'react'
import HeroSection from '../components/HeroSection'
import MainNavbar from "../components/MainNavbar"
import Sidebar from '../components/Sidebar'
import InfoSection from '../components/InfoSection'
import PrinterTools from '../components/PrinterTools'
import Services from '../components/Services'
import Footer from '../components/Footer'
import ModelSection from '../components/ModelSection'

const Home = () => {

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }


  return (
    <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <MainNavbar/>
      <HeroSection/>
      <InfoSection />
      <PrinterTools/>
      <ModelSection/>
      <Services/>
      
      <Footer/>
    </>
  )
}

export default Home
