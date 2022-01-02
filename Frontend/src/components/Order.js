import React, { useState } from 'react';
import { Form, Button, Row, Col } from 'react-bootstrap';

const Order = () => {
  const [user, setUser] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log(user);
  };

  return (
    <Form onSubmit={(e) => handleSubmit(e)}>
      <Form.Group as={Col} controlId="formGridEmail">
        <Form.Label>Email</Form.Label>
        <Form.Control
          type="email"
          placeholder="Enter email"
          onChange={(e) => setUser({ ...user, email: e.target.value })}
        />
      </Form.Group>

      <Row>
        <Col>
          <Form.Label>First name</Form.Label>
          <Form.Control
            placeholder="First name"
            onChange={(e) => setUser({ ...user, firstName: e.target.value })}
          />
        </Col>
        <Col>
          <Form.Label>Last name</Form.Label>
          <Form.Control
            placeholder="Last name"
            onChange={(e) => setUser({ ...user, lastName: e.target.value })}
          />
        </Col>
      </Row>

      <Form.Group className="mb-3" controlId="formGridAddress1">
        <Form.Label>Address</Form.Label>
        <Form.Control
          placeholder="1234 Main St"
          onChange={(e) => setUser({ ...user, address: e.target.value })}
        />
      </Form.Group>

      <Row className="mb-3">
        <Form.Group as={Col} controlId="formGridCity">
          <Form.Label>City</Form.Label>
          <Form.Control
            onChange={(e) => setUser({ ...user, city: e.target.value })}
          />
        </Form.Group>

        <Form.Group as={Col} controlId="formGridZip">
          <Form.Label>Zip</Form.Label>
          <Form.Control
            onChange={(e) => setUser({ ...user, zip: e.target.value })}
          />
        </Form.Group>
      </Row>

      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );
};

export default Order;
