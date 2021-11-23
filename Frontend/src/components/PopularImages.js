import { Card, Container, Row } from 'react-bootstrap';

const PopularImages = () => {
    return (
    <Container style={{'margin-top':'20px'}}>
        <Row>
            <h2> Most popular images </h2>
            <Card style={{ 'width': '200px', 'margin':'20px'}}>
                <Card.Img style={{ 'margin-top': '10px'}} variant="top" src="holder.js/100px180?text=Image here&bg=000000" />
                <Card.Body>
                    <Card.Title>Image</Card.Title>
                    <Card.Text>Price:</Card.Text>
                </Card.Body>
            </Card>
            <Card style={{ 'width': '200px', 'margin':'20px'}}>
                <Card.Img style={{ 'margin-top': '10px'}} variant="top" src="holder.js/100px180?text=Image here&bg=000000" />
                <Card.Body>
                    <Card.Title>Image</Card.Title>
                    <Card.Text>Price:</Card.Text>
                </Card.Body>
            </Card>
            <Card style={{ 'width': '200px', 'margin':'20px'}}>
                <Card.Img style={{ 'margin-top': '10px'}} variant="top" src="holder.js/100px180?text=Image here&bg=000000" />
                <Card.Body>
                    <Card.Title>Image</Card.Title>
                    <Card.Text>Price:</Card.Text>
                </Card.Body>
            </Card>
            <Card style={{ 'width': '200px', 'margin':'20px'}}>
                <Card.Img style={{ 'margin-top': '10px'}} variant="top" src="holder.js/100px180?text=Image here&bg=000000" />
                <Card.Body>
                    <Card.Title>Image</Card.Title>
                    <Card.Text>Price:</Card.Text>
                </Card.Body>
            </Card>
        </Row>
    </Container>
    )
}

export default PopularImages