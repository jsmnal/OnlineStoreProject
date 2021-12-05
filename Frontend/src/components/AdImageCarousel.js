import { Carousel, Container } from 'react-bootstrap';

const AdImageCarousel = () => {
  return (
    <Container style={{ marginTop: '20px', boxShadow: '0 0 2px 2px #765d3a' }}>
      <Carousel>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="holder.js/400x400?text=Image here&bg=000000"
            alt="ImageHere"
          />
        </Carousel.Item>
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="holder.js/400x400?text=Image here&bg=000000"
            alt="ImageHere"
          />
        </Carousel.Item>
      </Carousel>
    </Container>
  );
};

export default AdImageCarousel;
