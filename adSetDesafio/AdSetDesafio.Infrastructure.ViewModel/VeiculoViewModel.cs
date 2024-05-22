using System.ComponentModel.DataAnnotations;

namespace AdSetDesafio.Infrastructure.ViewModel
{
    public class VeiculoViewModel
    {
            public int Id { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public int Ano { get; set; }
            public string Placa { get; set; }
            public int? Km { get; set; }
            public string Cor { get; set; }
            public decimal Preco { get; set; }
            public List<string> Opcional { get; set; }
            public List<string> Foto { get; set; }
            public int PacoteICarros { get; set; }
            public int PacoteWebMotors { get; set; }

            public IEnumerable<ValidationResult> Validate()
            {
                var results = new List<ValidationResult>();
                //int qtdeAtivosImobilizadosLista;

                //switch ((SelecaoTipoProtocoloEnum)SelecaoTipoProtocolo)
                //{
                //    case SelecaoTipoProtocoloEnum.ProjetosEstudosConsultoria:
                //        if (string.IsNullOrWhiteSpace(ContratoSGL))
                //            results.Add(new("Nº do Contrato SGL deve ser informado"));
                //        else if (ContratoSGL.Replace("/", "").Replace("-", "").Replace("_", "").Length < 9)
                //            results.Add(new("Nº do Contrato SGL incompleto"));

                //        if (string.IsNullOrWhiteSpace(UnidadeSolicitante))
                //            results.Add(new("Sigla da Unidade Solicitante deve ser informada"));

                //        if (string.IsNullOrWhiteSpace(ContratoSAP) && string.IsNullOrWhiteSpace(ContratoSAPJustificativa))
                //            results.Add(new("Nº do Contrato SAP deve ser informado ou Justificado"));
                //        else if (!string.IsNullOrWhiteSpace(ContratoSAP) && ContratoSAP.Replace("_", "").Length < 10)
                //            results.Add(new("Nº do Contrato SAP incompleto"));

                //        if (string.IsNullOrWhiteSpace(AdministradorEmail))
                //            results.Add(new("Administrador do Contrato deve ser informado"));

                //        if (string.IsNullOrWhiteSpace(QtdArquivos))
                //            results.Add(new("Quantidade de Arquivos do Contrato deve ser informada"));

                //        if (string.IsNullOrWhiteSpace(ValorTotalArquivos))
                //            results.Add(new("Valor Total de Arquivos do Contrato deve ser informado"));

                //        break;

                //    case SelecaoTipoProtocoloEnum.Obras_GerouNumeroContrato:
                //        if (string.IsNullOrWhiteSpace(ContratoSGL))
                //            results.Add(new("Nº do Contrato SGL deve ser informado"));
                //        else if (ContratoSGL.Replace("/", "").Replace("-", "").Replace("_", "").Length < 9)
                //            results.Add(new("Nº do Contrato SGL incompleto"));

                //        if (string.IsNullOrWhiteSpace(UnidadeSolicitante))
                //            results.Add(new("Sigla da Unidade Solicitante deve ser informada"));

                //        if (string.IsNullOrWhiteSpace(ContratoSAP) && string.IsNullOrWhiteSpace(ContratoSAPJustificativa))
                //            results.Add(new("Nº do Contrato SAP deve ser informado ou Justificado"));
                //        else if (!string.IsNullOrWhiteSpace(ContratoSAP) && ContratoSAP.Replace("_", "").Length < 10)
                //            results.Add(new("Nº do Contrato SAP incompleto"));

                //        qtdeAtivosImobilizadosLista = 0;
                //        foreach (var item in ProtocoloAtivoImobilizados)
                //            if (!string.IsNullOrWhiteSpace(item.IdImobilizado) || !string.IsNullOrWhiteSpace(item.IdInventario))
                //                qtdeAtivosImobilizadosLista++;

                //        if (qtdeAtivosImobilizadosLista == 0)
                //            results.Add(new("Deve ser informado pelo menos um Ativos Imobilizados na lista"));

                //        if (string.IsNullOrWhiteSpace(AdministradorEmail))
                //            results.Add(new("Administrador do Contrato deve ser informado"));

                //        break;

                //    case SelecaoTipoProtocoloEnum.Obras_NaoGerouNumeroContrato:
                //        if (string.IsNullOrWhiteSpace(PedidoCompra))
                //            results.Add(new("Nº do Pedido de Compra (PC) deve ser informado"));
                //        else if (PedidoCompra.Replace("_", "").Length < 10)
                //            results.Add(new("Nº do Pedido de Compra (PC) incompleto"));

                //        if (!string.IsNullOrWhiteSpace(RequisicaoCompra) && !string.IsNullOrWhiteSpace(RequisicaoCompra.Replace("_", "")) && RequisicaoCompra.Replace("_", "").Length < 10)
                //            results.Add(new("Nº da Requisição de Compra (RC) incompleto"));

                //        if (string.IsNullOrWhiteSpace(UnidadeSolicitante))
                //            results.Add(new("Sigla da Unidade Solicitante deve ser informada"));

                //        if (string.IsNullOrWhiteSpace(AdministradorEmail))
                //            results.Add(new("Administrador do Contrato deve ser informado"));

                //        qtdeAtivosImobilizadosLista = 0;
                //        foreach (var item in ProtocoloAtivoImobilizados)
                //            if (!string.IsNullOrWhiteSpace(item.IdImobilizado) || !string.IsNullOrWhiteSpace(item.IdInventario))
                //                qtdeAtivosImobilizadosLista++;

                //        if (qtdeAtivosImobilizadosLista == 0)
                //            results.Add(new("Deve ser informado pelo menos um Ativos Imobilizados na lista"));

                //        break;

                //    case SelecaoTipoProtocoloEnum.Obras_GerouOrdemInterna:
                //        if (string.IsNullOrWhiteSpace(OrdemInterna))
                //            results.Add(new("Nº da Ordem Interna (OI) deve ser informado"));

                //        if (string.IsNullOrWhiteSpace(UnidadeSolicitante))
                //            results.Add(new("Sigla da Unidade Solicitante deve ser informada"));

                //        qtdeAtivosImobilizadosLista = 0;
                //        foreach (var item in ProtocoloAtivoImobilizados)
                //            if (!string.IsNullOrWhiteSpace(item.IdImobilizado) || !string.IsNullOrWhiteSpace(item.IdInventario))
                //                qtdeAtivosImobilizadosLista++;

                //        if (qtdeAtivosImobilizadosLista == 0)
                //            results.Add(new("Deve ser informado pelo menos um Ativos Imobilizados na lista"));

                //        if (string.IsNullOrWhiteSpace(AdministradorEmail))
                //            results.Add(new("Administrador do Contrato deve ser informado"));

                //        break;

                //    case SelecaoTipoProtocoloEnum.Obras_GerouDoacao:
                //        if (string.IsNullOrWhiteSpace(Doacao))
                //            results.Add(new("Nº da Doação deve ser informado"));

                //        if (string.IsNullOrWhiteSpace(UnidadeSolicitante))
                //            results.Add(new("Sigla da Unidade Solicitante deve ser informada"));

                //        qtdeAtivosImobilizadosLista = 0;
                //        foreach (var item in ProtocoloAtivoImobilizados)
                //            if (!string.IsNullOrWhiteSpace(item.IdImobilizado) || !string.IsNullOrWhiteSpace(item.IdInventario))
                //                qtdeAtivosImobilizadosLista++;

                //        if (qtdeAtivosImobilizadosLista == 0)
                //            results.Add(new("Deve ser informado pelo menos um Ativos Imobilizados na lista"));

                //        break;
                //}

                return results;
            }
    }
}
