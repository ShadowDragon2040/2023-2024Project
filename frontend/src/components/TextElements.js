import styled from "styled-components";
import{Link as LinkR} from 'react-router-dom'
import{Link as LinkS} from 'react-scroll'
import { Link } from "react-router-dom";
import { FaTimes } from "react-icons/fa";


export const InfoContainer=styled.div`
    color: #fff;
    background: ${({lightBg})=>(lightBg?'#f9f9f9':'#010606')};

    @media screen and (max-width:768px) {
        padding: 100px 0;

    }
`
export const InfoContainer3=styled.div`
    padding:10px;
    font-size:2em;
    color: #ffffff;
    @media screen and (max-width:768px) {
        padding: 100px 0;
    }
`

export const InfoContainer2=styled.div`
    color: #fff;
    background: ${({lightBg})=>(lightBg?'#f9f9f9':'#010606')};
    padding-bottom:150px;
    @media screen and (max-width:768px) {
        padding: 100px 0;

    }
`
export const CarouselImage=styled.img`
height:25vw;
`


export const SlideContainer=styled.div`
    color: #fff;
    background: ${({lightBg})=>(lightBg?'#f9f9f9':'#010606')};
    @media screen and (max-width:768px) {
        padding: 100px 0;

    }
    width: 300px;
    text-allign: center;
`
export const InfoWrapper =styled.div`
    display: grid;
    z-index: 1;
    height: 660px;
    width:100%;
    max-width: 1600px;
    margin-right: auto;
    margin-left:auto;
    padding:0 24px;
    justify-content: center;
 
`

export const InfoRow=styled.div`
    display:grid;
    grid-auto-columns: minmax(auto, 1fr);
    align-items: center;
    
    grid-template-areas: ${({imgStart})=>(imgStart? `'col2 col1'`:`'col1 col2'`)};  
    
    @media screen and (max-width:768px) {
    grid-template-areas: ${({imgStart})=>(imgStart? `'col1' 'col2'`:`'col2 col2' 'col1 col1'`)};
    

    }
`
export const InfoRow2=styled.div`
    display:grid;
    grid-auto-columns: minmax(auto, 1fr);
    align-items: center;
    
    grid-template-areas: ${({imgStart})=>(imgStart? `'col2 col1 col4 col3'`:`'col2 col1 col3 col4'`)};  
    
    @media screen and (max-width:768px) {
    grid-template-areas: ${({imgStart})=>(imgStart? `'col1' 'col2' 'col4' 'col3'`:`'col1' 'col2' 'col3' 'col4'`)};
    

    }
`
export const Column1 = styled.div`
    margin-bottom: 15px;
    padding: 0 15px;
    grid-area: col1;

`
export const Column2 = styled.div`
    margin-bottom: 15px;
    padding: 0 15px;
    grid-area: col2;`

export const Column3 = styled.div`
    margin-bottom: 15px;
    padding: 0 15px;
    grid-area: col3;`


export const Column4 = styled.div`
    margin-bottom: 15px;
    padding: 0 15px;
    grid-area: col4;
    
`
export const TextWrapper=styled.div`
    max-width: 540px;
    padding-top: 0;
    
  
`
export const TopLine=styled.p`
    color: #01bf71;
    font-size: 18px;
    line-height: 16px;
    font-weight: 700;
    letter-spacing: 1.4px;
    text-transform: uppercase;
    margin-bottom: 16px;
    
`
export const Heading =styled.h1`
    margin-bottom: 24px;
    font-size: 48px;
    line-height: 1.1;
    font-weight: 600;
    padding-top: 100px;
    color: #f7f8fa;
    text-align:center;
    @media screen and (max-width:480px) {
    font-size: 32px;
    }
`
export const Subtitle=styled.p`
    max-width: 440px;
    font-size: 18px;
    line-height: 24px;
    margin-bottom: 35px;
    font-weight: bold;
    text-align: justify;
    
    color: ${({darkText})=>(darkText ? '#f7f8fa' : '#fff')};
   
`
export const BtnWrap=styled.div`
    display: flex;
    justify-content: flex-start;
`
export const ImgWrap=styled.div`
    max-width: 555px;
    height: 100%;
`
export const Img =styled.img`
    margin: 0 0 10px 0;
    padding-right: 0;
    width:100%;
    
`
export const ServicesP=styled.p`
    
    font-size: 1rem;
    text-align: center;
`

