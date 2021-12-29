import React from 'react';
import { Card, Button } from 'react-bootstrap';
import shopBasketRowsService from '../services/shopBasketRows';

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
  const handleRemove = async (id) => {
    console.log(basketRowId);
    try {
      shopBasketRowsService.deleteBasketRow(id);
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
        <Button onClick={() => handleRemove(basketRowId)} variant="danger">
          Remove
        </Button>
      </Card.Body>
    </Card>
  );
};

export default ShoppingCartRow;
