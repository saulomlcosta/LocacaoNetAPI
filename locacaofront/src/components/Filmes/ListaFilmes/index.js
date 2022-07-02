import React from 'react';
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';

export default function Filmes() {
    return (
        <>
            <div>
                <Button className="mb-3 mr-3" href="/">Voltar</Button>
            </div>

            <div>
                <Button className="mb-3" href="/filmes/novo">Adicionar Novos Filmes</Button>
            </div>

            <div>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Título</th>
                            <th>Classificação</th>
                            <th>Lançamento</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
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