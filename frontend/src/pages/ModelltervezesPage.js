import React from 'react'
import { useState } from 'react';
import Navbar from '../components/ShopNavbar'
import Sidebar from '../components/Sidebar'
import Footer from '../components/Footer'
import {
  InfoContainer,
  InfoWrapper,
  InfoRow,
  Column1,
  Column2,
  Heading,
  ImgWrap,
  TopLine,
  Img,
  Subtitle
  } from '../components/TextElements'
function ModellTervezesPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <Sidebar isOpen={isOpen} toggle={toggle}/>
      <Navbar toggle={toggle}/>
      <InfoContainer  lightBg={false} id={'Modelltervezes'} >
        <Heading lightText={false}>Modelltervezés</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img></Img>
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Szoftver</TopLine>
                <Subtitle darkText={true}>
                A modellek tervezésére és elkészítésére a Blender-t használjuk, a programm segítségével bármilyen 3D modellt el lehet készíteni.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Méretek</TopLine>
                <Subtitle darkText={true}>
                A belső maximum nyomtatható méret: 22cm x 22cm x 25cm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img></Img>
                </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img></Img>
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>PEI nyomtatólap</TopLine>
                <Subtitle darkText={true}>
                Kíváló nyomtatási felület amely erős tapadást biztosít és egyedi mintázatot ad.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Felbontás</TopLine>
                <Subtitle darkText={true}>
                A minimális rétegmagasság 0,1mm és a maximális rétegmagasság 0,4mm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img></Img>
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer>
      <Footer/>
      </>
    )
}

export default ModellTervezesPage