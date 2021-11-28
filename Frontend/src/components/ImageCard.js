import { Card } from 'react-bootstrap';

const ImageCard = () => {
    return (
    <Card style={{ 'width': '200px', 'margin':'20px', 'box-shadow':'0 0 2px 2px #765d3a'}}>
        <Card.Img style={{ 'margin-top': '10px'}} variant="top" src="holder.js/100px180?text=Image here&bg=000000" />
        <Card.Body>
            <Card.Title>Image</Card.Title>
            <Card.Text>Price:</Card.Text>
        </Card.Body>
    </Card>
    )
}

export default ImageCard