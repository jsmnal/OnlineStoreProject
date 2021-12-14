import { Navbar, Container, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Navigation = () => {
  return (
    <Navbar bg="#ffffff" style={{ boxShadow: '0 0 2px 2px #765d3a' }}>
      <Container>
        <Navbar.Brand as={Link} to="/" style={{ color: '#000000' }}>
          Awesome Brand Logo??
        </Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link as={Link} to="/">
            Home
          </Nav.Link>
          <NavDropdown title="Categories">
            <NavDropdown.Item as={Link} to="/products/category=Nature">
              Nature
            </NavDropdown.Item>
            <NavDropdown.Item as={Link} to="/products/category=Landscape">
              Landscape
            </NavDropdown.Item>
          </NavDropdown>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default Navigation;
