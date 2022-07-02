import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import "react-datepicker/dist/react-datepicker.css";
import DatePicker from "react-datepicker";
import api from '../../../services/api';

export default function NovoCliente() {
    const [nome, setNome] = useState('');
    const [cpf, setCPF] = useState('');
    const [dataNascimento, setDataNascimento] = useState('');


    async function novoCliente(e) {
        e.preventDefault();

        var dataNascimentoFormat = new Date(dataNascimento).toISOString();

        const data = {
            nome,
            cpf,
            dataNascimento: dataNascimentoFormat
        }

        try {
            await api.post('api/Clientes', data)
        } catch (error) {
            alert(' Erro ao criar cliente ' + error);
        }
    }

    return (
        <>
            <div>
                <Button className="mb-3" href="/clientes">Voltar</Button>
            </div>

            <div>
                <Form onSubmit={novoCliente}>
                    <Form.Group className="mb-3" controlId="name">
                        <Form.Label>Nome</Form.Label>
                        <Form.Control
                            value={nome}
                            onChange={e => setNome(e.target.value)}
                            type="text"
                            placeholder="Nome" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="cpf">
                        <Form.Label>CPF</Form.Label>
                        <Form.Control
                            value={cpf}
                            onChange={e => setCPF(e.target.value)}
                            type="text"
                            placeholder="CPF" />
                    </Form.Group>

                    <Form.Group className="mb-3" controlId="dataNascimento">
                        <Form.Label>Data de Nascimento</Form.Label>
                        <Form.Control
                            value={dataNascimento}
                            onChange={e => setDataNascimento(e.target.value)}
                            type="date"
                            name="dataNascimento"
                            placeholder="Data de Nascimento" />
                    </Form.Group>

                    <Button variant="primary" type="submit">
                        Submit
                    </Button>
                </Form>
            </div>

        </>
    )
}