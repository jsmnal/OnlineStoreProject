import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import Home from './routes/Home';

function App() {
  return (
    <Router>
      <TitleHeader />
      <Navigation />
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route exact path="/products/:id" element={<Home />} />
      </Routes>
    </Router>
  );
}

export default App;
