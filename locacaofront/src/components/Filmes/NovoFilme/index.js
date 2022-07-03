import React, { useEffect, useState } from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import { Link, useNavigate, useParams } from 'react-router-dom';
import api from '../../../services/api';

export default function NovoFilme() {
    return (
        <>
            <Container>
                <Row>
                    <Col><Button className="mb-3" href="/filmes">Voltar</Button></Col>
                </Row>
            </Container>

            <Container>
                <Form>
                    <Row>
                        <Col xs lg="4">
                            <Form.Group className="mb-3" controlId="name">

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