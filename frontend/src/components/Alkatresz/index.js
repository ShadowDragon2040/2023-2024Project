import React from 'react'
import {
InfoContainer,
InfoWrapper,
Heading,
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

const Alkatresz = () => {
  return (
    <>
      <InfoContainer  lightBg={false} id={'Alkatresz'} >
        <Heading lightText={false}>Alkatrészek</Heading>
        <InfoWrapper>

        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default Alkatresz
