import React, { useState, useEffect } from 'react';
import { Container, Row } from 'react-bootstrap';
import ImageCard from '../components/ImageCard';
import Header from '../components/Header';
import { useParams } from 'react-router-dom';
import productService from '../services/product';
import config from '../utils/config';

const Category = () => {
  let params = useParams();
  useEffect(() => {
    getCategories(params.category);
  }, [params.category]);

  const [products, setProducts] = useState([]);
  const [categoryName, setCategory] = useState([]);

  const getCategories = async (category) => {
    try {
      const res = await productService.getWithCategory(category);
      setProducts(res);
      setCategory('Images of ' + category);
    } catch (err) {
      console.log(err.message);
    }
  };

  return (
    <Container >
      <Header title={categoryName} />
      <Row className="mt-3">
        {products.map((product) => (
          <ImageCard
            key={product.id}
            id={product.id}
            image={
              product.imagePath ? config.IMAGE_URL + product.imagePath : ''
            }
            name={product.name}
            price={product.price}
          />
        ))}
      </Row>
    </Container>
  );
};

export default Category;
