import React from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default function NovoFilme() {
    return (
        <>
            <div>
                <Button className="mb-3" href="/filmes">Voltar</Button>
            </div>

            <div>
                <Form>
                    <Form.Group className="mb-3" controlId="name">
                        <Form.Label>Nome</Form.Label>
                        <Form.Control type="text" placeholder="Nome" />
                    </Form.Group>

                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>

        </>
    )
}