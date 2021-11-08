import { Navbar } from 'react-bootstrap';

function App() {
  return (
    <div className="App">
      <header className="App-header"></header>
      <Navbar bg='primary'>
        <Navbar.Brand style={{color: '#ffffff'}}>
          Online Store
        </Navbar.Brand>
      </Navbar>
    </div>
  );
}

export default App;
