/* eslint-disable indent */
import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Button } from 'react-bootstrap';
import productService from '../services/product';
import localStorage from '../utils/localStorageUtil';
import ShoppingCartRow from './ShoppingCartRow';

const ShoppingCart = () => {
  const [products, setProducts] = useState([]);
  const [update, setUpdate] = useState('');

  useEffect(() => {
    getProducts();
  }, [update]);

  const getProducts = async () => {
    const productsFromLocalStorage = localStorage.getItemsFromCart();
    console.log(productsFromLocalStorage);
    let productArray = [];

    if (productsFromLocalStorage) {
      for (let i = 0; i < productsFromLocalStorage.length; i++) {
        let res = await productService.getOne(productsFromLocalStorage[i].id);
        res.localStorageUuid = productsFromLocalStorage[i].localStorageUuid;
        productArray.push(res);
      }
      setProducts(productArray);
    }
  };

  return (
    <Container className="text-center">
      <Row className="mt-3">
        <h3>Shopping Cart</h3>
        <Col>
          {products.length !== 0 ? (
            products.map((p, indx) => {
              return (
                <ShoppingCartRow
                  key={indx}
                  id={p.id}
                  name={p.name}
                  price={p.price}
                  category={p.category.name}
                  description={p.description}
                  discount={
                    p.discount.activityState
                      ? p.discount.discountPercentage
                      : null
                  }
                  localStorageId={p.localStorageUuid}
                  setUpdate={setUpdate}
                />
              );
            })
          ) : (
            <li>No products in shopping cart</li>
          )}
        </Col>
      </Row>
      <Row>
        <Col>
          <Button variant="primary">Make an order</Button>
        </Col>
      </Row>
    </Container>
  );
};

export default ShoppingCart;
