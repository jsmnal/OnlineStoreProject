import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import Home from './routes/Home';
import Product from './routes/Product';
import NotFound from './routes/404/NotFound';
import Category from './routes/Category';
import NotFoundProduct from './routes/404/NotFoundProduct';
import ShoppingCart from './routes/ShoppingCart';

function App() {
  return (
    <Router>
      <TitleHeader />
      <Navigation />
      <Routes>
        <Route exact path="*" element={<NotFound />} />
        <Route exact path="/" element={<Home />} />
        <Route exact path="/404" element={<NotFoundProduct />} />
        <Route exact path="/products" element={<Home />} />
        <Route exact path="/products/:id" element={<Product />} />
        <Route
          exact
          path="/products/category=:category"
          element={<Category />}
        />
        <Route exact path="/cart" element={<ShoppingCart />} />
      </Routes>
    </Router>
  );
}

export default App;
