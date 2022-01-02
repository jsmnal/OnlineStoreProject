/* eslint-disable indent */
import React, { useState, useEffect } from 'react';
import categoryService from '../services/category';
import { Navbar, Container, Nav, NavDropdown } from 'react-bootstrap';
import { Link, useLocation } from 'react-router-dom';
import shopBasketRowsService from '../services/shopBasketRows';

const Navigation = () => {
  const location = useLocation();
  const [categories, setCategories] = useState([]);
  const [cartItemAmount, setCartItemAmount] = useState(0);

  useEffect(() => {
    getCartItemsAmount();
  }, [location]);

  useEffect(() => {
    getCategories();
  }, []);

  const getCategories = async () => {
    try {
      const res = await categoryService.getAll();
      setCategories(res);
    } catch (err) {
      console.log(err.message);
    }
  };

  const getCartItemsAmount = async () => {
    const cart = await shopBasketRowsService.getCurrentShopBasket();
    setCartItemAmount(cart?.length ?? 0);
  };

  return (
    <Navbar bg="#ffffff" style={{ boxShadow: '0 0 2px 2px #765d3a' }}>
      <Container>
        <Navbar.Brand as={Link} to="/" style={{ color: '#000000' }}>
          Awesome Brand Logo??
        </Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link as={Link} to="/">
            Home
          </Nav.Link>
          <NavDropdown title="Categories">
            {categories.map((category) => {
              return (
                <NavDropdown.Item
                  key={category.id}
                  as={Link}
                  to={`/products/category=${category.name.split(' ')[0]}`}
                >
                  {category.name}
                </NavDropdown.Item>
              );
            })}
          </NavDropdown>
          <Nav.Link as={Link} to="/cart">
            Cart ({cartItemAmount})
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default Navigation;
