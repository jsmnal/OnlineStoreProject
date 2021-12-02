import TitleHeader from './components/TitleHeader';
import Navigation from './components/Navigation';
import AdImageCarousel from './components/AdImageCarousel';
import ImageCardRow from './components/ImageCardRow';
import Header from './components/Header';

function App() {
  return (
    <div className="App">
      <header className="App-header"></header>
      <TitleHeader />
      <Navigation />
      <AdImageCarousel />
      <Header title='The most popular'/>
      <ImageCardRow/>
      <Header title ='The newest'/>
      <ImageCardRow />
    </div>
  );
}

export default App;
