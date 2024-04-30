import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import Form from 'react-bootstrap/Form';
import { MdArrowBack } from "react-icons/md";
import {
  InfoContainer,
  NiceButton,
  NavBtnLink,
  NavBtn
} from '../../components/TextElements';
import {Accordion, Modal, Button, Row, Col, Image} from 'react-bootstrap';
import { toast } from 'react-toastify';



function ProfilePage() {
  const [userProfile, setUserProfile] = useState(null);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [editedLocation, setEditedLocation] = useState(null);
  const [showDeleteConfirmationModal, setShowDeleteConfirmationModal] = useState(false);

  const [avatarChangeModal,setAvatarChangeModal]=useState(false);
  const [selectedAvatar, setSelectedAvatar] = useState(null);
  const[avatarChoices,setAvatarChoices]=useState(null);

  const[emailCode,setEmailCode]=useState(null);
  const[changedPassword,setChangedPassword]=useState("");
  const[changedPasswordAgain,setChangedPasswordAgain]=useState("");
  const [error, setError] = useState('');

  const [userHelyadat, setUserHelyadat] = useState(null);
  const [userComments, setUserComments] = useState(null);
  const [userCommentProduct, setUserCommentProduct] = useState(null);
  const [userSzamlak, setUserSzamlak] = useState(null);

  const [userCountry, setUserCountry] = useState('');
  const [userCity, setUserCity] = useState('');
  const [userStreet, setUserStreet] = useState('');
  const [userZipCode, setUserZipCode] = useState('');
  const [userStreetNumber, setUserStreetNumber] = useState('');
  const [userOther, setUserOther] = useState('');

  const [collapseOneOpen, setCollapseOneOpen] = useState(false);
  const [collapseTwoOpen, setCollapseTwoOpen] = useState(false);

  const toggleCollapseOne = () => {
    setCollapseOneOpen(!collapseOneOpen);
  };

  const toggleCollapseTwo = () => {
    setCollapseTwoOpen(!collapseTwoOpen);
  };
  
  const userId = localStorage.getItem("userId");
  const token=localStorage.getItem("LoginToken")



  const validateForm = () => {

    if (parseInt(emailCode)!==parseInt(userProfile.emailCode)) {
      setError('Email code not match.');
      //console.log(userProfile.emailCode);
      return false;
    }

    if (changedPassword===""||changedPasswordAgain==="") {
      setError('Password cannot be null.');
      return false;
    }
  
    if (changedPassword !== changedPasswordAgain) {
      setError('Passwords do not match.');
      return false;
    }
    setError('');
    return true;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    
    if (validateForm()) {
      axios.post(`${process.env.REACT_APP_BASE_URL}Auth/updatepassword/`, {
        email: userProfile.email,
        emailCode:parseInt( emailCode),
        newPassword: changedPassword
      }, {
        headers: {
          Authorization: 'Bearer ' + token
        }
      })
      .then(response => {
        if (response.status === 200) {
          toast.success("Successfully changed password!");
        } else {
          toast.error("Failed to change password. Please try again.");
        }
      })
      .catch(error => {
        console.error("Error changing password:", error);
        toast.error("An error occurred. Please try again later.");
      });
    }
  };
  

  const handleClose = () =>{ 

    setAvatarChangeModal(false);
    setSelectedAvatar(null);
  } 

  const handleShow = () => setAvatarChangeModal(true);


  const handleAvatarSelection = (index) => {
    setSelectedAvatar(avatarChoices[index].url);
  };
  
  const handleSaveAvatar = async () => {
    try {
      //console.log("Selected avatar:", selectedAvatar);
      const response = await axios.put(
        `${process.env.REACT_APP_BASE_URL}Felhasznalok/${userId}`,
        {
          userName: userProfile.userName,
          passwordHash: userProfile.passwordHash,
          emailConfirmed: userProfile.emailConfirmed,
          email: userProfile.email,
          profilKep: selectedAvatar
        },
        {
          headers: {
            Authorization: 'Bearer ' + token
          }
        }
      );
      //console.log(response);
      handleClose();
    } catch (error) {
      console.error('Error saving avatar:', error);
    }
  };

    useEffect(() => {
      const fetchUserProfile = async () => {
        try {
          const response = await axios.get(`${process.env.REACT_APP_BASE_URL}Felhasznalok/${userId}`,{
            headers:{'Authorization': 'Bearer ' + token}
          });
          setUserProfile(response.data[0]);
        } catch (error) {
          console.error('Error fetching user profile:', error);
        }
      };
    
      fetchUserProfile();
    }, [selectedAvatar,token,userId]);
    
    useEffect(() => {
      const fetchUserHelyadat = async () => {
        try {
          const response = await axios.get(`${process.env.REACT_APP_BASE_URL}Helyadatok/${userId}`,{
            headers:{'Authorization': 'Bearer ' + token}
          });
          setUserHelyadat(response.data[0]);
        } catch (error) {
          console.error('Error fetching user helyadat:', error);
        }
      };
    
      if (userId) { // Add this condition to avoid unnecessary requests when userId is null
        fetchUserHelyadat();
      }
    },[userId, token]);
    
    useEffect(() => {
      const fetchAvatars = async () => {
        try {
          const avatarCount = 9;
          const avatarURLs = Array.from({ length: avatarCount }, (_, index) => {
            const avatarNumber = index + 1;
            return {
              url: `${process.env.REACT_APP_AVATAR_URL}/avatar${avatarNumber}.png`,
              selected: false
            };
          });
          setAvatarChoices(avatarURLs);
        } catch (error) {
          console.error('Error fetching avatars:', error);
        }
      };
  
      fetchAvatars();
    }, []);

  const openModal = (location) => {
    if (location) {
      setEditedLocation(location);
      setUserCountry(location.orszagNev);
      setUserCity(location.varosNev);
      setUserStreet(location.utcaNev);
      setUserZipCode(location.iranyitoszam);
      setUserStreetNumber(location.hazszam);
      setUserOther(location.egyeb);
    } else {
      setEditedLocation(null);
      setUserCountry('');
      setUserCity('');
      setUserStreet('');
      setUserZipCode('');
      setUserStreetNumber('');
      setUserOther('');
    }
    setModalIsOpen(true);
  }

  const closeModal = () => {
    setModalIsOpen(false);
    setShowDeleteConfirmationModal(false);
  }

  const handleAddLocation = async () => {
    try {
      const response = await axios.post(
        `${process.env.REACT_APP_BASE_URL}Helyadatok`,
        {
          userId: userId,
          orszagNev: userCountry,
          varosNev: userCity,
          utcaNev: userStreet,
          iranyitoszam: userZipCode,
          hazszam: userStreetNumber,
          egyeb: userOther
        },
        {
          headers: {
            "Content-Type": "application/json",
            'Authorization': 'Bearer ' + token

          }
        }
      );
      setUserHelyadat(response.data);
    } catch (error) {
      console.error('Error adding location:', error);
    }
    closeModal();
  }
  

  const handleEditLocation = async () => {
    try {
      const response = await axios.put(
        `${process.env.REACT_APP_BASE_URL}Helyadatok/${editedLocation.id}`,
        {
          userId: userId,
          orszagNev: userCountry,
          varosNev: userCity,
          utcaNev: userStreet,
          iranyitoszam: userZipCode,
          hazszam: userStreetNumber,
          egyeb: userOther
        },
        {
          headers: {
            "Content-Type": "application/json",
            'Authorization': 'Bearer ' + token
          }
        }
      );
      setUserHelyadat(response.data);
    } catch (error) {
      console.error('Error editing location:', error);
    }
    closeModal();
  }  

  const handleDeleteLocation = async () => {
    setShowDeleteConfirmationModal(true);
  }

  const confirmDeleteLocation = async () => {
    try {
      await axios.delete(`${process.env.REACT_APP_BASE_URL}Helyadatok/${userHelyadat.id}`,
      {headers:{'Authorization': 'Bearer ' + token}});
      setUserHelyadat(null);
    } catch (error) {
      console.error('Error deleting location:', error);
    }
    closeModal();
  }

  useEffect(() => {
    const fetchUserComments = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_BASE_URL}Hozzaszolas/${userId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        });
        
        setUserComments(response.data);
        //console.log(response.data);
        
        const termekResponse = await axios.get(`${process.env.REACT_APP_BASE_URL}Termekek/EgyTermek/${response.data[0].termekId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        });
        
        setUserCommentProduct(termekResponse.data);
        //console.log(termekResponse.data);
      } catch (error) {
        console.error('Error fetching user Comments:', error);
      }
    };

    fetchUserComments();
  }, [userId, token]); 


  useEffect(() => {
    const fetchUserSzamlak = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_BASE_URL}Szamlazas/${userId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        });
        setUserSzamlak(response.data);
      } catch (error) {
        console.error('Error fetching user szamlak:', error);
      }
    };

    fetchUserSzamlak();
  },[userId,token]);

  return (
      <InfoContainer>
      <Navbar />
        <div style={{padding: '80px', textAlign: 'left'}}>
        <NavBtn style={{margin: '20px 0px 20px 0px'}}>
          <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
        </NavBtn>
        
        <Modal show={avatarChangeModal} onHide={handleClose} dialogClassName='avatar-modal'>
          <Modal.Header closeButton>
            <Modal.Title>Set Avatar</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <Row>
              {/* Display current avatar on the left side */}
              <Col md={4} className='border mx-auto rounded'>
                <h5>Current Avatar</h5>
                {userProfile && (
                  <Image src={userProfile.profilKep} roundedCircle style={{ width: '200px', marginBottom: '10px' }} />
                )}
              </Col>
              {/* Display avatar choices on the right side */}
              <Col md={8}>
                <h5>Choose Avatar</h5>
                <Row>
                  {/* Map through avatar choices and display each */}
                  {avatarChoices&&avatarChoices.map((avatar, index) => (
                      <Col key={index} xs={4} style={{ marginBottom: '10px' }}>
                        <Image
                          src={avatar.url}
                          roundedCircle
                          style={{
                            cursor: 'pointer',
                            width: avatar.selected ? '110px' : '100px', 
                          }}
                          onClick={() => handleAvatarSelection(index)}
                        />
                      </Col>
                    ))}
                </Row>
              </Col>
            </Row>
          </Modal.Body>
          <Modal.Footer>
            {/* Button to save the selected avatar */}
            <Button variant="primary" onClick={handleSaveAvatar}>
              Save Avatar
            </Button>
            {/* Button to close the modal */}
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>
         
        <div className='container' style={{minHeight:'600px'}}>
          
          <div className='row'>
            <div className='col rounded' style={{backgroundColor: '#05a866',maxHeight:'400px'}}>
            {userProfile && (
              <Image src={userProfile.profilKep} onClick={handleShow} style={{maxWidth:"350px"}} alt='Profile Image' fluid roundedCircle/>
            )}
            </div>
            <div className='col'>
                {userProfile && (
                <>
                  <h2><strong>Profile of  {userProfile.userName}</strong></h2>
                  <p><strong>Email:</strong> {userProfile.email}</p>
                  <p><strong>Email Confirmed:</strong> {userProfile.emailConfirmed ? 'Yes' : 'No'}</p>
                  {userHelyadat ? (
                    <div key={userHelyadat.id}>
                      <p><strong>Country:</strong> {userHelyadat.orszagNev}</p>
                      <p><strong>City:</strong> {userHelyadat.varosNev}</p>
                      <p><strong>Postal Code:</strong> {userHelyadat.iranyitoszam}</p>
                      <p><strong>Street and House Number:</strong> {userHelyadat.utcaNev} {userHelyadat.hazszam}</p>
                      {userHelyadat.egyeb !== '' && (
                        <p><strong>Other:</strong> {userHelyadat.egyeb}</p>
                      )}
                      <NiceButton onClick={() => openModal(userHelyadat)}>Change Location</NiceButton>
                      <NiceButton style={{margin: '20px'}} onClick={handleDeleteLocation}>Delete Location</NiceButton>
                    </div>
                  ) : (
                    <NiceButton onClick={() => openModal()}>Add Location</NiceButton>
                  )}
                </>
              )}
            </div>
            <div className='col rounded' style={{backgroundColor: '#05a866'}}>
            <Accordion className='w-100 mx-auto rounded mt-4 p-3'>
              <Accordion.Item eventKey="0" style={{border:'2px solid black'}}>
              <Accordion.Header>Your Comments</Accordion.Header>
              <Accordion.Body>
              {userComments&&userCommentProduct && userComments.map(comment => (
                      <div className="comment-card" key={comment.hozzaszolasId}>
                        <p><strong>Comment ID:</strong> {comment.hozzaszolasId}</p>
                        <p><strong>Product name:</strong> {userCommentProduct.termekNev}</p>
                        <p><strong>Description:</strong> {comment.leiras}</p>
                        <p><strong>Rating:</strong> {comment.ertekeles}</p>
                        <hr style={{border: '2px solid #05a866'}}></hr>
                      </div>
                    ))}      
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="1" style={{border:'2px solid black'}}>
              <Accordion.Header >Your Invoices</Accordion.Header>
              <Accordion.Body>
              {userSzamlak && userSzamlak.map(invoice => (
                      <div className="invoice-card" key={invoice.szamlazasId}>
                        <h3>Invoice</h3>
                        <p><strong>User ID:</strong> {invoice.userId}</p>
                        <p><strong>Product ID:</strong> {invoice.termekId}</p>
                        <p><strong>Color:</strong> {invoice.szinHex}</p>
                        <p><strong>Quantity:</strong> {invoice.darab}</p>
                        <p><strong>Purchase Time:</strong> {new Date(invoice.vasarlasIdopontja).toLocaleString()}</p>
                        <p><strong>Successful Delivery:</strong> {invoice.sikeresSzalitas ? 'Yes' : 'No'}</p>
                      </div>
                    ))}
              </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="2" style={{border:'2px solid black'}}>
              <Accordion.Header  >Change Password</Accordion.Header>
              <Accordion.Body>
                  <Form className='p-1' onSubmit={handleSubmit}>
                  <Form.Group controlId="changedPassword">
                  <Form.Label>Email Code:</Form.Label>
                    <Form.Control
                      style={{ border: "2px solid black" }}
                      type="number"
                      min={1000}
                      max={9999}
                      value={emailCode}
                      onChange={(e) => setEmailCode(e.target.value)}
                    />
                    <Form.Label>New Password:</Form.Label>
                    <Form.Control
                      style={{ border: "2px solid black" }}
                      type="password"
                      value={changedPassword}
                      onChange={(e) => setChangedPassword(e.target.value)}
                    />
                    <Form.Label>Confirm New Password:</Form.Label>
                    <Form.Control
                      style={{ border: "2px solid black" }}
                      type="password"
                      value={changedPasswordAgain}
                      onChange={(e) => setChangedPasswordAgain(e.target.value)}
                    />
                  </Form.Group>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <Button className='btn btn-success' type="submit">Submit</Button>
              </Form>
              </Accordion.Body>
            </Accordion.Item>
          </Accordion>
            
            </div>
          </div>
        </div>
          
          {!userProfile && <p>Loading...</p>}
       
      </div>

        <Modal show={modalIsOpen} onHide={closeModal}>
          <Modal.Header closeButton>
            <Modal.Title>{editedLocation ? 'Edit Location' : 'Add Location'}</Modal.Title>
          </Modal.Header>
          <Form>
            <Modal.Body>
              <Form.Group controlId="formCountry">
                <Form.Label>Country:</Form.Label>
                <Form.Control type="text" placeholder="Enter country" value={userCountry} onChange={(e) => setUserCountry(e.target.value)} />
              </Form.Group>
              <Form.Group controlId="formCity">
                <Form.Label>City:</Form.Label>
                <Form.Control type="text" placeholder="Enter city" value={userCity} onChange={(e) => setUserCity(e.target.value)} />
              </Form.Group>
              <Form.Group controlId="formStreet">
                <Form.Label>Street:</Form.Label>
                <Form.Control type="text" placeholder="Enter street" value={userStreet} onChange={(e) => setUserStreet(e.target.value)} />
              </Form.Group>
              <Form.Group controlId="formZipCode">
                <Form.Label>Zip Code:</Form.Label>
                <Form.Control type="text" placeholder="Enter zip code" value={userZipCode} onChange={(e) => setUserZipCode(e.target.value)} />
              </Form.Group>
              <Form.Group controlId="formStreetNumber">
                <Form.Label>Street Number:</Form.Label>
                <Form.Control type="text" placeholder="Enter street number" value={userStreetNumber} onChange={(e) => setUserStreetNumber(e.target.value)} />
              </Form.Group>
              <Form.Group controlId="formOther">
                <Form.Label>Other:</Form.Label>
                <Form.Control type="text" placeholder="Enter other information" value={userOther} onChange={(e) => setUserOther(e.target.value)} />
              </Form.Group>
            </Modal.Body>
            <Modal.Footer>
              <NiceButton variant="secondary" onClick={closeModal}>Close</NiceButton>
              {editedLocation ? (
                <NiceButton variant="primary" onClick={handleEditLocation}>Save Changes</NiceButton>
              ) : (
                <NiceButton variant="primary" onClick={handleAddLocation}>Add Location</NiceButton>
              )}
            </Modal.Footer>
          </Form>
        </Modal>

        <Modal show={showDeleteConfirmationModal} onHide={() => setShowDeleteConfirmationModal(false)}>
          <Modal.Header closeButton>
            <Modal.Title>Confirm Delete</Modal.Title>
          </Modal.Header>
          <Modal.Body>Are you sure you want to delete your location data?</Modal.Body>
          <Modal.Footer>
            <NiceButton variant="secondary" onClick={() => setShowDeleteConfirmationModal(false)}>Cancel</NiceButton>
            <NiceButton variant="danger" onClick={confirmDeleteLocation}>Delete</NiceButton>
          </Modal.Footer>
        </Modal>

      <Footer />
      </InfoContainer>
  );
}

export default ProfilePage;
