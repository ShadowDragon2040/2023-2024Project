import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import {useState } from 'react';
import { Form, Button, Modal } from 'react-bootstrap';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { toast } from 'react-toastify';
import {
  NavBtnLink,
  NiceButton
} from '../TextElements';



const LoginModal = (props) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [show, setShow] = useState(false);

    const [showResetModal, setShowResetModal] = useState(false);
    const [resetEmail, setResetEmail] = useState('');
    const [resetEmailCode, setResetEmailCode] = useState('');
    const [newPassword, setNewPassword] = useState('');

    const handleClose = () => setShow(false);

    const handleShow = () => setShow(true);
    const handleResetModalClose = () => setShowResetModal(false);
    const handleResetModalShow = () => setShowResetModal(true);
    
    const handleLogin = async (e) => {

      e.preventDefault();
     
      try {
        const response = await axios.post(`${process.env.REACT_APP_BASE_URL}Auth/login`, {
          userName: username,
          password: password,
        });
        
        const token = response; 
        localStorage.setItem("LoginToken", token.data);
        
        const decodedToken = jwtDecode(token.data);
        
        const role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        sessionStorage.setItem("role", role);
        console.log(role);
        sessionStorage.setItem("bejelenkezve", "true");
        toast.success("Login successful.");
      } catch (error) {
        sessionStorage.setItem("bejelenkezve", "false");
        console.log("Login failed.", error);
        toast("Login failed.");
      }finally{
        /*ha benne van az inkrement akkor refresselődik az oldalde
        a megjelenés rossz lesz mert a session storage kitisztul ha
        nincs ez a kódrészlet benne akkor meg történnie kell egy refresh
        eseménynek hogy az oldal kinézete frissüljön a megfelelő állapotba.
        */
       props.incrementCounter();
       handleClose();
      }
    };

    const handlePasswordReset = async () => {
      try {
          const response = await axios.post(`${process.env.REACT_APP_BASE_URL}Auth/updatepassword`, {
              email: resetEmail,
              emailCode: resetEmailCode,
              newPassword: newPassword
          });
          console.log("Password reset successful.");
          toast.success("Password reset successful.");
          handleClose();
      } catch (error) {
          console.log("Password reset failed.", error);
          toast("Password reset failed.");
      }
  };

    return (
      <>
          <NavBtnLink onClick={handleShow}>Login</NavBtnLink>

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

                <NiceButton style={{marginTop: "10px", backgroundColor: "#01BF71", border: "none"}} variant="primary" type="submit">
                    Login
                </NiceButton>
                <NiceButton style={{marginLeft: "200px",backgroundColor: "#01BF71", border: "none"}} variant="primary" onClick={handleResetModalShow}>
                  Forgot Password?
                </NiceButton>
            </Form>
          </Modal>

          <Modal show={showResetModal} onHide={handleResetModalClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Reset Password:</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group controlId="formResetEmail">
                            <Form.Label>Email address:</Form.Label>
                            <Form.Control type="email" placeholder="Enter email" value={resetEmail} onChange={(e) => setResetEmail(e.target.value)} />
                        </Form.Group>
                        <Form.Group controlId="formResetEmailCode">
                            <Form.Label>Email code:</Form.Label>
                            <Form.Control type="text" placeholder="Enter email code" value={resetEmailCode} onChange={(e) => setResetEmailCode(e.target.value)} />
                        </Form.Group>
                        <Form.Group controlId="formNewPassword">
                            <Form.Label>New Password:</Form.Label>
                            <Form.Control type="password" placeholder="New Password" value={newPassword} onChange={(e) => setNewPassword(e.target.value)} />
                        </Form.Group>
                        <NiceButton style={{marginTop: "10px"}} variant="primary" onClick={handlePasswordReset}>
                            Reset Password
                        </NiceButton>
                    </Form>
                </Modal.Body>
            </Modal>
      </>
    );
};

export default LoginModal