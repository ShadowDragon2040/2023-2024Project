import React,{useState} from 'react'
import HeroSection from '../components/MainPageComponents/HeroComponent'
import MainNavbar from "../components/MainNavbarComponent"
import Sidebar from '../components/MainPageComponents/SidebarComponent'
import InfoSection from '../components/MainPageComponents/InfoComponent'
import PrinterTools from '../components/MainPageComponents/PrinterComponent'
import Services from '../components/MainPageComponents/ServicesComponent'
import Footer from '../components/FooterComponent'
import ModellSection from '../components/MainPageComponents/ModellComponent'

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
      <ModellSection/>
      <Services/>
      <Footer/>
    </>
  )
}

export default Home
