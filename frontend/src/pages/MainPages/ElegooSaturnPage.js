import React from 'react'
import { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import {NavBtn,NavBtnLink} from '../../components/TextElements'
import { MdArrowBack } from "react-icons/md";
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
  } from '../../components/TextElements'

function ElegooSaturnPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
  
    return(
      <>
      <Navbar toggle={toggle}/>
      <InfoContainer  lightBg={false} id={'tools'} >
        <Heading lightText={false}>Anycubic Photon Mono</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img/>
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Technology</TopLine>
                <Subtitle darkText={true}>
                Anycubic Photon Mono is an SLA 3D printer that prints with resin that cures under UV light.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Size</TopLine>
                <Subtitle darkText={true}>
                The maximum printable size inside: 13cm x 8cm x 16.5cm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img/>
                </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img/>
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Printing resolution</TopLine>
                <Subtitle darkText={true}>
                The minimum layer height is 0.01mm and the LCD screen has 4k detail.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Material</TopLine>
                <Subtitle darkText={true}>
                The material is abs-like-resin, which is a strong and durable material that cures under UV light.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                    <Img/>
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer>
      <Footer/>
      </>
    )
}

export default ElegooSaturnPage