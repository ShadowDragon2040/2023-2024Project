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
NavBtnLink
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
const InfoSection = () => {
  
  return (
    <>
      <InfoContainer  lightBg={false} id={'about'} >
        <Heading lightText={false}>A Cégünkről</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper> 
             <TopLine></TopLine>
              <Subtitle darkText={true}>
              A cégnél hisszük hogy a képzelet a határ, a 3D nyomtatási technológiával ez meg is oldható. Mindenkinek tudunk valamit ajánlani és akinek valami egyedi kell, azt reméljük hogy biztosítani tudjuk. Nézzen körbe az oldalunkon és válassza ki ami önnek tetszik, ha nem találja külde el e-mail-ben mit szeretne. 3D nyomtatáson kívűl foglalkozunk festéssel és elektroplaing-el. 
              </Subtitle>
            </TextWrapper>
            <NavBtn>
              <NavBtnLink  to='CompanyInfoPage'>About us</NavBtnLink>
            </NavBtn>
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

export default InfoSection
