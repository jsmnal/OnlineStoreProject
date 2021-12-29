/* eslint-disable indent */
import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Button } from 'react-bootstrap';
import productService from '../services/product';
import shopBasketRowsService from '../services/shopBasketRows';
import ShoppingCartRow from './ShoppingCartRow';

const ShoppingCart = () => {
  const [products, setProducts] = useState([]);
  const [update, setUpdate] = useState('');

  useEffect(() => {
    getCurrentShoppingCart();
  }, [update]);

  const getCurrentShoppingCart = async () => {
    try {
      const response = await shopBasketRowsService.getCurrentShopBasket();
      console.log(response);
      const prodArr = [];
      for (let i = 0; i < response.length; i++) {
        let res = await productService.getOne(response[i].productId);
        let formatProduct = {
          ...res,
          quantity: response[i].quantity,
          basketRowId: response[i].id,
        };
        prodArr.push(formatProduct);
      }
      setProducts(prodArr);
    } catch (error) {
      console.log(error);
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
                  basketRowId={p.basketRowId}
                  name={p.name}
                  price={p.price}
                  category={p.category.name}
                  description={p.description}
                  discount={
                    p.discount.activityState
                      ? p.discount.discountPercentage
                      : null
                  }
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
