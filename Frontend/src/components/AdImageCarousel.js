import { Carousel, Container } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import productService from '../services/product';
import config from '../utils/config';

const AdImageCarousel = () => {
  useEffect(() => {
    getNewestImages();
  }, []);

  const [images, setImages] = useState([]);

  const getNewestImages = async () => {
    try {
      const res = await productService.getNewest(4);
      setImages(res);
    } catch (err) {
      console.log(err.message);
    }
  };
  return (
    <Container style={{ marginTop: '20px', boxShadow: '0 0 2px 2px #765d3a' }}>
      <Carousel>
        {images.map((image) => (
          <Carousel.Item key={image.id} id={image.id}>
            <img
              style={{ height: '400px' }}
              className="d-block w-100"
              src={image.imagePath ? config.IMAGE_URL + image.imagePath : ''}
              alt="Image"
            />
          </Carousel.Item>
        ))}
      </Carousel>
    </Container>
  );
};

export default AdImageCarousel;
