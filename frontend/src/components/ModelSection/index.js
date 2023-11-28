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
Img
} from '../TextElements'

export const homeObjOne={
  id:'about',
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
const ModelSection = () => {
  
  return (
    <>
    
      <InfoContainer  lightBg={false} id={'models'} >
        <Heading lightText={false}>3D Modellek</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper>
             <TopLine></TopLine>
              <Subtitle darkText={true}>
              A 3D nyomtatáshoz szükséges 3D modelleket be lehet szerezni különböző oldalakon, a legismertebbek között van a MyMiniFactory és a Thingiverse ahol ingyen letölthető modelleket is be lehet szerezni. A leggyakoribb 3D modell formátum az STL, lehetőség szerint ebben adják meg a modelleket. Külön kérésre egy 3D modellt megváltoztathatunk tetszés szerint, ennek modellenként változó ára lehet.
              </Subtitle>
            </TextWrapper>
            </Column1>
             <Column2>
              <ImgWrap>
              <Img src={require('../../images/industar-kft-front.jpg')} alt={'cég'}/>
              </ImgWrap>
            </Column2> 
          </InfoRow>
        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default ModelSection
