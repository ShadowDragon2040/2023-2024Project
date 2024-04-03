import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import {useState } from 'react';
import { Form, Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { toast } from 'react-toastify';
import {
  NavBtn2,
  ModalButton
} from './TextElements';

const LoginModal = (props) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    
    const handleLogin = async (e) => {
      e.preventDefault();
      try {
        const response = await axios.post(`${process.env.BASE_URL}/Auth/login`, {
          userName: username,
          password: password,
        });
        localStorage.setItem("LoginToken",JSON.stringify(response.data.token))
        const decodedToken = jwtDecode(localStorage.getItem("LoginToken"));
        sessionStorage.setItem("decodedTokenRole", decodedToken.role);
        sessionStorage.setItem("bejelenkezve", "true");
        console.log(decodedToken);
        console.log("Login successful.");
        toast("Login successful.");
      } catch (error) {
        sessionStorage.setItem("bejelenkezve", "false");
        console.log("Login failed.", error);
        toast("Login failed.");
      }finally{
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
          <ModalButton onClick={handleShow}>Login</ModalButton>
        </NavBtn2>

          <Modal show={show} onHide={handleClose}>
            <Modal.Header style={{margin: "10px"}} closeButton>
              <Modal.Title>Login:</Modal.Title>
            </Modal.Header>

            <Form  style={{margin: "10px"}} onSubmit={handleLogin}>
                <Form.Group controlId="formUsername">
                  <Form.Label>Username:</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
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

                <Button style={{margin: "10px",backgroundColor: "#01BF71", border: "none"}} variant="primary" type="submit">
                    Login
                </Button>
            </Form>
          </Modal>
      </>
    );
};

export default LoginModal