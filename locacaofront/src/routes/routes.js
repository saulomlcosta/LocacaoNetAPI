import React from 'react';
import {
    BrowserRouter,
    Routes as Switch,
    Route,
} from "react-router-dom";
import Locacoes from '../components/Locacoes';
import Clientes from '../components/Clientes/ListaClientes';
import NovoCliente from '../components/Clientes/NovoCliente';
import Filmes from '../components/Filmes';


export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" element={<Locacoes />}></Route>
                <Route path="/clientes" element={<Clientes />}></Route>
                <Route path="/clientes/novo" element={<NovoCliente />}></Route>
                <Route path="/filmes" element={<Filmes />}></Route>
            </Switch>
        </BrowserRouter>
    )
}