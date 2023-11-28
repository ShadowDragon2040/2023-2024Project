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
                  <Img></Img>
                </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
            <TopLine>Spray festés</TopLine>
                <Subtitle darkText={true}>
                Spray festéssel egyszínű egyenletes festékréteget tudunk készíteni, ajánlott a burkolati elemeknél és az otthoni díszeknél.
                </Subtitle>
            </Column2>
          </InfoRow>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine>Kézi festés</TopLine>
                <Subtitle darkText={true}>
                Kézi festéssel a figurákat és a bábúkat festjük le, a részleteket kiemeli és megtartja, a részletességtől fűggően eltérő árakat adunk.
                </Subtitle>
            </Column1>
            <Column2 style={{position: 'relative'}}>
                <ImgWrap>
                  <Img></Img>
                </ImgWrap>
            </Column2>
          </InfoRow>
          <Heading lightText={false}>Galléria</Heading>
        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default Paint
