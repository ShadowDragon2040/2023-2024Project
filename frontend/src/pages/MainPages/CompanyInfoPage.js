import React,{useState} from 'react'
import NavbarA from '../../components/MainPageComponents/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import { MdArrowBack } from "react-icons/md";
import {NavBtn, NavBtnLink, TextWrapper} from '../../components/TextElements'
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

const CompanyInfoPage = () => {
  const[isOpen,setIsOpen]=useState(false)

  const toggle=()=>{
    setIsOpen(!isOpen)
  }
  return (
    <>
      <NavbarA toggle={toggle}/>
      <InfoContainer  lightBg={false} id={'about'} >
        <Heading lightText={false}>About our company</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper> 
             <TopLine></TopLine>
              <Subtitle darkText={true}>
              At the company, we believe that imagination is the limit, and this can be solved with 3D printing technology. We can offer something to everyone, and for those who need something unique, we hope to be able to provide it. Look around our site and choose what you like, if you can't find it, send us an e-mail. In addition to 3D printing, we deal with painting and electroplating.
              </Subtitle>
            </TextWrapper>
            </Column1>
             <Column2>
              <ImgWrap>
                  <Img
                    src={`${process.env.REACT_APP_KEP_URL}building.jpg`}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2> 
          </InfoRow>
        </InfoWrapper>
      </InfoContainer>
    <Footer/>
    </>
  )
}

export default CompanyInfoPage