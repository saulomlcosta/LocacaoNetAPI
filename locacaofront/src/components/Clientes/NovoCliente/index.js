import React, { useEffect, useState } from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate, useParams } from 'react-router-dom';
import api from '../../../services/api';

export default function NovoCliente() {
    const [id, setId] = useState(null);
    const [nome, setNome] = useState('');
    const [cpf, setCPF] = useState('');
    const [dataNascimento, setDataNascimento] = useState('');

    const { clienteId } = useParams();

    const navigate = useNavigate();


    useEffect(() => {
        if (clienteId === '0')
            return;
        else
            carregaCliente();
    }, clienteId)

    async function carregaCliente() {
        try {
            const response = await api.get(`api/clientes/${clienteId}`);

            setId(response.data.id);
            setNome(response.data.nome);
            setCPF(response.data.cpf);
            setDataNascimento(response.data.dataNascimento);
        } catch (error) {
            alert('Erro ao recuperar cliente' + error);
            navigate(`/clientes`)
        }
    }

    async function handleChange(e) {
        e.preventDefault();

        var dataNascimentoFormat = new Date(dataNascimento).toISOString();

        const payload = {
            nome,
            cpf,
            dataNascimento: dataNascimentoFormat
        }

        try {
            if (clienteId === '0') {
                await api.post('api/Clientes', payload);
            } else {
                payload.id = id;
                await api.put(`api/clientes/${clienteId}`, payload);
            }
            navigate(`/clientes`);
        } catch (error) {
            alert(' Erro ao criar cliente ' + error);
        }
    }

    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3" href="/clientes">Voltar</Button></Col>
                    <Col><Button className="mb-3" href="/clientes/novo/0">Criar Novo Cliente</Button></Col>
                </Row>
            </Container>

            <Container>
                <Form onSubmit={handleChange}>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group className="mb-3" controlId="name">
                                <Form.Label>Nome</Form.Label>
                                <Form.Control
                                    value={nome}
                                    onChange={e => setNome(e.target.value)}
                                    type="text"
                                    placeholder="Nome" />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group className="mb-3" controlId="cpf">
                                <Form.Label>CPF</Form.Label>
                                <Form.Control
                                    value={cpf}
                                    onChange={e => setCPF(e.target.value)}
                                    type="text"
                                    placeholder="CPF" />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col xs lg="2">
                            <Form.Group className="mb-3" controlId="dataNascimento">
                                <Form.Label>Data de Nascimento</Form.Label>
                                <Form.Control
                                    value={dataNascimento}
                                    onChange={e => setDataNascimento(e.target.value)}
                                    type="date"
                                    name="dataNascimento"
                                    placeholder="Data de Nascimento" />
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