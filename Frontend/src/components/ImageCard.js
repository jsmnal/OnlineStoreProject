import { Card } from 'react-bootstrap';


const ImageCard = (props) => {
    return (
    <Card style={{ 'width': '200px', 'margin':'20px', 'boxShadow':'0 0 2px 2px #765d3a'}}>
        <Card.Img style={{ 'marginTop': '10px'}} variant="top" src={props.image} />
        <Card.Body>
            <Card.Title>{props.name}</Card.Title>
            <Card.Title> Price: {props.price}</Card.Title>
        </Card.Body>
    </Card>
    )
}

export default ImageCard