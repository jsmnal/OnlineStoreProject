import { Navbar, Container } from 'react-bootstrap';

const Navigation = () => {
    return (
        <Navbar bg='#ffffff' style={{'box-shadow':'0 0 2px 2px #765d3a'}}>
            <Container>
                <Navbar.Brand style={{color: '#000000'}}>
                Navs
                </Navbar.Brand>
            </Container>
      </Navbar>
    )
}

export default Navigation