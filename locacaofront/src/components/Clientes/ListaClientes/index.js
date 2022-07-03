import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { Button, Table, Container, Row, Col } from 'react-bootstrap';
import { Modal } from 'react-bootstrap';
import { FiEdit, FiUserX } from 'react-icons/fi'


import api from '../../../services/api';


export default function Clientes() {
    const [clientes, setClientes] = useState([]);
    const [clienteSelecionado, setClienteSelecionado] = useState();

    const [modal, setModal] = useState(false);

    const fecharModal = () => setModal(false);


    const navigate = useNavigate()

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
            <Container>
                <Row>
                    <Col><Button className="mb-3 mr-3" href="/">Voltar</Button></Col>
                    <Col><Button className="mb-3" href="/clientes/novo/0">Criar Novo Cliente</Button></Col>
                </Row>
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
                                <td><Button variant="info" onClick={() => editarCliente(cliente.id)}>
                                    <FiEdit size={25} color="#17202a" />
                                </Button>
                                </td>
                                <td><Button variant="danger" onClick={() => selecionarCliente(cliente)}>
                                    <FiUserX size={25} color="#17202a" />
                                </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
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
            </Container>
        </>
    )
}