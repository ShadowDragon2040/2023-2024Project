import './App.css';
import {BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import Home from './pages';
import SigninPage from './pages/signin';
import Company from './pages/company';
import EnderPage from './pages/Ender';
import AnycubicPage from './pages/Anycubic';
import ElektroplatingPage from './pages/ElektroplatingPage';
import PaintPage from './pages/PaintPage';
import SzemuvegPage from './pages/Szemuveg';
import FiguraPage from './pages/Figura';
import OtthoniDiszPage from './pages/OtthoniDisz';
import AlkatreszPage from './pages/Alkatresz';
import ModelltervezesPage from './pages/ModelltervezesPage';
import SingleProductDisplay from './pages/SingleProductDisplay';
import ShopPage from './pages/ShopPage';
import "bootstrap/dist/css/bootstrap.css"
import CategoryPage from './pages/CategoryPage';
import NewsPage from './pages/NewsPage';

function App() {

  return (
    <Router>
      <Switch>
        <Route path="/" component={Home} exact />
        <Route path="/signin" component={SigninPage} exact />
        <Route path="/company" component={Company} exact />
        <Route path="/Ender" component={EnderPage} exact />
        <Route path="/Anycubic" component={AnycubicPage} exact />
        <Route path="/ElektroplatingPage" component={ElektroplatingPage} exact />
        <Route path="/ModelltervezesPage" component={ModelltervezesPage} exact />
        <Route path="/PaintPage" component={PaintPage} exact />
        <Route path="/SzemuvegPage" component={SzemuvegPage} exact />
        <Route path="/FiguraPage" component={FiguraPage} exact />
        <Route path="/OtthoniDiszPage" component={OtthoniDiszPage} exact />
        <Route path="/AlkatreszPage" component={AlkatreszPage} exact />
        <Route path="/ShopPage" component={ShopPage} exact />
        <Route path="/ShopPage/:ProductId" component={SingleProductDisplay} exact />
        <Route path="/ShopPage/Categories/:CategoryId" component={CategoryPage} exact />
        <Route path="/News" component={NewsPage} exact />
      </Switch>
    </Router>
  );
}
export default App;
