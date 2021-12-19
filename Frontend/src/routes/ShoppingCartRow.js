import React from 'react';
import { Card, Button } from 'react-bootstrap';
import localStorage from '../utils/localStorageUtil';

const ShoppingCartRow = ({
  id,
  name,
  price,
  category,
  description,
  discount,
  localStorageId,
  setUpdate,
}) => {
  const handleRemove = (id) => {
    localStorage.removeItemFromCart(id);
    setUpdate(Date.now);
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
        <Button onClick={() => handleRemove(localStorageId)} variant="danger">
          Remove
        </Button>
      </Card.Body>
    </Card>
  );
};

export default ShoppingCartRow;
