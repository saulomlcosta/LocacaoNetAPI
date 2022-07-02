import React from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

export default function NovaLocacao() {
    return (
        <>
            <div>
                <Button className="mb-3" href="/">Voltar</Button>
            </div>

            <div>
                <Form>
                    <Form.Group className="mb-3">
                        <Form.Label>Cliente</Form.Label>
                        <Form.Select>
                            <option>Cliente 1</option>
                            <option>Cliente 2</option>
                        </Form.Select>
                    </Form.Group>

                    <Form.Group className="mb-3">
                        <Form.Label>Filme</Form.Label>
                        <Form.Select>
                            <option>Filme 1</option>
                            <option>Filme 2</option>
                        </Form.Select>
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="dataLocacao">
                        <Form.Label>Data de Locação</Form.Label>
                        <Form.Control type="date" name="dob" placeholder="Data de Locação" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="dataDevolucao">
                        <Form.Label>Data de Devolução</Form.Label>
                        <Form.Control type="date" name="dob" placeholder="Data de Devolução" />
                    </Form.Group>

                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>

        </>
    )
}