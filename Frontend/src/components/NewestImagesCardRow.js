import { Container, Row } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import ImageCard from './ImageCard';
import productService from '../services/product';
import config from '../utils/config';

const NewestImagesCardRow = () => {
  useEffect(() => {
    getProducts();
  }, []);

  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);

  const getProducts = async () => {
    try {
      const res = await productService.getNewest(4);
      setProducts(res);
      setLoading(true);
    } catch (err) {
      console.log(err.message);
    }
  };
  return (
    <Container
      style={{ marginTop: '20px' }}
      className="d-flex justify-content-center"
    >
      <Row>
        {loading &&
          products.map((product) => (
            <ImageCard
              key={product.id}
              id={product.id}
              image={
                product.imagePath ? config.IMAGE_URL + product.imagePath : ''
              }
              name={product.name}
              price={product.price}
            />
          ))}
      </Row>
    </Container>
  );
};

export default NewestImagesCardRow;
