import React from 'react';
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';

export default function Locacoes() {
    return (
        <>
            <div>
                <Button className="mb-3" href="/clientes/">Clientes</Button>
            </div>

            <div>
                <Button className="mb-3" href="/filmes/">Filmes</Button>
            </div>

            <div>
                <Button className="mb-3" href="/locacao/novo">Criar Nova Locação</Button>
            </div>

            <div>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Cliente</th>
                            <th>Filme</th>
                            <th>Data de Locação</th>
                            <th>Data de Devolução</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                            <td>@mdo</td>

                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                            <td>@fat</td>

                        </tr>
                        <tr>
                            <td>3</td>
                            <td colSpan={2}>Larry the Bird</td>
                            <td>@twitter</td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td colSpan={2}>Larry the Bird</td>
                            <td>@twitter</td>
                        </tr>
                    </tbody>
                </Table>
            </div>
        </>
    )
}