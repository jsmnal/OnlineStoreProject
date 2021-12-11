import React from 'react';
import AdImageCarousel from '../components/AdImageCarousel';
import NewestImagesCardRow from '../components/NewestImagesCardRow';
import PopularImagesCardRow from '../components/PopularImagesCardRow';
import Header from '../components/Header';

const Home = () => {
  return (
    <div>
      <AdImageCarousel />
      <Header title="The most popular" />
      <PopularImagesCardRow />
      <Header title="The newest" />
      <NewestImagesCardRow />
    </div>
  );
};

export default Home;
