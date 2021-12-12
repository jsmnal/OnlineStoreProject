import React from 'react';
import { Container, Row, Button, Col } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

const NotFound = () => {
  let navigate = useNavigate();

  const handleClick = () => {
    navigate('/');
  };
  return (
    <Container>
      <Row className="mt-3 text-center">
        <h3>Sorry but we cannot find this product. :(</h3>
      </Row>
      <Row>
        <Col className="text-center">
          <Button onClick={handleClick} className="mt-3">
            Go Back to Home page!
          </Button>
        </Col>
      </Row>
    </Container>
  );
};

export default NotFound;