export const ServicesP2=styled.p`
    color:red;
    font-size: 1rem;
    text-align: center;
`
export const ServicesCard=styled.div`
    
    background: #fff;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
    border-radius: 10px;
    max-height: 340px;
    padding: 30px;
    box-shadow: 0 1px 3px rgba(0,0,0,0.2);
    transition: all 0.2s ease-in-out;

    &:hover{
        transform: scale(1.02);
        transition: all 0.2s ease-in-out;
        cursor: pointer;
    }

`
export const ServicesCard2=styled.div`
    background: #fff;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
    border-radius: 10px;
    max-width:250px;
    max-height: 340px;
    padding: 30px;
    box-shadow: 0 1px 3px rgba(0,0,0,0.2);
    transition: all 0.2s ease-in-out;

    &:hover{
        transform: scale(1.02);
        transition: all 0.2s ease-in-out;
        cursor: pointer;
    }

`

export const ServicesIcon=styled.img`
    height: 160px;
    width: 160px;
    margin-bottom: 10px;

`

export const ServicesContainer=styled.div`
    display: flex;
    padding-bottom: 210px;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background: #010606;
        @media screen and (max-width: 768px){
            height: 1100px;    
        }
        @media screen and (max-width: 480px){
            height: 1300px;    
        }
`
export const ServicesWrapper=styled.div`
    max-width: 1000px;
    margin: 0 auto;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    align-items: center;
    grid-gap: 16px;
    padding: 50px 0px;

    @media screen and (max-width: 1000px){
        grid-template-columns: 1fr 1fr;    
    }
    @media screen and (max-width: 768px){
        grid-template-columns: 1fr;
        padding:0 20px;
    }

`
export const ServicesH1=styled.h1`
    font-size: 48px;
    line-height: 1.1;
    font-weight: 600;
    padding-top:50px;
    color: #f7f8fa;
    text-align:center;

    @media screen and (max-width: 480px){
        font-size: 2rem;
    }
`
export const NavItem=styled.li`
    height: 80px;
`
export const NavLinks=styled(LinkS)`
    color: #fff;
    display: flex;
    align-items: center;
    text-decoration: none;
    padding: 0 1rem;
    height: 100%;
    cursor: pointer;

    &.active{
        border-bottom: 3px solid #01bf71;
    }
`
export const NavBtn=styled.nav`
    display:inline-flex;
    align-items: center;
    @media screen and (max-width: 768px) {
        display:none;
    }
`

export const NavBtn2=styled.nav`
    margin-left: 10px;
    margin-right: 10px;
    display:inline-flex;
    align-items: center;
    vertical-align: middle;
`

export const ModalButton=styled.button`
    border-radius:50px;
    background:#01bf71;
    white-space:nowrap;
    padding: 10px 22px;
    color:#010606;
    justify-self:end;
    font-size: 16px;
    outline: none;
    border: none;
    cursor: pointer;
    transition: all 0.2s ease-in-out;
    text-decoration:none;
    &:hover{
        transition: all 0.2s ease-in-out;
        background:black;
        color:white;
    }
`

export const NavBtnLink=styled(LinkR)`
    border-radius:50px;
    background:#05a866;
    white-space:nowrap;
    padding: 10px 22px;
    color:#010606;
    justify-self:end;
    font-size: 16px;
    outline: none;
    border: none;
    cursor: pointer;
    transition: all 0.2s ease-in-out;
    text-decoration:none;
    &:hover{
        transition: all 0.2s ease-in-out;
        background:black;
        color:white;
    }
`
export const MobileIcon=styled.div`
    display: none;

    @media screen and (max-width:768px){
        display: block;
        position: absolute;
        top: 0;
        right: 0;
        transform: translate(-100%, 60%);
        font-size: 1.8rem;
        cursor: pointer;  
        color: #fff;   
    }
`
export const NavMenu=styled.ul`
    display: flex;
    align-items: center;
    list-style: none;
    text-align: center;
    margin: -22px;

    @media screen and (max-width:768px){
        display: none;
    }
`

