import React from 'react'
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
} from '../TextElements'
const Footer = () => {
    const toggleHome=()=>{
        scroll.scrollToTop();
    };
  return (
    <FooterContainer>
        <FooterWrap>
            <FooterLinksContainer>
                <FooterLinksWrapper>
                    <FooterLinkItems>
                        <FooterLinkTitle>Csatlakozz</FooterLinkTitle>
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