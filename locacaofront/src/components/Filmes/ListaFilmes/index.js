import React, { useEffect, useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { Button, Table, Container, Row, Col } from 'react-bootstrap';
import { Modal } from 'react-bootstrap';
import { FiEdit, FiUserX } from 'react-icons/fi'


import api from '../../../services/api';

export default function Filmes() {
    const [filmes, setFilmes] = useState([]);
    const [filmeSelecionado, setFilmeSelecionado] = useState();

    const [modal, setModal] = useState(false);

    const fecharModal = () => setModal(false);


    const navigate = useNavigate()

    async function carregarFilmes() {
        try {
            var response = await api.get(`api/filmes`);

            setFilmes(response.data);
        } catch (error) {
            alert('Não foi possível carregar os filmes');
        }
    }

    // async function editarFilme(id) {
    //     try {
    //         navigate(`/filmes/novo/${id}`)
    //     } catch (error) {
    //         alert('Não foi possível ir para tela de edição');
    //     }
    // }

    async function excluirFilme(id) {
        try {
            await api.delete(`api/filmes/${id}`);
            setModal(false);
            carregarFilmes();
        } catch (error) {
            alert('Não foi possível deletar o filme');
        }
    }

    async function selecionarFilme(filme) {
        setFilmeSelecionado(filme);
        setModal(true);
    }


    useEffect(() => {
        carregarFilmes();
    }, [])

    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3 mr-3" href="/">Voltar</Button></Col>
                    <Col><Button className="mb-3" href="/filmes/novo/0">Adicionar Filmes</Button></Col>
                </Row>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Título</th>
                            <th>Classificação Indicativa</th>
                            <th>Lançamento</th>
                            {/* <th></th> */}
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {filmes.map(filme => (
                            <tr>
                                <td>{filme.titulo}</td>
                                <td>{filme.classificacaoIndicativa}</td>
                                <td>{filme.lancamento}</td>
                                {/* <td><Button variant="info" onClick={() => editarFilme(filme.id)}>
                                    <FiEdit size={25} color="#17202a" />
                                </Button>
                                </td> */}
                                <td><Button variant="danger" onClick={() => selecionarFilme(filme)}>
                                    <FiUserX size={25} color="#17202a" />
                                </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
                <Modal show={modal} onHide={fecharModal}>
                    <Modal.Body>Você confirma a exclusão deste filme? : {filmeSelecionado && filmeSelecionado.titulo}</Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={fecharModal}>
                            Não
                        </Button>
                        <Button variant="primary" onClick={() => excluirFilme(filmeSelecionado.id)}>
                            Sim
                        </Button>
                    </Modal.Footer>
                </Modal>
            </Container>
        </>
    )
}