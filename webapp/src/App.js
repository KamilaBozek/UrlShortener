import './App.css';
import { getAllUrl, createShortUrl } from './services/UrlShortenerService';
import Table from './components/Table'

function App()  {
  const getHeadings = () => {
    return Object.keys(getAllUrl()[0]);
  };

  const getAllData = () => {
    return getAllUrl();
  }

  return (
    <div className="App">
      <header className="App-header">
        <p>
          <input value="test" />
        </p>
        <button onClick={() => createShortUrl("google.com")}>Create short url</button>
        <p>

        </p>
        <p><button onClick={() => getAllUrl()}>getAll</button></p>
      </header>
    </div>
  );
}

export default App;
