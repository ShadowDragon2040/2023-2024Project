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

const Szemuveg = () => {
  return (
    <>
      <InfoContainer  lightBg={false} id={'Szemuveg'} >
        <Heading lightText={false}>Szemüvegek</Heading>
        <InfoWrapper>

        </InfoWrapper>
      </InfoContainer>
    </>
  )
}

export default Szemuveg
