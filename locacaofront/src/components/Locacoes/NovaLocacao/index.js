import React, { useEffect, useState } from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate, useParams } from 'react-router-dom';
import api from '../../../services/api';

export default function NovaLocacao() {
    const [id, setId] = useState(null);
    const [idCliente, setIdCliente] = useState('');
    const [clientes, setClientes] = useState([]);
    const [filmes, setFilmes] = useState([]);
    const [idFilme, setIdFilme] = useState('');
    const [dataLocacao, setDataLocacao] = useState('');
    const [dataDevolucao, setDataDevolucao] = useState('');


    const { locacaoId } = useParams();

    const navigate = useNavigate();


    useEffect(() => {
        if (locacaoId === '0')
            return;
        else
            carregaLocacao();
    }, locacaoId)

    async function carregaLocacao() {
        try {
            const response = await api.get(`api/locacoes/${locacaoId}`);

            setId(response.data.id);
            setIdCliente(response.data.cliente.id);
            setIdFilme(response.data.filme.id);
            setDataLocacao(response.data.dataNascimento);
            setDataDevolucao(response.data.dataNascimento);
        } catch (error) {
            alert('Erro ao recuperar locacao' + error);
            navigate(`/locacoes`)
        }
    }

    async function carregaClientes() {
        try {
            const response = await api.get(`api/clientes`);

            setClientes(response.data);
        } catch (error) {
            alert('Erro ao recuperar cliente' + error);
        }
    }

    async function carregaFilmes() {
        try {
            const response = await api.get(`api/filmes`);

            setFilmes(response.data);
        } catch (error) {
            alert('Erro ao recuperar filme' + error);
        }
    }

    async function handleChange(e) {
        e.preventDefault();

        var dataLocacaoFormat = new Date(dataLocacao).toISOString();

        var dataDevolucaoFormat = new Date(dataDevolucao).toISOString();


        const payload = {
            id_Cliente: idCliente,
            id_Filme: idFilme,
            dataLocacao: dataLocacaoFormat,
            dataDevolucao: dataDevolucaoFormat
        }

        try {
            if (locacaoId === '0') {
                await api.post('api/locacoes', payload);
            } else {
                payload.id = id;
                await api.put(`api/locacoes/${locacaoId}`, payload);
            }
            navigate(`/`);
        } catch (error) {
            alert(' Erro ao criar locacao ' + error);
        }
    }


    useEffect(() => {
        carregaClientes();
        carregaFilmes();
    }, [])

    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3" href="/">Voltar</Button></Col>
                </Row>
            </Container>

            <Container>
                <Form onSubmit={handleChange}>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group className="mb-3">
                                <Form.Label>Clientes</Form.Label>
                                <Form.Select
                                    value={idCliente}
                                    onChange={e => setIdCliente(e.target.value)}
                                >
                                    <option>Selecione</option>
                                    {clientes.map(cliente => (
                                        <option key={cliente.id} value={cliente.id}>{cliente.nome}</option>
                                    ))}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group className="mb-3">
                                <Form.Label>Filmes</Form.Label>
                                <Form.Select
                                    value={idFilme}
                                    onChange={e => setIdFilme(e.target.value)}
                                >
                                    <option>Selecione</option>
                                    {filmes.map(filme => (
                                        <option key={filme.id} value={filme.id}>{filme.titulo}</option>
                                    ))}
                                </Form.Select>
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs lg="2">
                            <Form.Group className="mb-3" controlId="dataLocacao">
                                <Form.Label>Data de Locação</Form.Label>
                                <Form.Control
                                    value={dataLocacao}
                                    onChange={e => setDataLocacao(e.target.value)}
                                    type="date"
                                    name="dataLocacao"
                                    placeholder="Data de Locação" />
                            </Form.Group>
                        </Col>
                        <Col xs lg="2">
                            <Form.Group className="mb-3" controlId="dataNascimento">
                                <Form.Label>Data de Devolução</Form.Label>
                                <Form.Control
                                    value={dataDevolucao}
                                    onChange={e => setDataDevolucao(e.target.value)}
                                    type="date"
                                    name="dataDevolucao"
                                    placeholder="Data de Devolução" />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <Button variant="primary" type="submit">
                                Submit
                            </Button>
                        </Col>
                    </Row>
                </Form>
            </Container>
        </>
    )
}