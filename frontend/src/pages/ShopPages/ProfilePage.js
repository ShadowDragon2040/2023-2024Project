import React, { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import {
  InfoContainer10
} from '../../components/TextElements';

function ProfilePage() {

  return (
    <>
      <Navbar/>
      <InfoContainer10>
        <p>valami</p>
      </InfoContainer10>
      <Footer/>
    </>
  );
}

export default ProfilePage;