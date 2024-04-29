import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Navbar from '../../components/MainNavbarComponent';
import Footer from '../../components/FooterComponent';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import { MdArrowBack } from "react-icons/md";
import {
  InfoContainer,
  NiceButton,
  NavBtnLink,
  NavBtn
} from '../../components/TextElements';


function ProfilePage() {
  const [userProfile, setUserProfile] = useState(null);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [editedLocation, setEditedLocation] = useState(null);
  const [showDeleteConfirmationModal, setShowDeleteConfirmationModal] = useState(false);

  const [userHelyadat, setUserHelyadat] = useState(null);
  const [userComments, setUserComments] = useState(null);
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
  }, []);

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

    fetchUserHelyadat();
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
        console.log(response.data);
      } catch (error) {
        console.error('Error fetching user Comments:', error);
      }
    };

    fetchUserComments();
  }, []);

  useEffect(() => {
    const fetchUserSzamlak = async () => {
      try {
        const response = await axios.get(`${process.env.REACT_APP_BASE_URL}Szamlazas/${userId}`,{
          headers:{'Authorization': 'Bearer ' + token}
        });
        setUserSzamlak(response.data);
        console.log(response.data);
      } catch (error) {
        console.error('Error fetching user szamlak:', error);
      }
    };

    fetchUserSzamlak();
  }, []);

  return (
      <InfoContainer>
      <Navbar />
        <div style={{padding: '80px', textAlign: 'left'}}>
        <NavBtn style={{margin: '20px 0px 20px 0px'}}>
          <NavBtnLink to='/ShopPage'><MdArrowBack />Back</NavBtnLink>
        </NavBtn>
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
          {!userProfile && <p>Loading...</p>}
        </div>
        
        <div className="accordion w-50 m-5" id="accordionExample">
        <div className="accordion-item" style={{border:"none"}}>
          <h2 className="accordion-header" id="headingOne">
          <button
            className={`accordion-button ${collapseOneOpen ? '' : 'collapsed'}`}
            style={{ backgroundColor: '#05a866' }}
            type="button"
            onClick={toggleCollapseOne}
            aria-expanded={collapseOneOpen ? "true" : "false"}
            aria-controls="collapseOne"
          >
            Your Comments
          </button>
          </h2>
          <div id="collapseOne" className={`accordion-collapse ${collapseOneOpen ? 'collapse show' : 'collapse'}`} aria-labelledby="headingOne" data-bs-parent="#accordionExample">
            <div className="accordion-body">
              {userComments && userComments.map(comment => (
                <div className="comment-card" key={comment.hozzaszolasId}>
                  <p><strong>Comment ID:</strong> {comment.hozzaszolasId}</p>
                  <p><strong>Product name:</strong></p>
                  <p><strong>Description:</strong> {comment.leiras}</p>
                  <p><strong>Rating:</strong> {comment.ertekeles}</p>
                  <hr style={{border: '2px solid #05a866'}}></hr>
                </div>
              ))}
            </div>
          </div>
        </div>
        <div className="accordion-item" style={{border:"none"}}>
          <h2 className="accordion-header"  id="headingTwo">
          <button
            className={`accordion-button ${collapseTwoOpen ? '' : 'collapsed'}`}
            style={{ backgroundColor: '#05a866' }}
            type="button"
            onClick={toggleCollapseTwo}
            aria-expanded={collapseTwoOpen ? "true" : "false"}
            aria-controls="collapseTwo"
          >
            Your Invoices
          </button>
          </h2>
          <div id="collapseTwo" className={`accordion-collapse ${collapseTwoOpen ? 'collapse show' : 'collapse'}`} aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
            <div className="accordion-body">
              {userSzamlak && userSzamlak.map(invoice => (
                <div className="invoice-card" key={invoice.szamlazasId}>
                  <h3>Invoice</h3>
                  <p><strong>Product ID:</strong> {invoice.termekId}</p>
                  <p><strong>Color:</strong> {invoice.szinHex}</p>
                  <p><strong>Quantity:</strong> {invoice.darab}</p>
                  <p><strong>Purchase Time:</strong> {new Date(invoice.vasarlasIdopontja).toLocaleString()}</p>
                  <p><strong>Successful Delivery:</strong> {invoice.sikeresSzalitas ? 'Yes' : 'No'}</p>
                </div>
              ))}
            </div>
          </div>
        </div>
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
