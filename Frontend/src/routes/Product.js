import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Image, Container, Row, Col, Button } from 'react-bootstrap';

import productService from '../services/product';
import config from '../utils/config';

const Product = () => {
  let params = useParams();
  let navigate = useNavigate();

  const [product, setProduct] = useState([]);

  useEffect(() => {
    getProduct(params.id);
  }, [params.id]);

  const getProduct = async (id) => {
    try {
      const res = await productService.getOne(id);
      setProduct(res);
      await productService.increaseViewsByOne(id);
    } catch (err) {
      console.log(err.message);
      navigate('/404');
    }
  };

  return (
    <Container>
      <Row className="mt-3">
        <Col lg={9} className="text-center">
          {product.imagePath ? (
            <Image
              className="shadow rounded"
              src={config.IMAGE_URL + product.imagePath}
              fluid
            />
          ) : (
            <h3>No image available!</h3>
          )}
        </Col>
        <Col lg={3} className="text-center">
          <Row>
            <h3>{product.name}</h3>
            <p>{product.description}</p>
          </Row>
          <Row className="mt-2">
            <Col>{product.stockQuantity} pc. in stock</Col>
            <Col>Price: {product.price}$</Col>
          </Row>
          <Row className="mt-3">
            <Col>Category: {product.category?.name}</Col>
          </Row>
          <Row>
            <Col className="mt-3">
              <Button variant="primary">Buy now!</Button>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  );
};

export default Product;
