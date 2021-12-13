import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import Home from './routes/Home';
import Product from './routes/Product';
import NotFound from './routes/404/NotFound';
import NotFoundProduct from './routes/404/NotFoundProduct';

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
      </Routes>
    </Router>
  );
}

export default App;
