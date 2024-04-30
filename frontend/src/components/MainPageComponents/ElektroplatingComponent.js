import React from 'react'
import { MdArrowBack } from "react-icons/md";
import {NavBtn,NavBtnLink} from '../TextElements'
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
} from '../TextElements'

const Elektroplating = () => {
  return (
    <>
      <InfoContainer15  lightBg={false} id={'Elektroplating'} >
        <Heading lightText={false}>Elektroplating</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img src={`${process.env.REACT_APP_KEP_URL}ElektroplatingProcess.jpg`} />
              </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Technology</TopLine>
                <Subtitle darkText={true}>
                  Electrochemical deposition is a flexible low-cost technology of fabrication of a wide variety of two- and three-dimensional coatings or films. As the name suggests, the process involves depositing material using an electric current.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Surface finish</TopLine>
                <Subtitle darkText={true}>
                 After the process the elektroplated plastic object will have a metalic finsih.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
              <ImgWrap>
                <Img src={`${process.env.REACT_APP_KEP_URL}Elektroplating.jpg`} />
              </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer15>
    </>
  )
}

export default Elektroplating
