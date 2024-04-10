import React from 'react'
import { useState } from 'react';
import NavbarA from '../../components/MainPageComponents/MainNavbarComponent'
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
function BambuPage(){

  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
    return(
      <>
      <NavbarA toggle={toggle}/>
      <InfoContainer5  lightBg={false}>
        <Heading lightText={false}>Bambu Carbon X1</Heading>
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
                The Bambu Carbon X1 is an FDM 3D printer that builds the desired object layer by layer using liquid plastic.
                It is a high end precision 3D printer that is capable of using high strenght materials such as carbon fiber infused PLA and it is much more faster then the regular home 3D printers.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Size</TopLine>
                <Subtitle darkText={true}>
                The maximum printable size inside is: 25.6cm x 25.6cm x 25.6cm.
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
                  <Img src={`${process.env.REACT_APP_KEP_URL}PEIsheet.jpg`} />
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Multi Color printing</TopLine>
                <Subtitle darkText={true}>
                With the use of the Bambu Carbon X1 it is possible to print 3D objects with multiple colors, using the provided AMS witch stores and dehidrates the materials and the printer can switch colors mid printing.
                This can be used to print with different kind of materials in the same 3D print, allowing the possibility of composit materials. 
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Printing resolution</TopLine>
                <Subtitle darkText={true}>
                The minimum layer height is 0.08 mm and the maximum layer height is 0.4 mm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}PEIsheet.jpg`}></Img>
                </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer5>
      <Footer/>
      </>
    )
}

export default BambuPage