import React from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default function NovoCliente() {
    return (
        <>
            <div>
                <Button className="mb-3" href="/clientes">Voltar</Button>
            </div>

            <div>
                <Form>
                    <Form.Group className="mb-3" controlId="name">
                        <Form.Label>Nome</Form.Label>
                        <Form.Control type="text" placeholder="Nome" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="cpf">
                        <Form.Label>CPF</Form.Label>
                        <Form.Control type="text" placeholder="CPF" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="dob">
                        <Form.Label>Data de Nascimento</Form.Label>
                        <Form.Control type="date" name="dob" placeholder="Date of Birth" />
                    </Form.Group>

                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>

        </>
    )
}