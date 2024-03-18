import React, { useState } from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { Form, Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import { NavBtn2, ModalButton } from './TextElements';
import { toast } from 'react-toastify';

const RegisterModal = () => {
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [email, setEmail] = useState('');
  const [showRegisterModal, setShowRegisterModal] = useState(false);
  const [showVerificationModal, setShowVerificationModal] = useState(false);
  const [verificationCode, setVerificationCode] = useState('');

  const handleCloseRegisterModal = () => setShowRegisterModal(false);
  const handleShowRegisterModal = () => setShowRegisterModal(true);
  const handleCloseVerificationModal = () => setShowVerificationModal(false);
  const handleShowVerificationModal = () => setShowVerificationModal(true);

  const handleRegister = async (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      toast("Passwords do not match!");
      return;
    }
    try {
      const response = await axios.post('https://localhost:7026/Auth/register', {
        userName: userName,
        password: password,
        email: email
      });
      console.log("Registration successful:", response.data);
      handleShowVerificationModal();
    } catch (error) {
      console.error("Registration failed:", error);
    } finally {
      handleCloseRegisterModal();
    }
  };

  const handleVerificationSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('https://localhost:7026/Auth/verify-email', {
        email: email,
        emailCode: verificationCode
      });
      console.log("Registration successful:", response.data);
      handleShowVerificationModal();
    } catch (error) {
      console.error("Registration failed:", error);
    } finally {
      handleCloseVerificationModal();
    }
    console.log("Verification code submitted:", verificationCode);
  };

  return (
    <>
      <NavBtn2>
        <ModalButton onClick={handleShowRegisterModal}>Register</ModalButton>
      </NavBtn2>

      <Modal show={showRegisterModal} onHide={handleCloseRegisterModal}>
        <Modal.Header style={{ margin: "10px" }} closeButton>
          <Modal.Title>Register:</Modal.Title>
        </Modal.Header>

        <Form style={{ margin: "10px" }} onSubmit={handleRegister}>
          <Form.Group controlId="formUserName">
            <Form.Label>Username:</Form.Label>
            <Form.Control
              type="text"
              placeholder="Enter username"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formPassword">
            <Form.Label>Password:</Form.Label>
            <Form.Control
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formPasswordAgain">
            <Form.Label>Password again:</Form.Label>
            <Form.Control
              type="password"
              placeholder="Enter password again"
              value={confirmPassword}
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </Form.Group>

          <Form.Group controlId="formEmail">
            <Form.Label>Email address:</Form.Label>
            <Form.Control
              type="email"
              placeholder="Enter email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
          </Form.Group>

          <Button style={{ margin: "10px", backgroundColor: "#01BF71", border: "none" }} variant="primary" type="submit">
            Register
          </Button>
        </Form>
      </Modal>

      <Modal show={showVerificationModal} onHide={handleCloseVerificationModal}>
        <Modal.Header style={{ margin: "10px" }} closeButton>
          <Modal.Title>Enter Verification Code:</Modal.Title>
        </Modal.Header>

        <Form style={{ margin: "10px" }} onSubmit={handleVerificationSubmit}>
          <Form.Group controlId="formVerificationCode">
            <Form.Label>Email Verification Code:</Form.Label>
            <Form.Text>Please check your email for the verification code.</Form.Text>
            <Form.Control
              type="text"
              placeholder="Enter verification code"
              value={verificationCode}
              onChange={(e) => setVerificationCode(e.target.value)}
            />
          </Form.Group>

          <Button style={{ margin: "10px", backgroundColor: "#01BF71", border: "none" }} variant="primary" type="submit">
            Verify Email
          </Button>
        </Form>
      </Modal>
    </>
  );
};

export default RegisterModal;
