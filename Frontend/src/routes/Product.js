import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Image, Container, Row, Col, Button, Alert } from 'react-bootstrap';

import productService from '../services/product';
import shopBasketRowsService from '../services/shopBasketRows';
import config from '../utils/config';

const Product = () => {
  let params = useParams();
  let navigate = useNavigate();

  const [product, setProduct] = useState([]);
  const [update, setUpdate] = useState(null);
  const [alert, setAlert] = useState({ show: false, variant: null, msg: null });

  useEffect(() => {
    getProduct(params.id);
  }, [params.id, update]);

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

  const handleClick = async (item) => {
    const basketRow = {
      quantity: 1,
      productId: item.id,
    };
    try {
      const res = await productService.decreaseStockQuantity(item.id, {
        stockQuantity: 1,
      });
      if (res.error) {
        console.log(res);
        setAlert({
          show: true,
          variant: 'danger',
          msg: 'Cant add item to cart',
        });
        setTimeout(() => {
          setAlert({ show: false, variant: null, msg: null });
        }, 2000);
        throw new Error('Cant decrease stock quantity');
      }
      await shopBasketRowsService.createBasketRow(basketRow);
      setUpdate(Date.now);
      setAlert({
        show: true,
        variant: 'primary',
        msg: `Successfully added: ${product.name} to cart!`,
      });
      setTimeout(() => {
        setAlert({ show: false, variant: null, msg: null });
      }, 2000);
    } catch (error) {
      console.log('Error!', error);
    }
  };

  return (
    <Container>
      <Row className="mt-3">
        <Col lg={9} className="text-center">
          {product.imagePath ? (
            <Image
              style={{ maxHeight: '800px', objectFit: 'cover' }}
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
              <Button variant="primary" onClick={() => handleClick(product)}>
                Buy now!
              </Button>
            </Col>
            {alert.show ? (
              <Row className="mt-2">
                <Col>
                  <Alert variant={alert.variant}>{alert.msg}</Alert>
                </Col>
              </Row>
            ) : null}
          </Row>
        </Col>
      </Row>
    </Container>
  );
};

export default Product;
