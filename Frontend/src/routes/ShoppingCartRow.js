import React from 'react';
import { Card, Button } from 'react-bootstrap';
import shopBasketRowsService from '../services/shopBasketRows';
import productService from '../services/product';

const ShoppingCartRow = ({
  id,
  basketRowId,
  name,
  price,
  category,
  description,
  discount,
  setUpdate,
}) => {
  const handleRemove = async (basketId, productId) => {
    try {
      shopBasketRowsService.deleteBasketRow(basketId);
      productService.increaseStockQuantity(productId);
      setUpdate(Date.now);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Card className="mb-3">
      <Card.Header as="h5">
        ID: {id} | {category}
      </Card.Header>
      <Card.Body>
        <Card.Title>
          {name} | {price} {discount ? `| DISCOUNT: ${discount}%` : ''}
        </Card.Title>
        <Card.Text>{description}</Card.Text>
        <Button onClick={() => handleRemove(basketRowId, id)} variant="danger">
          Remove
        </Button>
      </Card.Body>
    </Card>
  );
};

export default ShoppingCartRow;
