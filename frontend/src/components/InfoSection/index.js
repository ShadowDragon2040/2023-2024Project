import React from 'react'
import {
InfoContainer,
InfoWrapper,
InfoRow,
Column1,
Column2,
TextWrapper,
TopLine,
Heading,
Subtitle,
ImgWrap,
Img,
NavBtn,
NavBtnLink,
baseImageUrl
} from '../TextElements'

const InfoSection = () => {

  return (
    <>
      <InfoContainer  lightBg={false} id={'about'} >
        <Heading lightText={false}>About our company</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper> 
             <TopLine></TopLine>
              <Subtitle darkText={true}>
              At the company, we believe that imagination is the limit, and this can be solved with 3D printing technology. We can offer something to everyone, and for those who need something unique, we hope to be able to provide it. Look around our site and choose what you like, if you can't find it, send us an e-mail. In addition to 3D printing, we deal with painting and electroplating.
              </Subtitle>
            </TextWrapper>
            <NavBtn>
              <NavBtnLink  to='CompanyInfoPage'>About us</NavBtnLink>
            </NavBtn>
            </Column1>
             <Column2>
              <ImgWrap>
                  <Img
                    src={`${baseImageUrl}anycubicphotonmono.jpg`}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2> 
          </InfoRow>
        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default InfoSection
