import { Carousel, Container } from 'react-bootstrap';
import 'holderjs';

const AdImageCarousel = () => {
    return (
        <Container style={{'margin-top':'20px'}}>
            <Carousel>
                <Carousel.Item>
                    <img className="d-block w-100" src="holder.js/400x400?text=Image here&bg=000000" alt="ImageHere"/>
                </Carousel.Item>
                <Carousel.Item>
                    <img className="d-block w-100" src="holder.js/400x400?text=Image here&bg=000000" alt="ImageHere"/>
                </Carousel.Item>
            </Carousel>
        </Container>
    )
}

export default AdImageCarousel