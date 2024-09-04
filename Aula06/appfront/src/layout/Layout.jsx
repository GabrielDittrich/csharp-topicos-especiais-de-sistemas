import './Layout.css'
import Header from './Header';
import Aside from './Aside';
import Footer from './Footer';
import Nav from './Nav';

function Layout(props){
    return (
        <body>
           <div>
                <Header />

                <Nav />

                <Aside />

                <main>{props.children}</main>

                <Footer />

        </div>
    </body>
    );
}

export default Layout;