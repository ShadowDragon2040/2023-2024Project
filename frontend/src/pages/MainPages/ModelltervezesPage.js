import React from 'react'
import { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import Sidebar from '../../components/MainPageComponents/SidebarComponent'
import {
  InfoContainer15,
  InfoWrapper,
  InfoRow,
  Column1,
  Column2,
  Heading,
  ImgWrap,
  TopLine,
  Img,
  Subtitle
  } from '../../components/TextElements'
function ModellTervezesPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
      <InfoContainer15  lightBg={false} id={'Modelltervezes'} >
        <Heading lightText={false}>Modell Designing</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img style={{height:'500px'}} src={`${process.env.REACT_APP_KEP_URL}Blender.jpg`} />
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Szoftver</TopLine>
                <Subtitle darkText={true}>       
                  We use Blender to design and create the models, with the help of the program you can create any 3D model.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Contact us</TopLine>
                <Subtitle darkText={true}>
                 Contact us if you want to get a uniqe 3D model made by us.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}Képernyőkép%202024-03-25%20102422.png`} />
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer15>
      <Footer/>
      </>
    )
}

export default ModellTervezesPage