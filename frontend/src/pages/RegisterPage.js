import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import { useEffect,useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';

const Register = () => {
    const [userName, setUserName] = useState('');
    const [fullName, setFullName] = useState('');
    const [age, setAge] = useState(0);
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
  
    const handleRegister = async (e) => {
      e.preventDefault();
      try {
        const response = await axios.post('https://localhost:7026/Auth/register', {
          userName: userName,
          fullName: fullName,
          age: age,
          password: password,
          email: email
        });
        console.log("Registration successful:", response.data);
      } catch (error) {
        console.error("Registration failed:", error);
      }
    };
  
    return (
      <div>
        <div style={{
            width:'50%',
            margin:'auto',
            }}>
            <h1>Register</h1>
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
                <Form.Group controlId="formFullName">
                <Form.Label>Full Name</Form.Label>
                <Form.Control
                    type="text"
                    placeholder="Enter full name"
                    value={fullName}
                    onChange={(e) => setFullName(e.target.value)}
                />
                </Form.Group>
                <Form.Group controlId="formAge">
                <Form.Label>Age</Form.Label>
                <Form.Control
                    type="number"
                    placeholder="Enter age"
                    value={age}
                    onChange={(e) => setAge(e.target.value)}
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
        </div>
      </div>
    );
  };

export default Register