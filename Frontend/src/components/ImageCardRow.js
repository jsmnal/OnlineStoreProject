import { Container, Row } from 'react-bootstrap';
import ImageCard from './ImageCard';

const ImageCardRow = () => {
    return (
    <Container style={{'margin-top':'20px'}} className='d-flex justify-content-center'>
        <Row>
            <h2> Title </h2>
            <ImageCard /> 
            <ImageCard /> 
            <ImageCard /> 
            <ImageCard /> 
        </Row>
    </Container>
    )
}

export default ImageCardRow