import React, { useEffect } from 'react'
import { FaFacebook } from 'react-icons/fa'
import { animateScroll as scroll } from 'react-scroll'
import {
    FooterContainer,
    FooterLink,
    FooterLinkItems,
    FooterLinkTitle,
    FooterLinksContainer,
    FooterLinksWrapper,
    FooterWrap,
    SocialIcons,
    SocialIconLink,
    SocialMedia,
    SocialMediaWrap,
    SocialLogo,
    WebsiteRights
} from './TextElements'
import { useState } from 'react'
const Footer = (props) => {
    const toggleHome=()=>{
        scroll.scrollToTop();
    };

    const [isButtom, setIsButtom] = useState(false);

    useEffect(() => {
        if(props.isButtom){
         setIsButtom(props.isButtom);
        }
    }, [props.isButtom])
    


  return (
    <FooterContainer style={{zIndex:"10", position:isButtom ? "fixed" : "relative", bottom: isButtom ? "0" : "auto", width:"100%"}}>
        <FooterWrap>
            <FooterLinksContainer>
                <FooterLinksWrapper>
                    <FooterLinkItems>
                        <FooterLinkTitle>Join us</FooterLinkTitle>
                        <FooterLink to="/signin">About us</FooterLink>
                    </FooterLinkItems>
                </FooterLinksWrapper>
            </FooterLinksContainer>
            <SocialMedia>
                <SocialMediaWrap>
                    <SocialLogo to='/' onClick={toggleHome}>
                        PrintFusion
                    </SocialLogo>
                     <WebsiteRights>PrintFusion {new Date().getFullYear()}</WebsiteRights>
                      <SocialIcons>
                        <SocialIconLink href="/" target="_blank"
                        aria-label="Facebook"></SocialIconLink>
                        <FaFacebook/>
                      </SocialIcons>
                      <SocialIcons>
                        <SocialIconLink href="/" target="_blank"
                        aria-label="Facebook"></SocialIconLink>
                        <FaFacebook/>
                      </SocialIcons>
                </SocialMediaWrap>
            </SocialMedia>
        </FooterWrap>
    </FooterContainer>
  )
}

export default Footer