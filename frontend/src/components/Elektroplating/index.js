import React from 'react'
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
} from '../TextElements'

const Elektroplating = () => {
  return (
    <>
      <InfoContainer  lightBg={false} id={'Elektroplating'} >
        <Heading lightText={false}>Ender 3V2</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.KEP_URL}anycubicphotonmono.jpg`}
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
                    src={`${process.env.KEP_URL}anycubicphotonmono.jpg`}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.KEP_URL}anycubicphotonmono.jpg`}
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
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Printing resolution</TopLine>
                <Subtitle darkText={true}>
                The minimum layer height is 0.1 mm and the maximum layer height is 0.4 mm.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.KEP_URL}PEIsheet.jpg`}
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

export default Elektroplating
