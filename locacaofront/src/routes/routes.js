import React from 'react';
import {
    BrowserRouter,
    Routes as Switch,
    Route,
} from "react-router-dom";
import Locacoes from '../components/Locacoes/ListaLocacoes';
import NovaLocacao from '../components/Locacoes/NovaLocacao';
import Clientes from '../components/Clientes/ListaClientes';
import NovoCliente from '../components/Clientes/NovoCliente';
import Filmes from '../components/Filmes/ListaFilmes';
import NovoFilme from '../components/Filmes/NovoFilme';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" element={<Locacoes />}></Route>
                <Route path="/locacoes/novo/:locacaoId" element={<NovaLocacao />}></Route>
                <Route path="/clientes" element={<Clientes />}></Route>
                <Route path="/clientes/novo/:clienteId" element={<NovoCliente />}></Route>
                <Route path="/filmes" element={<Filmes />}></Route>
                <Route path="/filmes/novo:filmeId" element={<NovoFilme />}></Route>
            </Switch>
        </BrowserRouter>
    )
}