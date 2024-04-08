import React from 'react'
import { useState } from 'react';
import NavbarA from '../components/MainNavbar'
import Footer from '../components/Footer'
import {NavBtn,NavBtnLink} from '../components/TextElements'
import { NavLink } from 'react-bootstrap';
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
  } from '../components/TextElements'
function EnderPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <NavbarA toggle={toggle}/>
      <InfoContainer5  lightBg={false}>
        <Heading lightText={false}>Ender 3V2</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}fdmboatmodell.jpg`} />
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Technology</TopLine>
                <Subtitle darkText={true}>
                The Ender 3 V2 is an FDM 3D printer that builds the desired object layer by layer using liquid plastic.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Size</TopLine>
                <Subtitle darkText={true}>
                The maximum printable size inside is: 22cm x 22cm x 25cm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}Ender3v2_Volume.jpg`} />
                </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}PEIsheet.jpg`} />
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>PEI Buildplate</TopLine>
                <Subtitle darkText={true}>
                An excellent printing surface that provides strong adhesion and gives an unique pattern.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Printing resolution</TopLine>
                <Subtitle darkText={true}>
                The minimum layer height is 0.1 mm and the maximum layer height is 0.4 mm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}fdmlayerheightcomparison.jpg`}></Img>
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer5>
      <Footer/>
      </>
    )
}

export default EnderPage