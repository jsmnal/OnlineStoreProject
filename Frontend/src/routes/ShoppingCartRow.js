import React from 'react';
import { Card, Button } from 'react-bootstrap';
import shopBasketRowsService from '../services/shopBasketRows';
import productService from '../services/product';

const ShoppingCartRow = ({ product, setUpdate }) => {
  const handleRemove = async (product) => {
    try {
      await shopBasketRowsService.deleteBasketRow(product.basketRowId);
      await productService.increaseStockQuantity(product.id, {
        stockQuantity: product.quantity,
      });
      setUpdate(Date.now);
    } catch (error) {
      console.log(error);
    }
  };
  return (
    <Card className="mb-3">
      <Card.Header as="h5">
        ID: {product.id} | {product.category.name}
      </Card.Header>
      <Card.Body>
        <Card.Title>
          {product.name} | {product.price}${' '}
          {product.discount
            ? `| DISCOUNT: ${product.discount.discountPercentage}%`
            : ''}{' '}
          | Quantity: {product.quantity}pc.
        </Card.Title>
        <Card.Text>{product.description}</Card.Text>
        <Button onClick={() => handleRemove(product)} variant="danger">
          Remove
        </Button>
      </Card.Body>
    </Card>
  );
};

export default ShoppingCartRow;
