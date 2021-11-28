import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import AdImageCarousel from './components/AdImageCarousel';
import ImageCardRow from './components/ImageCardRow';

function App() {
  return (
    <div className="App">
      <header className="App-header"></header>
      <TitleHeader />
      <Navigation />
      <AdImageCarousel />
      <ImageCardRow />
      <ImageCardRow />
    </div>
  );
}

export default App;