export const NavbarContainer=styled.div`
    justify-content: space-between;
    display:flex;
    height: 80px;
    z-index: 1;
    width: 100%;
    padding: 0 24px ;
    background: linear-gradient(180deg,rgba(0,0,0,0.2) 0%, rgba(0,0,0,0.6) 100%), linear-gradient(180deg,rgba(0,0,0,0.2) 0%,transparent 100%);

`    
export const NavLogo=styled(LinkR)`
    color:#fff;
    cursor: pointer;
    font-size: 1.5rem;
    display: flex;
    align-items:center;
    margin-left: 24px;
    font-weight: bold;
    text-decoration: none;
`
export const Nav=styled.nav`
    background: ${({scrollNav}) => (scrollNav ? '#000' : 'transparent')};
    background: linear-gradient(180deg,rgba(0,0,0,0.2) 0%, rgba(0,0,0,0.6) 100%), linear-gradient(180deg,rgba(0,0,0,0.2) 0%,transparent 100%);
    height:80px;
    margin-top:-80px;
    display:flex;
    justify-content:center;
    align-items: center;
    font-size: 1rem;
    position: sticky;
    top: 0;
    z-index: 10;
    @media screen and (max-width: 960px) {
        transition:0.8s all ease ;
    }
`

export const Nav2=styled.nav`
    background: #024f02;
    height:80px;
    margin-top:-80px;
    display:flex;
    justify-content:center;
    align-items: center;
    font-size: 1rem;
    position: sticky;
    top: 0;
    z-index: 10;
    @media screen and (max-width: 960px) {
        transition:0.8s all ease ;
    }
`

export const HeroContainer=styled.div`
    background: green;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 0 30px;
    height: 950px;
    position: relative;
    z-index: 1;

    :before{
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background: linear-gradient(180deg,rgba(0,0,0,0.2) 0%,
        rgba(0,0,0,0.6) 100%),
        linear-gradient(180deg,rgba(0,0,0,0.2) 0%, transparent 100%);
    }
`
export const ShopPageContainer=styled.div`
    background: black;
`

export const HeroContent=styled.div`
 z-index: 3;
 max-width: 1200px;
 position: absolute;
 padding: 8px 24px;
 display: flex;
 flex-direction: column;
 align-items: center;
`

export const HeroH1=styled.h1`
    color: #fff;
    font-size: 52px;
    text-align: center;
    font-weight: 700;
    @media screen and (max-width:768px) {
     font-size:40px ;
    }
    @media screen and (max-width:480px) {
     font-size:32px ;
    }
`

export const HeroP=styled.p`
 margin-top: 24px;
 font-size: 24px;
 color: #fff;
 text-align:center;
 max-width: 600px;

 @media screen and (max-width:768px) {
     font-size:24px ;
    }
    @media screen and (max-width:480px) {
     font-size:18px ;
    }
`
export const CarouselContainer = styled.div`
    margin-top:15%;
    width:90%;
    border-radius:20px;
    background-color:#059e60;
     @media screen and (max-width:700px) {
        display:none;
    }
`
export const ItemContainer=styled.div`
        position:relative;
        display:inline-block;
        margin:auto;
        margin-top:5%;
        float:right;
    @media screen and (max-width:700px) {
        margin-top:80px;
        width:60%
    }
`


export const FooterContainer=styled.footer`
    bottom:0px;
    position:relative;
    z-index:10;
    background-color: #101522;
`

export const FooterWrap =styled.div`
    padding: 20px 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    max-width: 1100px;
    margin: 0 auto;
`
export const FooterLinksContainer =styled.div`
    display: flex;
    justify-content: center;

    @media screen and (max-width: 820px){
        padding-top: 25px;
    }

`

