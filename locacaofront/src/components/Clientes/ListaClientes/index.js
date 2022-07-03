import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Table from 'react-bootstrap/Table';
import { Modal } from 'react-bootstrap';

import api from '../../../services/api';


export default function Clientes() {
    const [clientes, setClientes] = useState([]);
    const [clienteSelecionado, setClienteSelecionado] = useState();

    const [modal, setModal] = useState(false);

    const fecharModal = () => setModal(false);


    const navigate = useNavigate();

    async function editarCliente(id) {
        try {
            navigate(`/clientes/novo/${id}`)
        } catch (error) {
            alert('Não foi possível ir para tela de edição');
        }
    }


    async function excluirCliente(id) {
        try {
            await api.delete(`api/clientes/${id}`);
            setModal(false);

        } catch (error) {
            alert('Não foi possível deletar o cliente');
        }
    }

    async function selecionarCliente(cliente) {
        setClienteSelecionado(cliente);
        setModal(true);
    }


    useEffect(() => {
        api.get(`api/clientes`).then(
            response => { setClientes(response.data) }
        )
    }, [excluirCliente])


    return (
        <>
            <div>
                <Button className="mb-3 mr-3" href="/">Voltar</Button>
            </div>

            <div>
                <Button className="mb-3" href="/clientes/novo/0">Criar Novo Cliente</Button>
            </div>

            <div>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Nome</th>
                            <th>CPF</th>
                            <th>Editar</th>
                            <th>Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
                        {clientes.map(cliente => (

                            <tr>
                                <td>{cliente.nome}</td>
                                <td>{cliente.cpf}</td>
                                <td><Button variant="info" onClick={() => editarCliente(cliente.id)}>Editar</Button>
                                </td>
                                <td><Button variant="danger" onClick={() => selecionarCliente(cliente)}>Excluir</Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>

            <Modal show={modal} onHide={fecharModal}>
                <Modal.Body>Você confirma a exclusão deste(a) cliente? : {clienteSelecionado && clienteSelecionado.nome}</Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={fecharModal}>
                        Não
                    </Button>
                    <Button variant="primary" onClick={() => excluirCliente(clienteSelecionado.id)}>
                        Sim
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    )
}