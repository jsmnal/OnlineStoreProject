import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import AdImageCarousel from './components/AdImageCarousel';
import PopularImages from './components/PopularImages';

function App() {
  return (
    <div className="App">
      <header className="App-header"></header>
      <TitleHeader />
      <Navigation />
      <AdImageCarousel />
      <PopularImages />
    </div>
  );
}

export default App;
