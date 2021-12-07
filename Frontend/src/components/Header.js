import { Container, Row } from 'react-bootstrap';

const Header = ({ title }) => {
  return (
    <Container
      style={{ margin: '20px' }}
      className="d-block justify-content-center"
    >
      <Row>
        <h2>{title}</h2>
      </Row>
    </Container>
  );
};

export default Header;