export const FooterLinksWrapper =styled.div`
    display: flex;

    @media screen and (max-width: 820px){
        flex-direction: column;
    }

`

export const FooterLinkItems =styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 16px;
    text-align: left;
    width: 160px;
    box-sizing: border-box;
    color: #fff;

    @media screen and (max-width: 420px){
        margin: 0;
        padding: 5px;
        width: 100%;
    }
`

export const FooterLinkTitle =styled.h1`
    font-size: 14px;
    margin-bottom: 10px;
`

export const FooterLink =styled(Link)`
    color: #fff;
    text-decoration: none;
    margin-bottom: 0.5rem;
    font-size: 14px;

    &:hover{
        color: #01bf71;
        transition: 0.3s ease-out;
    }
`

export const SocialMedia =styled.section`
    max-width: 1000px;
    width: 100%;
`

export const SocialMediaWrap =styled.div`
    display: flex;
    justify-content: space-between;
    align-items: center;
    max-width: 1100px;
    margin: 40px auto 0 auto;

    @media screen and (max-width: 820px){
        flex-direction: column;
    }

`

export const SocialLogo =styled(Link)`
    color: #fff;
    justify-self: start;
    cursor: pointer;
    text-decoration: none;
    font-size: 1.5rem;
    display: flex;
    align-items: center;
    margin-bottom: 16px;
    font-weight: bold;
`

export const WebsiteRights =styled.small`
    color: #fff;
    margin-bottom: 16px;
`

export const SocialIcons =styled.div`
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 240px;
`

export const SocialIconLink =styled.a`
    color: #fff;
    font-size: 24px;
`

export const SidebarContainer=styled.aside`
    position:fixed;
    z-index: 10;
    width:100%;
    height:100%;
    background:#0d0d0d;
    display:grid;
    align-items:center;
    top: 0;
    left: 0;
    transition: 0.3s ease-in-out;
    opacity: ${({isOpen}) => (isOpen ? '100%' : '0')};
    top: ${({isOpen}) => (isOpen ? '0' : '-100%')};
`
export const ShopSidebarContainer=styled.aside`
    font-size: 20px;
    text-style: bold;
    margin-top:80px;
    height:100%;
    left:0px;
    position:fixed;
    
`

export const ProfileDisplayPageContainer=styled.aside`
    width:16%;
    margin-top:80px;
    float:right;
    position:absolute;
    z-index:5;
    height:100%;
    right:0px;
    padding:25px;
    background: linear-gradient(180deg,rgba(0,0,0,0.2) 0%, rgba(0,0,0,0.6) 100%), linear-gradient(180deg,rgba(0,0,0,0.2) 0%,transparent 100%);
`


export const CloseIcon=styled(FaTimes)`
    color: #fff;

`

export const Icon=styled.div`
    position: absolute;
    top: 1.2rem;
    right: 1.5rem;
    background: transparent;
    font-size: 2rem;
    cursor: pointer;
    outline: none;

`
export const SidebarWrapped=styled.div`
    color: #fff;

`
export const SidebarMenu=styled.ul`
    display: grid;
    grid-template-columns:1fr;
    grid-template-rows:repeat(6,80px);
    text-align: center;

    @media screen and (max-width:480px){
        grid-template-rows:repeat(6,60px);
    }

`
export const SidebarLink=styled(LinkS)`
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 1.5rem;
    text-decoration: none;
    list-style: none;
    transition: 0.2s ease-in-out;
    color: #fff;
    cursor: pointer;

    &:hover{
        color: #01bf71;
        transition: 0.2s ease-in-out;
    }

`
export const SideBtnWrap=styled.div`
    display: flex;
    justify-content: center;

`
export const SidebarRoute=styled(LinkR)`
    border-radius: 50px;
    background: #01bf71;
    white-space:nowrap;
    padding: 16px 64px;
    color: #010606;
    font-size:16px;
    outline: none;
    border: none;
    cursor: pointer;
    transition: all 0.2s ease-in-out;
    text-decoration: none;

    &:hover{
        transition: all 0.2s ease-in-out;
        background: #fff;
        color: #010606;
    }

`
