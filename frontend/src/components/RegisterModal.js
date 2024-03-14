import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import {useState } from 'react';
import { Form, Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import {
  NavBtn2,
  ModalButton
} from './TextElements';
import { toast } from 'react-toastify';

const RegisterModal = (props) => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [email, setEmail] = useState('');
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    
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
      } catch (error) {
        console.error("Registration failed:", error);
      } finally {
        /*ha benne van az inkrement akkor refresselődik az oldalde
        a megjelenés rossz lesz mert a session storage kitisztul ha
        nincs ez a kódrészlet benne akkor meg történnie kell egy refresh
        eseménynek hogy az oldal kinézete frissüljön a megfelelő állapotba.
        props.incrementCounter();*/
        handleClose();
      }
    };

    return (
      <>
        <NavBtn2>
          <ModalButton onClick={handleShow}>Register</ModalButton>
        </NavBtn2>

        <Modal show={show} onHide={handleClose}>
            <Modal.Header style={{margin: "10px"}} closeButton>
              <Modal.Title>Register:</Modal.Title>
            </Modal.Header>

            <Form style={{margin: "10px"}} onSubmit={handleRegister}>
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

                <Button style={{margin: "10px",backgroundColor: "#01BF71", border: "none"}} variant="primary" type="submit">
                    Register
                </Button>
            </Form>
        </Modal>
      </>   
    );
  };

export default RegisterModal 