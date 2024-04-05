import React from 'react'
import { Link } from 'react-router-dom';
import { 
  ServicesContainer,
  ServicesCard,
  ServicesH1,
  ServicesIcon,
  ServicesP,
  ServicesWrapper,
  TopLine,
  baseImageUrl
 } from '../TextElements'

const Services = () => {

  function handleClick(event) {
    window.scrollTo({top:0});     
  }

  return (
    <ServicesContainer id="services">
        <ServicesH1>Other services</ServicesH1>
        <ServicesWrapper>
            <Link style={{textDecoration: 'none'}} onClick={handleClick} to={'PaintPage'}>
            <ServicesCard>
                <ServicesIcon src={`${baseImageUrl}svg-1.svg`}/>
                <TopLine>Painting</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
            <Link style={{textDecoration: 'none'}} onClick={handleClick} to={'ElektroplatingPage'}>
            <ServicesCard>
                <ServicesIcon src={`${baseImageUrl}svg-1.svg`}/>
                <TopLine>Elektroplating</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
            <Link style={{textDecoration: 'none'}} onClick={handleClick} to={'ModelltervezesPage'}>
            <ServicesCard>
                <ServicesIcon src={`${baseImageUrl}svg-1.svg`}/>
                <TopLine>Modell designing</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
        </ServicesWrapper>
    </ServicesContainer>
  )
}

export default Services