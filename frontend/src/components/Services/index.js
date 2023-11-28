import React from 'react'
import Icon1 from '../../images/svg-1.svg'
import { Link } from 'react-router-dom';
import { 
  ServicesContainer,
  ServicesCard,
  ServicesH1,
  ServicesIcon,
  ServicesP,
  ServicesWrapper,
  TopLine
 } from '../TextElements'

const Services = () => {

  function handleClick(event) {
    window.scrollTo({top:0});     
  }

  return (
    <ServicesContainer id="services">
        <ServicesH1>Utómunkák</ServicesH1>
        <ServicesWrapper>
            <Link onClick={handleClick} to={'PaintPage'}>
            <ServicesCard>
                <ServicesIcon src={Icon1}/>
                <TopLine>Festés</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
            <Link onClick={handleClick} to={'ElektroplatingPage'}>
            <ServicesCard>
                <ServicesIcon src={Icon1}/>
                <TopLine>Elektroplating</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
            <Link onClick={handleClick} to={'ModelltervezesPage'}>
            <ServicesCard>
                <ServicesIcon src={Icon1}/>
                <TopLine>Modelltervezés</TopLine>
                <ServicesP></ServicesP>
            </ServicesCard>
            </Link>
        </ServicesWrapper>
    </ServicesContainer>
  )
}

export default Services