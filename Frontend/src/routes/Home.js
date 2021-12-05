import React from 'react';
import AdImageCarousel from '../components/AdImageCarousel';
import ImageCardRow from '../components/ImageCardRow';
import Header from '../components/Header';

const Home = () => {
  return (
    <div>
      <AdImageCarousel />
      <Header title="The most popular" />
      <ImageCardRow />
      <Header title="The newest" />
      <ImageCardRow />
    </div>
  );
};

export default Home;
