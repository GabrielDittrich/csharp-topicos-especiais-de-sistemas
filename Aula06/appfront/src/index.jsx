import { createRoot } from "react-dom/client";
import Layout from "./layout/Layout";
import Home from "./paginas/Home";

const divDoIndex = document.getElementById('root');
const root = createRoot(divDoIndex);

root.render(
    <Layout><Home /></Layout>
);