import React from 'react'
import { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import {NavBtn,NavBtnLink} from '../../components/TextElements'
import { MdArrowBack } from "react-icons/md";
import {
  InfoContainer5,
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
      <InfoContainer5  lightBg={false} id={'tools'} >
        <Heading lightText={false}>Elegoo Saturn</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}SaturnTechnology.png`} />
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Technology</TopLine>
                <Subtitle darkText={true}>
                Elegoo Saturn is an SLA 3D printer that prints with resin that cures under UV light.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Build volume</TopLine>
                <Subtitle darkText={true}>
                The maximum printable size inside: 21,8cm x 12,2cm x 26cm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}ElegooVolume.jpeg`} />
                </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}elegooSaturn3.png`} />
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
                  <Img src={`${process.env.REACT_APP_KEP_URL}abslikeresin.jpg`} />
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer5>
      <Footer/>
      </>
    )
}

export default ElegooSaturnPage