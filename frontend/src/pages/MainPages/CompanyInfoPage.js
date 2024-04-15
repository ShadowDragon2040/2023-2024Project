import React,{useState} from 'react'
import Navbar from '../../components/MainNavbarComponent'
import Footer from '../../components/FooterComponent'
import { MdArrowBack } from "react-icons/md";
import {NavBtn, NavBtnLink, TextWrapper} from '../../components/TextElements'
import {
  InfoContainer8,
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
      <Navbar toggle={toggle}/>
      <InfoContainer8  lightBg={false} id={'about'} >
        <Heading lightText={false}>About our company</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper> 
             <TopLine></TopLine>
                <Subtitle>
                  At our company, we're pioneers in pushing the boundaries of creativity through the power of 3D printing technology. We firmly believe that imagination knows no bounds, and with the versatility of 3D printing, we can turn even the wildest ideas into tangible realities. Whether you're a tech enthusiast, an artist, or a hobbyist, we have something special just for you.
                </Subtitle>
                <Subtitle>
                  Explore our website and discover a plethora of ready-made designs that cater to a wide range of tastes and interests. But what truly sets us apart is our commitment to personalized innovation. Can't find exactly what you're looking for? Don't worry – simply shoot us an email detailing your vision, and our team of skilled artisans and engineers will work tirelessly to bring it to life.
                </Subtitle>
                <Subtitle>
                  But our expertise doesn't stop at 3D printing. We're also masters of the finishing touches, offering top-notch painting and electroplating services to give your creations that professional polish they deserve. So whether you're dreaming up a one-of-a-kind sculpture, a custom-made gadget, or anything in between, trust us to make your imagination a reality.
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
      </InfoContainer8>
    <Footer/>
    </>
  )
}

export default CompanyInfoPage