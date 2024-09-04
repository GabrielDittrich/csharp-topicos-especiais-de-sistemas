import './App.css'
import Header from './layout/Header';
import Aside from './layout/Aside';
import Footer from './layout/Footer';
import Home from './paginas/Home';
import Nav from './layout/Nav';

function App(){
    return (
        <body>
           <div>
                <Header />

                <Nav />

                <Aside />

                <Main />

                <Footer />

        </div>
    </body>
    );
}

export default App;