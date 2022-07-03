import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { Button, Table, Container, Row, Col } from 'react-bootstrap';
import { Modal } from 'react-bootstrap';
import { FiEdit, FiUserX } from 'react-icons/fi'
import api from '../../../services/api';


export default function Locacoes() {
    const [locacoes, setLocacoes] = useState([]);
    const [locacaoSelecionada, setLocacaoSelecionada] = useState();

    const [modal, setModal] = useState(false);

    const fecharModal = () => setModal(false);


    const navigate = useNavigate()

    async function editarLocacao(id) {
        try {
            navigate(`/locacoes/novo/${id}`)
        } catch (error) {
            alert('Não foi possível ir para tela de edição');
        }
    }

    async function excluirLocacao(id) {
        try {
            await api.delete(`api/locacoes/${id}`);
            setModal(false);

        } catch (error) {
            alert('Não foi possível deletar a Locação');
        }
    }

    async function selecionarLocacao(locacao) {
        setLocacaoSelecionada(locacao);
        setModal(true);
    }


    useEffect(() => {
        api.get(`api/locacoes`).then(
            response => { setLocacoes(response.data) }
        )
    }, [excluirLocacao])


    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3" href="/locacoes/novo/0">Criar Nova Locação</Button></Col>
                    <Col><Button className="mb-3" href="/clientes">Clientes</Button></Col>
                    <Col><Button className="mb-3" href="/filmes">Filmes</Button></Col>
                </Row>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Cliente</th>
                            <th>Filme</th>
                            <th>Data da Locação</th>
                            <th>Data da Devolução </th>
                            <th></th>
                            <th></th>

                        </tr>
                    </thead>
                    <tbody>
                        {locacoes.map(locacao => (

                            <tr>
                                <td>{locacao.cliente.nome}</td>
                                <td>{locacao.filme.titulo}</td>
                                <td>{locacao.dataLocacao}</td>
                                <td>{locacao.dataDevolucao}</td>
                                <td><Button variant="info" onClick={() => editarLocacao(locacao.id)}>
                                    <FiEdit size={25} color="#17202a" />
                                </Button>
                                </td>
                                <td><Button variant="danger" onClick={() => selecionarLocacao(locacao)}>
                                    <FiUserX size={25} color="#17202a" />
                                </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
                <Modal show={modal} onHide={fecharModal}>
                    {/* <Modal.Body>Você confirma a exclusão desta locação? : {locacaoSelecionada && locacaoSelecionada.nome}</Modal.Body> */}
                    <Modal.Body>Você confirma a exclusão desta locação?</Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={fecharModal}>
                            Não
                        </Button>
                        <Button variant="primary" onClick={() => excluirLocacao(locacaoSelecionada.id)}>
                            Sim
                        </Button>
                    </Modal.Footer>
                </Modal>
            </Container>
        </>
    )
}