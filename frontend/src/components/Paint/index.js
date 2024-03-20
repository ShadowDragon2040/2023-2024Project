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

export const homeObjOne={
  id:'tools',
  lightBg:false,
  lightText:true,
  lightTextDesc:false,
  headline:'Cég bemutató',
  topLine:'Industár.kft',
  imgStart:false,
  img:require('../../images/industar-kft-front.jpg'),
  alt:'Car',
  dark:true,
  primary:true,
  darkText:true,
};

const Paint = () => {
  return (
    <>
      <InfoContainer  lightBg={false} id={'Paint'} >
        <Heading lightText={false}>Festés</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={'http://printfusion.nhely.hu/test/anycubicphotonmono.jpg'}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Spray painting</TopLine>
                <Subtitle darkText={true}>
                With spray painting, we can create an even paint layer of one color, recommended for covering elements and home decorations.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Hand painting</TopLine>
                <Subtitle darkText={true}>
                We paint the figures and parts by hand, the details are highlighted and preserved, we give different prices depending on the modell.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={'http://printfusion.nhely.hu/test/anycubicphotonmono.jpg'}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2>
          </InfoRow>
          <Heading lightText={false}>Gallery</Heading>
        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default Paint
