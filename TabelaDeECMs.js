import React, { Component } from 'react';
import { Table } from 'react-bootstrap'



export default class TabelaDeEcms extends Component {

    constructor(props) {
        super(props)
        this.state = {
            localizacoes: []
        };


        fetch('api/SampleData/listarLocalizacoesPorIdEvento')
            .then(response => response.json())
            .then(data => {

                this.setState({
                    localizacoes: data
                });

            });
    }
   
    render() {
        return (
            <div className="divTabelaDeEcms">

                
                <Table bordered hover variant="dark" size="sm" responsive>
                        <thead>
                            <tr>
                                <th>Data</th>
                                <th>Ecm</th>
                                <th>Localizacao</th>
                            </tr>
                        </thead>
                        <tbody >

                            {this.state.localizacoes.map(localizacao =>

                                <tr key={localizacao.idLocalizacao} >
                                    <td>{localizacao.dsDataLocalizacao}</td>
                                    <td>{localizacao.dsEndereco}</td>
                                    <td>{localizacao.dsLocalizacao}</td>

                                </tr>

                            )}

                        </tbody>
                    </Table>                

            </div>
        );

    }

}


