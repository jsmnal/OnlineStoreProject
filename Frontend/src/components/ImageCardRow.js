import { Container, Row } from 'react-bootstrap';
import { useState, useEffect } from 'react';
import ImageCard from './ImageCard';
import axios from 'axios';

const ImageCardRow = () => {
  const IMAGE_URL = 'https://localhost:5001/images/';
  const PRODUCTS_URL = 'https://localhost:5001/api/Products/';

  useEffect(() => {
    getProducts();
  }, []);

  const [products, setProducts] = useState([]);
  const [loading, setLoading] = useState(false);

  const getProducts = async () => {
    try {
      const res = await axios.get(PRODUCTS_URL);
      setProducts(res.data);
      setLoading(true);
    } catch (err) {
      alert(err.message);
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
              image={product.imagePath ? IMAGE_URL + product.imagePath : ''}
              name={product.name}
              price={product.price}
            />
          ))}
      </Row>
    </Container>
  );
};

export default ImageCardRow;
