import React from 'react';
import { MdArrowBack } from "react-icons/md";
import {NavBtn,NavBtnLink} from '../TextElements';
import {
InfoContainer15,
InfoWrapper,
InfoRow,
Column1,
Column2,
Heading,
ImgWrap,
TopLine,
Img,
Subtitle
} from '../TextElements';

const Paint = () => {
  return (
    <>
      <InfoContainer15  lightBg={false} id={'Paint'} >
        <Heading lightText={false}>Painting</Heading>
          <NavBtn style={{margin:'20px 0px 20px 200px'}}>
            <NavBtnLink to='/'><MdArrowBack/>Back</NavBtnLink>
          </NavBtn>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1 style={{position: 'relative'}}>
              <ImgWrap>
                  <Img
                    src={`${process.env.REACT_APP_KEP_URL}SprayPainting.jpg`}
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
                    src={`${process.env.REACT_APP_KEP_URL}HandPainting.jpg`}
                  />
              </ImgWrap>
            </Column2>
          </InfoRow>
        </InfoWrapper>
      </InfoContainer15>
    </>
  )
}

export default Paint
