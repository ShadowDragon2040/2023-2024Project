import React from 'react'
import {
InfoContainer4,
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

const ModelSection = () => {
  
  return (
      <InfoContainer4  lightBg={false}  >
        <Heading id={'models'} lightText={false}>3D Modells</Heading>
        <InfoWrapper>
          <InfoRow  imgStart={false} >
            <Column1>
            <TextWrapper>
             <TopLine></TopLine>
              <Subtitle darkText={true}>
              The 3D models needed for 3D printing can be obtained from various sites, among the most well-known are MyMiniFactory and Thingiverse, where you can also obtain free downloadable models. The most common 3D model format is STL, where possible the models are entered in this format. On special request, we can change a 3D model to your liking, the price of this may vary depending on the model.
              </Subtitle>
            </TextWrapper>
            </Column1>
             <Column2>
              <ImgWrap>
                  <Img
                    src={'http://printfusion.nhely.hu/test/anycubicphotonmono.jpg'}
                    alt={'Our Company'}
                  />
              </ImgWrap>
            </Column2> 
          </InfoRow>
        </InfoWrapper>
      </InfoContainer4>
  )
}

export default ModelSection
