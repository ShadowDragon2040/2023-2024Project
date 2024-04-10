import React from 'react'
import { useState } from 'react';
import { Link } from 'react-router-dom';
import {
InfoContainer2,
InfoWrapper,
InfoRow,
Column1,
Column2,
TopLine,
Heading,
ImgWrap,
Img
} from '../TextElements'

const PrinterTools = () => {
  const [TopLeftHovered, setTopLeftHovered] = useState(false);
  const [TopRightHovered, setTopRightHovered] = useState(false);
  const [BottomLeftHovered, setBottomLeftHovered] = useState(false);
  const [BottomRightHovered, setBottomRightHovered] = useState(false);

  function handleClick(event) {
  window.scrollTo({top:0});     
}

  return (
    <>
      <InfoContainer2  lightBg={false} id={'tools'} >
        <Heading lightText={false}>Our printers</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine style={{
              position: "absolute",
              top: "50%",
              left: "50%",
              transform: "translate(-50%,-50%)",
              visibility: TopLeftHovered ? 'hidden' : 'visible',
              textAlign: 'center',
              textShadow: "4px 2px 2px black",
              zIndex: 1
            }}>Ender 3 V2</TopLine>
            <ImgWrap>
            <Link onClick={handleClick} to="/Ender">
                <Img
                  src={`${process.env.REACT_APP_KEP_URL}Ender3V2.jpg`}
                  alt={'Ender3V2'}
                  onMouseEnter={() => setTopLeftHovered(true)}
                  onMouseLeave={() => setTopLeftHovered(false)}
                  style={{
                    filter: TopLeftHovered ? "blur(0px)" : "blur(3px)",
                    width: "100%",
                    height: "auto",
                  }}
                />
              </Link>
            </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
             <TopLine style={{
              position: "absolute",
              top: "50%",
              left: "50%",
              transform: "translate(-50%,-50%)",
              visibility: TopRightHovered ? 'hidden' : 'visible',
              textAlign: 'center',
              textShadow: "4px 2px 2px black",
              zIndex: 1
            }}>Anycubic photon mono</TopLine>
              <ImgWrap>
              <Link onClick={handleClick} to="/Anycubic">
                <Img
                  src={`${process.env.REACT_APP_KEP_URL}anycubicphotonmono.jpg`}
                  alt={'anycubic photon mono'}
                  onMouseEnter={() => setTopRightHovered(true)}
                  onMouseLeave={() => setTopRightHovered(false)}
                  style={{
                    filter: TopRightHovered ? "blur(0px)" : "blur(3px)",
                    width: "100%",
                    height: "auto",
                  }}
                />
              </Link>
              </ImgWrap>
            </Column2>
          </InfoRow>

          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
            <TopLine style={{
              position: "absolute",
              top: "50%",
              left: "50%",
              transform: "translate(-50%,-50%)",
              visibility: BottomLeftHovered ? 'hidden' : 'visible',
              textAlign: 'center',
              textShadow: "4px 2px 2px black",
              zIndex: 1
            }}>Bambu Carbon X1</TopLine>
            <ImgWrap>
            <Link onClick={handleClick} to="/Bambu">
                <Img
                  src={`${process.env.REACT_APP_KEP_URL}bambucarbonmain.jpg`}
                  alt={'Bambu Carbon X1'}
                  onMouseEnter={() => setBottomLeftHovered(true)}
                  onMouseLeave={() => setBottomLeftHovered(false)}
                  style={{
                    filter: BottomLeftHovered ? "blur(0px)" : "blur(3px)",
                    width: "100%",
                    height: "auto",
                  }}
                />
              </Link>
            </ImgWrap>
            </Column1>
            <Column2 style={{position: 'relative'}}>
             <TopLine style={{
              position: "absolute",
              top: "50%",
              left: "50%",
              transform: "translate(-50%,-50%)",
              visibility: BottomRightHovered ? 'hidden' : 'visible',
              textAlign: 'center',
              textShadow: "4px 2px 2px black",
              zIndex: 1
            }}>Elegoo Saturn 3</TopLine>
              <ImgWrap>
              <Link onClick={handleClick} to="/Anycubic">
                <Img
                  src={`${process.env.REACT_APP_KEP_URL}anycubicphotonmono.jpg`}
                  alt={'Elegoo Saturn 3'}
                  onMouseEnter={() => setBottomRightHovered(true)}
                  onMouseLeave={() => setBottomRightHovered(false)}
                  style={{
                    filter: BottomRightHovered ? "blur(0px)" : "blur(3px)",
                    width: "100%",
                    height: "auto",
                  }}
                />
              </Link>
              </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer2>
    </>
  )
}

export default PrinterTools
