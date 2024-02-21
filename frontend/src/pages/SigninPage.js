import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { useEffect,useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { toast } from 'react-toastify';

const SignIn = (props) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async (e) => {
      e.preventDefault();
      try {
        const response = await axios.post('https://localhost:7026/Auth/login', {
          userName: username,
          password: password,
        });
        localStorage.setItem("LoginToken",JSON.stringify(response.data.token))
        const decodedToken = jwtDecode(localStorage.getItem("LoginToken"));
        props.role(decodedToken.role);
        props.bejelenkezve(true);
        toast("Login successful.");
      } catch (error) {
        props.bejelenkezve(false);
        toast("Login failed.");
      }
    };

    return (
      <div>
        
        <div style={{
            width:'50%',
            margin:'auto',
            }}>
            <h1>Login</h1>
            <Form onSubmit={handleLogin}>
                <Form.Group controlId="formUsername">
                <Form.Label>Username</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
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
                <Button variant="primary" type="submit">
                    Login
                </Button>
            </Form>
        </div>
      </div>
    );
};

export default SignIn