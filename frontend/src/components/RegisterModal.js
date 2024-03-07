import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { useEffect,useState } from 'react';
import { Form, Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import {
  InfoContainer3,
  NavBtn2,
  ModalButton
} from './TextElements';

const RegisterModal = () => {
    const [userName, setUserName] = useState('');
    const [fullName, setFullName] = useState('');
    const [age, setAge] = useState(0);
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleRegister = async (e) => {
      e.preventDefault();
      try {
        const response = await axios.post('https://localhost:7026/Auth/register', {
          userName: userName,
          password: password,
          email: email
        });
        console.log("Registration successful:", response.data);
      } catch (error) {
        console.error("Registration failed:", error);
      }
    };
  
    return (
      <>
        <NavBtn2>
          <ModalButton onClick={handleShow}>Register</ModalButton>
        </NavBtn2>

        <Modal show={show} onHide={handleClose}>
          <InfoContainer3>
            Register
          </InfoContainer3>

            <Form onSubmit={handleRegister}>
                <Form.Group controlId="formUserName">
                  <Form.Label>Username</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter username"
                        value={userName}
                        onChange={(e) => setUserName(e.target.value)}
                    />
                  </Form.Group>
                <Form.Group controlId="formPassword">
                  <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                  </Form.Group>
                <Form.Group controlId="formEmail">
                  <Form.Label>Email address</Form.Label>
                    <Form.Control
                        type="email"
                        placeholder="Enter email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </Form.Group>

                <Button variant="primary" type="submit">
                    Register
                </Button>
            </Form>
        </Modal>
      </>   
    );
  };

export default RegisterModal 