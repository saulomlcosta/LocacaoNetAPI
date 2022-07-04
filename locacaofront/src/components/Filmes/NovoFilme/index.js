import React, { useEffect, useState } from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate, useParams } from 'react-router-dom';

import api from '../../../services/api';

export default function NovoFilme() {
    const [arquivoFilme, setArquivoFilme] = useState('');

    async function handleChange(e) {
        e.preventDefault();
        const formData = new FormData();

        formData.append("UploaderName", arquivoFilme.name);
        formData.append("UploaderAddress", 'Address');
        formData.append("file", arquivoFilme);

        try {
            await api.post('api/filmes', formData);
        } catch (error) {
            alert(' Erro ao enviar os filmes ' + error);
        }
    }

    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3" href="/filmes">Voltar</Button></Col>
                </Row>
            </Container>

            <Container>
                <Form onSubmit={handleChange}>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group controlId="formFile" className="mb-3">
                                <Form.Label>Insira a lista de filmes (formato .xlsx)</Form.Label>
                                <Form.Control
                                    onChange={(e) => setArquivoFilme(e.target.files[0])}
                                    type="file"
                                />
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