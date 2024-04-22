import React, { useState } from 'react';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import {
  InfoContainer10
} from '../../components/TextElements';

function ProfilePage() {

  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [showProfile, setShowProfile] = useState(false);

  const handleProfileClick = () => {
   
    setUsername('teszt_user');
    setEmail('teszt_user@example.com');
    setShowProfile(true);
  };

  const profileCardStyle = {
    backgroundColor: '#fff',
    boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)',
    borderRadius: '5px',
    padding: '20px',
    marginBottom: '20px',
    maxWidth: '400px',
    margin: 'auto'
  };
  
  const headingStyle = {
    textAlign: 'center',
    color: '#333'
  };
  
  const hrStyle = {
    border: '0',
    borderTop: '1px solid #eee',
    marginTop: '10px',
    marginBottom: '10px'
  };
  
  const labelStyle = {
    fontWeight: 'bold',
    marginRight: '5px',
    color: 'black'
  };
  

  return (
    <>
      <Navbar/>
      <InfoContainer10>
        <button onClick={handleProfileClick}>Profil megtekintése</button>
        {showProfile && (
          <div style={profileCardStyle}>
            <h2 style={headingStyle}>Profil információk</h2>
            <hr style={hrStyle} />
          
            <p style={labelStyle}><strong style={labelStyle}>Felhasználónév:</strong> {username}</p>
            <p style={labelStyle}><strong style={labelStyle}>Email:</strong> {email}</p>
          </div>
        )}
      </InfoContainer10>
      <Footer/>
    </>
  );
}

export default ProfilePage;

