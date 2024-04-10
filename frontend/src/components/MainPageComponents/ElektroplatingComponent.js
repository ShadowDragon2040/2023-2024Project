import React from 'react'
import { MdArrowBack } from "react-icons/md";
import {NavBtn,NavBtnLink} from '../TextElements'
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
} from '../TextElements'

const Elektroplating = () => {
  return (
    <>
      <InfoContainer5  lightBg={false} id={'Elektroplating'} >
        <Heading lightText={false}>Ender 3V2</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.REACT_APP_KEP_URL}anycubicphotonmono.jpg`}
                    alt={'Our Company'}
                  />
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
                The maximum printable size inside: 22cm x 22cm x 25cm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.REACT_APP_KEP_URL}anycubicphotonmono.jpg`}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.REACT_APP_KEP_URL}anycubicphotonmono.jpg`}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>PEI Buildplate</TopLine>
                <Subtitle darkText={true}>
                An excellent printing surface that provides strong adhesion and gives a unique pattern.
                </Subtitle>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer5>
    </>
  )
}

export default Elektroplating
